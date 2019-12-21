using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace Tabuada
{
    public class ResultadosSoma : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null) this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString()
        {
            return this.Resultado;
        }

        public string Resultado { get; set; }

        private bool _Error;

        public bool Error
        {
            get { return _Error; }
            set
            {
                if (_Error != value)
                {
                    _Error = value;
                    this.OnPropertyChanged("Error");
                    this.OnPropertyChanged("Cor");
                }
            }
        }

        public System.Windows.Media.Brush Cor
        {
            get
            {
                if (this.Error)
                    return new System.Windows.Media.SolidColorBrush(Colors.Red);
                return new System.Windows.Media.SolidColorBrush(Colors.Black);

                //if (this.Error)
                //    return new System.Windows.Media.SolidColorBrush(Colors.Red);
                //return new System.Windows.Media.SolidColorBrush(Colors.White);
            }
        }
    }
}
