using ClasePoker.Model;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClasePoker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        public int RondesExtra {  get; set; }

        public Dictionary<int,List<int>> premis = new Dictionary<int, List<int>>()
        {
            { 0, new List<int> { 250, 500, 750, 1000, 4000 } },
            { 1, new List<int> { 50, 100, 150, 200, 250 } },
            { 2, new List<int> { 25, 50, 75, 100, 125 } },
            { 3, new List<int> { 9, 18, 27, 36, 45 } },
            { 4, new List<int> { 6, 12, 18, 24, 30 } },
            { 5, new List<int> { 4, 8, 12, 16, 20 } },
            { 6, new List<int> { 3, 6, 9, 12, 15 } },
            { 7, new List<int> { 2, 4, 6, 8, 10 } },
            { 8, new List<int> { 1, 2, 3, 4, 5 } }
        };
        private void CambiarEstils()
        {
            this.Resources.MergedDictionaries.Clear();
            if (State==GameState.WinPoker || State == GameState.Doble || State ==GameState.Semidoble)
            {
                var diccionari = new ResourceDictionary
                {
                    Source = new Uri("/Estils/TemaVerd.xaml", UriKind.Relative)
                };
                this.Resources.MergedDictionaries.Add(diccionari);
            }
            else
            {
                var diccionari = new ResourceDictionary
                {
                    Source = new Uri("/Estils/TemaBlau.xaml", UriKind.Relative)
                };
                this.Resources.MergedDictionaries.Add(diccionari);
            }

        }
        private void CreaBindings()
        {
            CommandBinding reparteix = new CommandBinding(Commands.Reparteix);
            reparteix.Executed += Reparteix_Executed;
            reparteix.CanExecute += Reparteix_CanExecute;
            this.CommandBindings.Add(reparteix);
            CommandBinding doble = new CommandBinding(Commands.Doble);
            doble.Executed += Doble_Executed;
            doble.CanExecute += Doble_CanExecute;
            this.CommandBindings.Add(doble);
            CommandBinding semiDoble = new CommandBinding (Commands.SemiDoble);
            semiDoble.Executed += SemiDoble_Executed;
            semiDoble.CanExecute += SemiDoble_CanExecute;
            this.CommandBindings.Add(semiDoble);
            CommandBinding apostaMes = new CommandBinding (Commands.ApostaMes);
            apostaMes.Executed += ApostaMes_Executed;
            apostaMes.CanExecute += ApostaMes_CanExecute;
            this.CommandBindings.Add(apostaMes);
            CommandBinding swap = new CommandBinding (Commands.Swap);
            swap.Executed += Swap_Executed;
            swap.CanExecute += Swap_CanExecute;
            this.CommandBindings.Add (swap);
            CommandBinding deal = new CommandBinding(Commands.Deal);
            deal.Executed += Deal_Executed;
            deal.CanExecute += Deal_CanExecute;
            this.CommandBindings.Add(deal);
        }

        private void Deal_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (State == GameState.FirstHand || State == GameState.SecondHand);
        }

        private void Deal_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Deal();
        }

        private void Swap_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (State == GameState.FirstHand);
        }

        private void Swap_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Swap();
        }

        private void ApostaMes_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            bool result = false;
            int increment = int.Parse(e.Parameter.ToString());
            if (increment+Bet <= 5 && State==GameState.NoGame) 
            {
                result = true;
            }
            e.CanExecute=result;
        }

        private void ApostaMes_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            int increment = int.Parse(e.Parameter.ToString());
            Bet += increment;
        }

        private void SemiDoble_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = State == GameState.WinPoker;
        }

        private void SemiDoble_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SemiDoble();
        }

        private void Doble_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = State == GameState.WinPoker;
        }

        private void Doble_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Doble();
        }

        private void Reparteix_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = State == GameState.NoGame;
        }

        private void Reparteix_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Reparteix();
        }

        public enum GameState
        {
            NoGame,FirstHand, SecondHand, Doble, Semidoble, WinPoker
        }
        int bet = 1;

        int credit = 0;
        public int Bet
        {
            get => bet; 
            set
            {
                bet = value;
                txtCredit.Text = $"Credit:{credit}\nBet:{bet}";
            }
        }
        GameState State {  get; set; }
        public int Credit
        {
            get
            {
                return credit;
            }
            set
            {
                credit = value;
                txtCredit.Text = $"Credit:{credit}\nBet:{bet}";
                

            }
        }
        Baralla baralla = new Baralla();
        Ma ma = new Ma();
        public MainWindow()
        {
            InitializeComponent();
            CreaBindings();
            Bet = 1;
            Credit = 100;
            State = GameState.NoGame;
            OnGameStateChange();
        }

        private void btnNovama_Click(object sender, RoutedEventArgs e)
        {
            Reparteix();
        }
        private void Reparteix()
        {
            SetTable();
            baralla.Remena();
            for (int i = 0; i < 5; i++)
            {
                Carta cartaActual = baralla.Roba();
                ma.Afegeix(cartaActual);
                RenderitzaCarta(cartaActual);
            }
            OnGameStateChange();
        }
        private void PokerWinSetup()
        {
            SetTable();
            baralla = new Baralla();
            baralla.Remena();
            Random r = new Random();
            int c = r.Next(0, 5);
            for (int i = 0; i < 5; i++)
            {
                Carta cartaActual = baralla.Roba();
                ma.Afegeix(cartaActual);
                if(c!=i)
                    cartaActual.BocaAvall = true;
                RenderitzaCarta(cartaActual);
            }
            OnGameStateChange();
        }

        private void RenderitzaCarta(Carta cartaActual)
        {
            Image imgCarta = new Image();
            imgCarta.Source = (ImageSource)FindResource(cartaActual.ClauImatge);
            imgCarta.Width = 200;
            imgCarta.Margin = new Thickness(10);
            stkHand.Children.Add(imgCarta);
            imgCarta.MouseDown += TriaCarta;
            imgCarta.Tag = cartaActual;
        }

        private void TriaCarta(object sender, MouseButtonEventArgs e)
        {
            if (State == GameState.FirstHand)
            {
                Image imgCarta = (Image)sender;
                Carta current = imgCarta.Tag as Carta;
                if (current != null)
                {
                    current.BocaAvall = !current.BocaAvall;
                    imgCarta.Source = (ImageSource)FindResource(current.ClauImatge);
                }
            }
            else if(State == GameState.Doble || State==GameState.Semidoble)
            {
                Valor valorClic;
                Valor valorMa=0;
                foreach(Carta c in ma)
                {
                    if (c.BocaAvall)
                        valorMa = c.Valor;
                }
                Image imgCarta = (Image)sender;
                Carta current = imgCarta.Tag as Carta;
                if (current != null)
                {
                    current.BocaAvall = !current.BocaAvall;
                    imgCarta.Source = (ImageSource)FindResource(current.ClauImatge);
                    valorClic = current.Valor;
                    HighCard(valorClic, valorMa, State);
                }
            }
        }
        private void HighCard (Valor clic, Valor ma, GameState state)
        {
            bool result = false;
            if (clic > ma)
            {
                result = true;
            }
            if (result == true)
            {
                if (state == GameState.Doble)
                {
                    Bet += Bet;
                    State = GameState.WinPoker;
                    OnGameStateChange();
                }
                else if (state == GameState.Semidoble)
                {
                    Bet += Bet/2;
                    State = GameState.WinPoker;
                    OnGameStateChange();
                }

            }
            else if (state == GameState.Semidoble)
            {
                credit += Bet / 2;
                State = GameState.NoGame;
                OnGameStateChange();
            }
            else
            {
                State = GameState.NoGame;
                OnGameStateChange();
            }
        }
        private void OnGameStateChange()
        { 
            switch(State)
            {
                case GameState.NoGame:
                    Bet = 1;
                    SetTable();
                    State = GameState.NoGame;
                    btnNovama.IsEnabled = true;
                    btnSwap.IsEnabled = false;
                    btnDeal.IsEnabled = false;
                    btnDoble.IsEnabled = false;
                    btnSemiDoble.IsEnabled = false;
                    btnMaxBet.IsEnabled = true;
                    btnPlusOne.IsEnabled = true;
                    RondesExtra = 0;
                    break;
                case GameState.FirstHand:
                    SenyalaResult();
                    btnNovama.IsEnabled = false;
                    btnSwap.IsEnabled = true;
                    btnDeal.IsEnabled = true;
                    btnPlusOne.IsEnabled = false;
                    btnMaxBet.IsEnabled = false;
                    break;
                case GameState.SecondHand:
                    SenyalaResult();
                    btnNovama.IsEnabled = false;
                    btnSwap.IsEnabled = false;
                    btnDeal.IsEnabled = true;
                    btnPlusOne.IsEnabled = false;
                    btnMaxBet.IsEnabled = false;
                    break;
                case GameState.WinPoker:
                    btnNovama.IsEnabled = false;
                    btnDoble.IsEnabled = true;
                    btnSemiDoble.IsEnabled = true;
                    btnPlusOne.IsEnabled = true;
                    btnMaxBet.IsEnabled = true;
                    PokerWinSetup();
                    State = GameState.WinPoker;
                    btnSwap.IsEnabled = false;
                    btnDeal.IsEnabled = false;
                    break;
                case GameState.Doble:
                    btnSwap.IsEnabled = false;
                    btnDeal.IsEnabled = false;
                    btnNovama.IsEnabled = false;
                    btnDoble.IsEnabled = false;
                    btnSemiDoble.IsEnabled = false;
                    btnPlusOne.IsEnabled = true;
                    btnMaxBet.IsEnabled = true;
                    break;
                case GameState.Semidoble:
                    btnSwap.IsEnabled = false;
                    btnDeal.IsEnabled = false;
                    btnDoble.IsEnabled = false;
                    btnSemiDoble.IsEnabled = false;
                    btnNovama.IsEnabled = false;
                    btnPlusOne.IsEnabled = true;
                    btnMaxBet.IsEnabled = true;
                    break;
            }
            CambiarEstils();
            SenyalaResult();
        }

        private void btnSwap_Click(object sender, RoutedEventArgs e)
        {
            Swap();
        }

        private void SwapFlip()
        {
            
            for(int i = 0; i < ma.Count; i++) 
            {
                if (ma[i].BocaAvall)
                {
                    ma.Elimina(i);
                    Carta actual = baralla.Roba();
                    ma.Afegeix(actual);
                    //Truco barato...
                    i = -1;
                }
            }
            Refresh();
        }

        private void Refresh()
        {
            stkHand.Children.Clear();
            foreach(Carta c in ma)
            {
                RenderitzaCarta(c);
            }
        }

        private void Payout()
        {
            int millorResultat = ma.MillorResultat;
            if (millorResultat != -1 && (State==GameState.FirstHand || State==GameState.SecondHand))
            {
                Bet = premis[millorResultat][Bet - 1];
                State = GameState.WinPoker;
                OnGameStateChange();
            }
            else if(State == GameState.WinPoker) 
            {
                State = GameState.NoGame;
                OnGameStateChange();
            }
            else
            {
                credit -= bet;
                State = GameState.NoGame;
                OnGameStateChange();

            }

        }

        private void btnDeal_Click(object sender, RoutedEventArgs e)
        {
            Deal();
        }
        private void SetTable()
        {
            stkHand.Children.Clear();
            ma = new Ma();
            baralla = new Baralla();
            State = GameState.FirstHand;
            OnGameStateChange();
        }
        private void SenyalaResult()
        {
            foreach (UIElement child in grdPayout.Children)
            {
                // Comprobar si el hijo es un TextBlock
                if (child is TextBlock textBlock)
                {
                    // Comprobar si pertenece a la fila específica
                    if (Grid.GetRow(textBlock) == ma.MillorResultat+1)
                    {
                        // Cambiar el color de Foreground
                        if (ma.MillorResultat != -1)
                            textBlock.Foreground = new SolidColorBrush(Colors.Red);
                    }
                    else if (Grid.GetRow(textBlock) != 0)
                    {
                        textBlock.Foreground = new SolidColorBrush(Colors.White);
                    }
                }
            }
        }

        private void btnPlusOne_Click(object sender, RoutedEventArgs e)
        {
            if (State == GameState.Doble || State == GameState.Semidoble || State == GameState.WinPoker)
            {
                Credit += Bet;
                State = GameState.NoGame;
                OnGameStateChange();
            }

            else if (Bet<5 && State==GameState.NoGame)
            {
                Bet++;
            }
            
        }

        private void btnMaxBet_Click(object sender, RoutedEventArgs e)
        {
            if (State == GameState.Doble || State==GameState.Semidoble || State==GameState.WinPoker)
            {
                Credit += Bet;
                State = GameState.NoGame;
                OnGameStateChange();
            }
            else if (Bet < 5 && State==GameState.NoGame)
            {
                Bet=5;
            }
        }

        private void btnDoble_Click(object sender, RoutedEventArgs e)
        {
            Doble();
        }

        private void btnSemiDoble_Click(object sender, RoutedEventArgs e)
        {
            SemiDoble();
        }

        private void Doble()
        {
            RondesExtra++;
            if (RondesExtra < 5)
            {
                State = GameState.Doble;
                OnGameStateChange();
            }
            else
            {
                State = GameState.NoGame;
                OnGameStateChange();
            }    
        }
        private void SemiDoble()
        {
            RondesExtra++;
            if(RondesExtra < 5)
            {
                State = GameState.Semidoble;
                OnGameStateChange();
            }
            else
            {
                State = GameState.NoGame;
                OnGameStateChange();
            }
        }
        private void Swap()
        { 
            bool flipped = false;
            foreach (Carta c in ma)
            {
                if (c.BocaAvall)
                    flipped = true;
            }
            if (flipped)
            {
                SwapFlip();
                State = GameState.SecondHand;
                OnGameStateChange();
            }
        }

        private void Deal()
        {
            Payout();
            OnGameStateChange();
        }

    }

}