using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Tabuada
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow// : Window
    {
        private Provider provider = null;

        public MainWindow()
        {
            InitializeComponent();

            this.provider = new Provider();
            this.stkStatus.Visibility = System.Windows.Visibility.Collapsed;
            this.provider.Event_ConcluidoEventHandler += new EventHandler(Concluido);
            this.DataContext = this.provider;
        }

        private void Concluido(object sender, EventArgs e)
        {
            this.stkStatus.Visibility = System.Windows.Visibility.Visible;
        }

        private void Inicia_Click(object sender, RoutedEventArgs e)
        {
            this.provider.Inicia();
            this.provider.FalaPergunta();
            this.stkStatus.Visibility = System.Windows.Visibility.Collapsed;
            this.txtResultado.Focus();
        }

        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.provider.Resultado = "";
                e.Handled = true;
            }
            else if (e.Key == Key.Enter)
            {
                if (this.ValidaResultado())
                {
                    this.provider.Responde();
                    this.provider.FalaPergunta();
                    this.provider.Resultado = "";
                }
                e.Handled = true;
            }
        }

        private bool ValidaResultado()
        {
            if (this.provider.Pergunta.ToUpper() == "Finalizado".ToUpper()) return false;
            if (string.IsNullOrEmpty(this.provider.Resultado))
            {
                if (this.provider.ComAudio)
                    this.provider.Fala("Informe sua resposta!");
                else
                    MessageBox.Show("Informe o resultado!", "Atenção", MessageBoxButton.OK, MessageBoxImage.Information);
                txtResultado.Focus();
                txtResultado.SelectAll();
                return false;
            }
            return true;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.provider.SetOperador((sender as ComboBox).SelectedItem.ToString());
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            this.provider.SetTabuada((sender as ComboBox).SelectedItem);
        }

        private void Cancela_Click(object sender, RoutedEventArgs e)
        {
            this.provider.Cancela();
            this.stkStatus.Visibility = System.Windows.Visibility.Collapsed;
        }
    }
}
