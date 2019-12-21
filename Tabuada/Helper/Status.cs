using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace Tabuada.Helper
{
    public class StatusResult : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null) this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _tempo;

        public string Tempo
        {
            get { return _tempo; }
            set
            {
                if (_tempo != value)
                {
                    _tempo = value;
                    this.OnPropertyChanged("Tempo");
                }
            }
        }

        private System.Windows.Media.Brush _Brush;

        public System.Windows.Media.Brush Brush
        {
            get { return _Brush; }
            set
            {
                if (_Brush != value)
                {
                    _Brush = value;
                    this.OnPropertyChanged("Brush");
                }
            }
        }        

        private string _status;

        public string Status
        {
            get { return _status; }
            set
            {
                if (_status != value)
                {
                    _status = value;
                    this.OnPropertyChanged("Status");
                }
            }
        }

        private int _erros;

        public int Erros
        {
            get { return _erros; }
            set
            {
                if (_erros != value)
                {
                    _erros = value;
                    this.OnPropertyChanged("Erros");
                }
            }
        }

        internal void SetStatusNotify(int erros, string cronometro, DateTime tempo)
        {
            this.Erros = erros; ;
            this.Tempo = cronometro;

            if (this.Erros > 0)
            {
                this.Status = "Erro";
                this.Brush = new SolidColorBrush(Colors.Red);
            }
            else
            {
                if (DateTime.Now.Subtract(tempo).Seconds <= 15)
                {
                    this.Status = "Ótimo";
                    this.Brush = new SolidColorBrush(Colors.Blue);
                }
                else if (DateTime.Now.Subtract(tempo).Seconds > 15 && DateTime.Now.Subtract(tempo).Seconds <= 25)
                {
                    this.Status = "Bom";
                    this.Brush = new SolidColorBrush(Colors.Green);
                }
                else if (DateTime.Now.Subtract(tempo).Seconds > 25 && DateTime.Now.Subtract(tempo).Seconds <= 35)
                {
                    this.Status = "Médio";
                    this.Brush = new SolidColorBrush(Colors.Gray);
                }
                else
                {
                    this.Status = "Ruim";
                    this.Brush = new SolidColorBrush(Colors.Red);
                }
            }
        }
    }
}
