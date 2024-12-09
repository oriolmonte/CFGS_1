using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RPS.Dades;
using RPS.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RPS.ViewModel
{
    public partial class JugadorViewmodel : ObservableObject
    {
        public string[] Moves = ["Rock", "Paper", "Scissors", "Lizard", "Spock"];
        public Dictionary<string, string[]> Wins = new Dictionary<string, string[]>
        {
            { "Rock", ["Scissors", "Lizard"]},
            { "Paper", ["Rock", "Spock"]},
            { "Scissors", ["Paper", "Lizard"] },
            { "Lizard",["Spock", "Paper" ]},
            { "Spock", ["Scissors", "Rock" ] }
        };

        
        [ObservableProperty]
        Gamestate state;
        [ObservableProperty]
        Jugador jugadorActual;
        [ObservableProperty]
        string nom;
        [ObservableProperty]
        int punts;
        [ObservableProperty]
        string foto;
        [ObservableProperty]
        ObservableCollection<Jugador> jugadors = new();
        [ObservableProperty]
        int currentScore = 0;
        [ObservableProperty]
        string resultImgSource;
        [ObservableProperty]
        string computerPickImg;
        [ObservableProperty]
        string yourPickImg;
        [ObservableProperty]
        GameResult result;
        [ObservableProperty]
        bool normal = true;
        [ObservableProperty]
        string gamemode = "Normal";
        [ObservableProperty]
        Visibility vismode = Visibility.Collapsed;
        IRepositori repositori = Repositori.ObreBDClients();

        public JugadorViewmodel()
        {
            Jugadors = repositori.Obten();
            
            State = Gamestate.Entrada;
        }

        [RelayCommand]
        private void LoginRegister()
        {
            Jugadors = repositori.Obten();

            if(Jugadors.Where(y => y.Nom == nom).Any())
            {
                var jugador = Jugadors.Where(y=>y.Nom == nom).FirstOrDefault();
                Punts = jugador.Punts;
                Foto = jugador.Foto;
                JugadorActual = jugador;
            }
            else if(Nom.Length > 0) 
            {
                Jugador nou = new Jugador()
                {
                    Id = Guid.NewGuid().ToString(),
                    Nom = this.Nom,
                    Foto = $"https://loremflickr.com/320/240/?random={nom}",
                    Punts = this.Punts
                };
                repositori.Afegeix(nou);
                JugadorActual = nou;
            }
            Jugadors = repositori.Obten();

        }
        [RelayCommand]
        public void ResultPick(string? pick)
        {
            if (pick != null)
            {
                Random r = new();
                string comPick;
                if (Normal)
                {
                   comPick = Moves[r.Next(Moves.Length-2)];
                }
                else
                    comPick = Moves[r.Next(Moves.Length)];

                ComputerPickImg = $"pack://application:,,,/Resources/{comPick}.png";
                YourPickImg = $"pack://application:,,,/Resources/{pick}.png";

                if (Wins[pick].Contains(comPick))
                {                   
                    CurrentScore += 1;
                    Result = GameResult.Win;
                }
                else if(pick==comPick) 
                {
                    Result = GameResult.Tie;

                }
                else
                {
                    Result = GameResult.Loss;
                }
                State = Gamestate.ResultScreen;
            }
        }
        [RelayCommand]
        private void StartGame()
        {
            try
            {
                LoginRegister();
                if(!Normal)
                {
                    Vismode = Visibility.Visible;
                }
                else
                {
                    Vismode= Visibility.Collapsed;
                }
                if(JugadorActual != null)
                {
                    State = Gamestate.GameScreen;
                }
                else
                    MessageBox.Show("Error al assignar jugador.");
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Error al assignar jugador.\n"+ex.Message);
            }            
        }
        [RelayCommand]
        private void NextResult()
        {
            if(Result==GameResult.Win || Result==GameResult.Tie)
            {
                State = Gamestate.GameScreen;                
            }
            else
            {
                if(CurrentScore>JugadorActual.Punts)
                {
                    JugadorActual.Punts = CurrentScore;
                }
                repositori.Modifica(JugadorActual);
                Jugadors = repositori.Obten();

                
                State = Gamestate.Records;
            }            
        }
        [RelayCommand(CanExecute =nameof(RecordsCan))]
        private void VeureRecords()
        {
             State = Gamestate.Records;
        }
        private bool RecordsCan()
        {
            return State == Gamestate.Entrada;
        }
        [RelayCommand(CanExecute =nameof(AbandonaCan))]
        private void Abandona()
        {
            if(State!=Gamestate.Entrada) 
            {
                State = Gamestate.Entrada;
                CurrentScore = 0;
            }
            else if(State==Gamestate.Entrada)
                App.Current.Shutdown();
        }
        private bool AbandonaCan()
        {
            return State != Gamestate.Records;
        }
        [RelayCommand]
        private void ChangeMode()
        {
            Normal = !Normal;
            if (Normal)
            {
                Gamemode = "Normal";
            }
            else
                Gamemode = "Lizard-Spock";
        }


        [RelayCommand]
        private void StartAgain()
        {
            CurrentScore = 0;
            State = Gamestate.Entrada;
        }
        
    }
    public enum Gamestate
    {
        Entrada, GameScreen, ResultScreen, Records
    }
    public enum GameResult
    {
        No, Win, Loss, Tie
    }
}
