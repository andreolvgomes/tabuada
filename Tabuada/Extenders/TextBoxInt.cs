using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace Tabuada.Extenders
{
    public class TextBoxInt : TextBox
    {
        public TextBoxInt()
        {
            this.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(TextBox_PreviewTextInput);
        }

        private void TextBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            foreach (char c in e.Text)
            {
                if (char.IsDigit(c)) e.Handled = false;
                else e.Handled = true;
            }
        }
    }
}
