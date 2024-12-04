using Microsoft.Win32;
using System.Collections.Concurrent;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Buscar
{
    public partial class MainWindow : Window
    {
        // <summary>
        /// Gestiona el token de cancel·lació per permetre aturar threads de manera controlada.
        /// </summary>
        /// 
        private CancellationTokenSource _cancellationTokenSource;


        /// <summary>
        /// Col·lecció observable que conté els resultats trobats; està vinculada al ListView de la UI.
        /// </summary>
        public ObservableCollection<FileResult> Results { get; set; } = new ObservableCollection<FileResult>();

        /// <summary>
        /// Emmagatzema la ruta de la carpeta arrel seleccionada per iniciar la cerca.
        /// </summary>
        private string selectedFolder = string.Empty;

        /// <summary>
        /// Conté el nombre màxim de threads que pot gestionar el sistema (igual al nombre de processadors).
        /// </summary>
        public int MaxThreads { get; } = Environment.ProcessorCount;

        /// <summary>
        /// Guarda els fitxers ja processats per evitar duplicats.
        /// </summary>
        private readonly HashSet<string> processedFiles = new HashSet<string>();

        /// <summary>
        /// Objecte per bloquejar l'accés als recursos compartits entre threads.
        /// </summary>
        private readonly object lockObject = new object();

        /// <summary>
        /// Cua segura per a múltiples threads que conté carpetes pendents de processar.
        /// </summary>
        private ConcurrentQueue<string> folderQueue = new ConcurrentQueue<string>();

        /// <summary>
        /// Comptador del nombre total d'arxius processats durant la cerca.
        /// </summary>
        private int fileCount = 0;

        /// <summary>
        /// Temporitzador per mesurar el temps transcorregut durant la cerca.
        /// </summary>
        private System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();

        /// <summary>
        /// Constructor de la finestra principal. Inicialitza els components i vincula els resultats al ListView.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            ResultsListView.ItemsSource = Results;
        }

        /// <summary>
        /// Mostra un diàleg perquè l'usuari seleccioni la carpeta arrel per començar la cerca.
        /// Desa la carpeta seleccionada a la variable `selectedFolder`.
        /// </summary>
        private void SelectFolder_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFolderDialog();
            if (dialog.ShowDialog() == true)
            {
                selectedFolder = dialog.FolderName; // Guarda la ruta seleccionada
                MessageBox.Show($"Carpeta seleccionada: {selectedFolder}");
            }
        }

        /// <summary>
        /// Inicia la cerca multi-threading. Gestiona la cua de carpetes i els threads.
        /// Mostra un missatge amb el temps transcorregut i els resultats processats.
        /// </summary>
        private async void StartSearch_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(selectedFolder))
            {
                MessageBox.Show("Si us plau, selecciona una carpeta abans de començar la cerca.");
                return;
            }

            string searchPattern = "*"+FileNameTextBox.Text; 
            if (string.IsNullOrWhiteSpace(searchPattern))
            {
                MessageBox.Show("Si us plau, introdueix un patró de cerca.");
                return;
            }

            _cancellationTokenSource = new CancellationTokenSource();
            CancellationToken token = _cancellationTokenSource.Token;

            // Neteja els resultats anteriors
            Results.Clear();
            processedFiles.Clear();
            fileCount = 0;
            folderQueue = new ConcurrentQueue<string>();

            // Afegim la carpeta seleccionada a la cua de treball
            folderQueue.Enqueue(selectedFolder);

            // Inicia el temporitzador per mesurar el temps de cerca
            stopwatch.Restart();

            try
            {
                // Llança la cerca de carpetes i fitxers utilitzant múltiples threads
                var tasks = new List<Task>();

                for (int i = 0; i < MaxThreads; i++)
                {
                    tasks.Add(Task.Run(() => ProcessFolders(searchPattern, token), token));
                }

                // Espera a que totes les tasques finalitzin
                await Task.WhenAll(tasks);

                stopwatch.Stop();
                MessageBox.Show($"Cerca completada en {stopwatch.Elapsed.TotalSeconds:N2} segons. Fitxers trobats: {fileCount}");
            }
            catch (OperationCanceledException)
            {
                stopwatch.Stop();
                MessageBox.Show("Cerca cancel·lada per l'usuari.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"S'ha produït un error: {ex.Message}");
            }
        }

        /// <summary>
        /// Atura la cerca mitjançant el token de cancel·lació.
        /// </summary>
        private void StopSearch_Click(object sender, RoutedEventArgs e)
        {
            if (_cancellationTokenSource != null)
            {
                _cancellationTokenSource.Cancel();
            }
        }

        /// <summary>
        /// Processa les carpetes de manera recursiva. Cerca fitxers que coincideixin amb el nom indicat
        /// i afegeix subcarpetes a la cua.
        /// </summary>
        private async Task ProcessFolders(string fileName, CancellationToken token)
        {
            while (folderQueue.TryDequeue(out string currentFolder))
            {
                try
                {
                    token.ThrowIfCancellationRequested();

                    var files = Directory.GetFiles(currentFolder, fileName);
                    foreach (var file in files)
                    {
                        token.ThrowIfCancellationRequested();
                        lock (lockObject)
                        {
                            if (processedFiles.Add(file))
                            {
                                fileCount++;

                                Application.Current.Dispatcher.Invoke(() =>
                                {
                                    Results.Add(new FileResult
                                    {
                                        Name = Path.GetFileName(file),
                                        Path = file
                                    });
                                });
                            }
                        }
                    }

                    var subfolderTasks = new List<Task>();
                    var subfolders = Directory.GetDirectories(currentFolder);
                    foreach (var subfolder in subfolders)
                    {
                        token.ThrowIfCancellationRequested(); 

                        subfolderTasks.Add(Task.Run(() =>
                        {
                            folderQueue.Enqueue(subfolder);
                        }));
                    }

                    await Task.WhenAll(subfolderTasks);
                }
                catch (OperationCanceledException)
                {
                    break;
                }
                catch (UnauthorizedAccessException)
                {
                }
                catch (Exception ex)
                {
                    // Log unexpected errors
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        Results.Add(new FileResult
                        {
                            Name = "[Error]",
                            Path = $"{currentFolder}: {ex.Message}"
                        });
                    });
                }
            }
        }


        /// <summary>
        /// Detecta el doble clic a un element del ListView i obre el fitxer o la carpeta corresponent.
        /// Aquesta funció ja està completament implementada.
        /// </summary>
        private void ResultsListView_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (ResultsListView.SelectedItem is FileResult selectedFile)
            {
                var hitTest = ResultsListView.InputHitTest(e.GetPosition(ResultsListView)) as FrameworkElement;

                if (hitTest != null && hitTest.DataContext is FileResult)
                {
                    if (hitTest is TextBlock textBlock && textBlock.Text == selectedFile.Name)
                    {
                        OpenFile_Click(selectedFile);
                    }
                    else if (hitTest is TextBlock textBlockPath && textBlockPath.Text == selectedFile.Path)
                    {
                        OpenDirectory_Click(selectedFile);
                    }
                }
            }
        }

        /// <summary>
        /// Obre el fitxer seleccionat amb l'aplicació predeterminada.
        /// </summary>
        private void OpenFile_Click(FileResult file)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = file.Path,
                UseShellExecute = true 
            });

        }

        /// <summary>
        /// Obre la carpeta que conté el fitxer seleccionat.
        /// </summary>
        private void OpenDirectory_Click(FileResult file)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = Path.GetDirectoryName(file.Path),
                UseShellExecute = true,
                Verb = "open"
            });
        }

        /// <summary>
        /// Esborra tots els resultats de la UI i reinicia el conjunt de fitxers processats.
        /// </summary>
        private void ClearResults_Click(object sender, RoutedEventArgs e)
        {
            Results.Clear();
        }
    }

    /// <summary>
    /// Representa un fitxer trobat durant la cerca.
    /// </summary>
    public class FileResult
    {
        public string Name { get; set; }
        public string Path { get; set; }
    }
}