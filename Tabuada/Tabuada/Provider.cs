using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Windows.Media;
using System.Windows.Threading;
using Tabuada.Helper;

namespace Tabuada
{
    public class Provider : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null) this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private bool _PerguntaSequencial;

        public bool PerguntaSequencial
        {
            get { return _PerguntaSequencial; }
            set
            {
                if (_PerguntaSequencial != value)
                {
                    _PerguntaSequencial = value;
                    this.OnPropertyChanged("PerguntaSequencial");
                }
            }
        }

        private bool _aleatoriamente;

        public bool Aleatoriamente
        {
            get { return _aleatoriamente; }
            set
            {
                if (_aleatoriamente != value)
                {
                    _aleatoriamente = value;
                    this.OnPropertyChanged("Aleatoriamente");
                }
            }
        }

        private string _resultado;
        /// <summary>
        /// Reposta do usário
        /// </summary>
        public string Resultado
        {
            get { return _resultado; }
            set
            {
                if (_resultado != value)
                {
                    _resultado = value;
                    this.OnPropertyChanged("Resultado");
                }
            }
        }

        private string _Pergunta;

        public string Pergunta
        {
            get { return _Pergunta; }
            set
            {
                if (_Pergunta != value)
                {
                    _Pergunta = value;
                    this.OnPropertyChanged("Pergunta");
                }
            }
        }

        private bool _ComAudio;

        public bool ComAudio
        {
            get { return _ComAudio; }
            set
            {
                if (_ComAudio != value)
                {
                    _ComAudio = value;
                    this.OnPropertyChanged("ComAudio");
                }
            }
        }


        private string _cronometro;

        public string Cronometro
        {
            get { return _cronometro; }
            set
            {
                if (_cronometro != value)
                {
                    _cronometro = value;
                    this.OnPropertyChanged("Cronometro");
                }
            }
        }

        private bool _executando;

        public bool Executando
        {
            get { return _executando; }
            set
            {
                if (_executando != value)
                {
                    _executando = value;
                    this.OnPropertyChanged("Executando");
                }
            }
        }

        private ObservableCollection<ResultadosSoma> _resultados;
        public ObservableCollection<ResultadosSoma> Resultados
        {
            get { return _resultados; }
            set
            {
                if (_resultados != value)
                {
                    _resultados = value;
                    this.OnPropertyChanged("Resultados");
                }
            }
        }

        public FontFamily FontFamily
        {
            get
            {
                //return new FontFamily("Comic Sans MS");
                return new FontFamily("Comic Sans MS, Verdana");
                //return new FontFamily("MV Boli");
            }
        }

        public List<string> Tabuada { get; set; }
        public List<string> Operacoes { get; set; }
        public StatusResult Status { get; set; }
        private string operador { get; set; }

        private List<TabuadaCorrida> numeros;
        private int tabuada { get; set; }
        private int por = 0;

        private DateTime tempo;
        private Stopwatch cronometro;
        private DispatcherTimer timer;

        public event EventHandler Event_ConcluidoEventHandler;
        public SpeechSynthesizer SpeechSynthesizer { get; set; }
        public string VozPergunta { get; set; }

        public Provider()
        {
            this.Resultados = new ObservableCollection<ResultadosSoma>();
            this.Operacoes = new List<string>() { "+", "*" };
            this.Tabuada = new List<string>() { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };

            this.Status = new StatusResult();    
            this.SpeechSynthesizer = new SpeechSynthesizer();
            this.SpeechSynthesizer.Volume = 100;  // 0...100
            this.SpeechSynthesizer.Rate = 5;     // -10...10

            this.cronometro = new Stopwatch();
            this.timer = new DispatcherTimer();
            this.timer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            this.timer.Tick += new EventHandler(TimeTick);
            this.timer.IsEnabled = true;
        }

        private void OnEvent_ConcluidoEventHandler()
        {
            EventHandler _event = this.Event_ConcluidoEventHandler;
            if (_event != null) _event(this, EventArgs.Empty);
        }

        private void TimeTick(object sender, EventArgs e)
        {
            this.Cronometro = string.Format("{0:00}:{1:00}:{2:000}", cronometro.Elapsed.Minutes, cronometro.Elapsed.Seconds, cronometro.Elapsed.Milliseconds);
        }

        public void Inicia()
        {
            cronometro.Reset();
            cronometro.Start();
            tempo = DateTime.Now;

            this.Executando = true;
            this.numeros = new List<TabuadaCorrida>();
            this.Resultados = new ObservableCollection<ResultadosSoma>();
            this.SetPergunta();
        }

        public void Cancela()
        {
            cronometro.Stop();
            cronometro.Reset();

            this.Executando = false;
            this.numeros = new List<TabuadaCorrida>();
            this.Resultados = new ObservableCollection<ResultadosSoma>();
            this.Pergunta = "";
            this.Resultado = "";
        }

        private void SetPergunta()
        {
            Random rm = new Random();
            if (this.Aleatoriamente)
            {
                do
                {
                    this.tabuada = rm.Next(1, 11);
                } while (!this.TabuadaOk(this.tabuada));
            }
            if (this.PerguntaSequencial && !this.Aleatoriamente)
            {
                this.por = (this.numeros.Count + 1);
            }
            else
            {
                this.por = 0;
                do
                {
                    this.por = rm.Next(1, 11);
                } while (!this.PorOk(por));
            }
            this.numeros.Add(new TabuadaCorrida() { Tabuada = this.tabuada, Por = this.por });
            switch (this.operador)
            {
                case "+":
                    this.Pergunta = string.Format("{0} {1} {2}", this.tabuada, this.operador, por);
                    this.VozPergunta = (string.Format("{0} mais {1}", this.tabuada, por));
                    break;
                case "*":
                    this.Pergunta = string.Format("{0} {1} {2}", this.tabuada, this.operador, por);
                    this.VozPergunta = (string.Format("{0} vezes {1}", this.tabuada, por));
                    break;
                case "-":
                    this.Pergunta = string.Format("{0} {1} {2}", por, this.operador, this.tabuada);
                    this.VozPergunta = (string.Format("{0} menos {1}", por, this.tabuada));
                    break;
                case "/":
                    this.Pergunta = string.Format("{0} {1} {2}", por, this.operador, this.tabuada);
                    this.VozPergunta = (string.Format("{0} dividido {1}", por, this.tabuada));
                    break;
            }
        }

        private bool TabuadaOk(int tabuada)
        {
            int count = this.numeros.Count(c => c.Tabuada == tabuada);
            return (count < 10);
        }

        private bool PorOk(int i)
        {
            TabuadaCorrida current = this.numeros.FirstOrDefault(c => c.Tabuada == this.tabuada && c.Por == this.por);
            if (current != null) return false;
            return true;
        }

        public void Responde()
        {
            int value = this.GetResult();
            if (value == Convert.ToInt16(this.Resultado))
                this.Resultados.Add(new ResultadosSoma() { Resultado = string.Format("{0} = {1}", this.Pergunta, this.Resultado) });
            else
                this.Resultados.Add(new ResultadosSoma() { Resultado = string.Format("{0} = {1} - Erro({2})", this.Pergunta, value, this.Resultado), Error = true });
            if (this.IsSetPergunta())
            {
                this.SetPergunta();
            }
            else
            {
                this.Pergunta = "Finalizado";
                cronometro.Stop();

                this.OnEvent_ConcluidoEventHandler();
                this.Status.SetStatusNotify(this.Resultados.Count(c => c.Error), this.Cronometro.Substring(0, 5), tempo);
                this.Executando = false;
            }
            this.Resultado = "";
        }

        private int GetResult()
        {
            switch (this.operador)
            {
                case "+":
                    return (this.tabuada + this.por);
                case "*":
                    return (this.tabuada * this.por);
                case "-":
                    return (this.por - this.tabuada);
                case "/":
                    return (this.por / this.tabuada);
            }
            return -0;
        }

        private bool IsSetPergunta()
        {
            if (this.Aleatoriamente)
                return (this.numeros.Count < 100);
            return (this.numeros.Count < 10);
        }

        internal void SetOperador(string selected)
        {
            this.operador = selected.ToString();
        }

        internal void SetTabuada(object selected)
        {
            this.tabuada = Convert.ToInt16(selected);
        }

        public void FalaPergunta()
        {
            if (this.Executando)
            {
                if (this.ComAudio)
                {
                    this.SpeechSynthesizer.SpeakAsync(this.VozPergunta);
                }
            }
        }

        public void Fala(string palavra)
        {
            if (this.ComAudio)
            {
                this.SpeechSynthesizer.SpeakAsync(palavra);
            }
        }
    }
}
