   M S B A M L   `   `   `  ����B  >Tabuada, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Tabuada.ThemeTabuada.Theme  5   	   !clr-namespace:TabuadaTabuada  5   	   5clr-namespace:Tabuada.ExtendersTabuada.Extenders  5   	   7 clr-namespace:Tabuada.ConvertersTabuada.Converters  5   	       Tabuada.MainWindow   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   .windowclr-namespace:Tabuada.Theme     5   	   'localclr-namespace:Tabuada     5   	   5	extendersclr-namespace:Tabuada.Extenders     5   	   7
converters clr-namespace:Tabuada.Converters     5   	     � Title$  TABUADA��5   	   $	��700��6    � SizeToContent$ Height=�6%      StyleWindow#��[  6<    � WindowStartupLocation$ CenterScreen=�6a   ��5   =   �� *
FontFamily+ � 	Resources 5
         BooleanToVisibilityConverter(   "Tabuada.Converters.BooleanToInvert  BooleanToInvert;   5Tabuada.Converters.BooleanToVisibilityConverterInvert & "BooleanToVisibilityConverterInvert �� DataType   Tabuada.ResultadosSoma��%�   &	       &	      &	 &     (�� 9     5      *, +)�� 5   
   6'     5   
   6%     5   
   68   �� 5   
   "  6   .R�5      �� ��6   �� *	Resultado+��63   �� *Cor+5      5      .��5      �� .+�5   
   �� 
�������$��1q�6$    �� Padding$ 10q�68   ._�5      �� .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� -   5         ��Name$ chkTudoAleatorio��5      $!��Toda Tabuada Aleatoriamente��69   {�6_   �� *
Executando+ �� 	Converter# [ 	 d� 	IsChecked	 6�   �� *Aleatoriamente+��6�   �� *
FontFamily+�� 5      -   5        $ chkAleatorio��5      $��10,0,0,0q�65   $��Em Sequencia��6G   {�6^   �� *
Executando+# [ 	 6�   �� *PerguntaSequencial+y�5      �� 
 �� ElementName$
 chkTudoAleatorio�� �� Path$ 	IsChecked�# [ ��6�   �� *
FontFamily+�� 5      -   5        $ chkAudio��5      $��Com Voz��61   $��10,0,0,0q�6b   	 6C   �� *
ComAudio+��6t   �� *
FontFamily+5      �� 5      �� 5      y�6   �� $
 chkAudio��$ 	IsChecked�# [ .+�5       �� $��Velocidade da Voz��6    �� 5!       � Maximum$ 10Q�6    � Value 6*   �� *SpeechSynthesizer.Rate+5$      � 5%      $��0,5,0,0q�6    � RowDefinitions 5&      �� 5'      $
��Auto �6(   �� 5(      $
��Auto �6(    � ColumnDefinitions 5*      �� 5+      $
��Auto �6+   �� 5,      $
��Auto �6+   �� 5-      $��* �6+   �� 5.      $��* �6+   .+�51      �� $��0��6    $��0��6-   $��Tabuada de:��6=   y�6P   �� $
 chkTudoAleatorio��$ 	IsChecked�# [ ��52       �� *
FontFamily+�� 53      -   5        $��1��53      $��0��6,   $��75��6<   $��25(�6g    �� SelectedIndex$ 0��6u   $��0,0,10,0q�54   �   ��53   G   �� *	Tabuada+y�6�   �� $
 chkTudoAleatorio��$ 	IsChecked�# [ {�54   N   �� *
Executando+# [ ��6�   �� *
FontFamily+�� 56      $��0��6    $��1��6-   $��
Operação��6=   ��6M   �� *
FontFamily+�� 57      -   5         ��Name$ cmbOperacao��57      $��1��64   $��1��6A   $	��150��6Q   $��25(�58      $ 0��6-   ��57   ]   �� *	Operacoes+��6   �� *
FontFamily+{�58   l   �� *
Executando+# [ �� 5:      -   5         ��Name$ 	btnInicar��5:      $��1��60   $��2��6=   $	��150��6M   $��Inicia��6Y   {�5;      �� *
Executando+# [ �� 5<      -   5        $ 
btnCancela��5<      $��1��61   $��3��6>   $	��150��6N   $��Cancela��6Z   {�5=      �� *
Executando+5>      5?      5@      � 5A   
   $��0,10,0,0q�6    5B      �� 5C      $��* �6#   �� 5D      $��* �6#   .+�5N      �� $��0��6   $	��400��6%   
�������$��1q�6E   $ 2q�6Y   ._�5O      �� ,   &Tabuada.Extenders.ScrollViewerToBottom   ScrollToBottom . $��10,5,0,0q�6T   .��5P      �� $��25(�6F   $
��Bold"�6T   ��6#   �� *
Resultados+��6f   �� *
FontFamily+5Q      5R      � 5S      $��1��6    5T      �� 5U      $��* �6$   �� 5V      $
��Auto �6$   �� 5W      $
��Auto �6$   .+�5Y      �� $��5,0,0,0q�6   .+�5Z      �� $��0��6    $��Center=�6G   $��60(�6d   $
��Bold"�6r   
����  ���6-   �� *
Pergunta+6�   �� 5[      -   5         ��Name$ 	stkStatus��5[   !   .+�5\      �� $��25(�6$   ��62   �� *Status.Status+��6Q   �� *Status.Brush+��6u   �� *
FontFamily+�� 5]      $��25(�6$   ��62   �� *
FontFamily+
�5^      �� 5_   "   $�Erros: ��6&    �� 5`   "   �6&   �� *Status.Erros+5b      �� 5c      $��25(�6$   ��62   �� *
FontFamily+
�5d      �� 5e   "   $�Tempo: ��6&    �� 5f   "   �6&   �� *Status.Tempo+5h      5i      5j      �� 5k      $��1��6   $��Resposta��6)   $��Center=�69   "   Tabuada.Extenders.TextBoxInt  5l      -	   5          Name$ txtResultado��5l   '   "   Tabuada.Extenders.TextBoxInt   PreviewKeyDown$ TextBox_PreviewKeyDown��6�   $��2��6=   $	��100��6�   $��50(�6�    �� TextAlignment$ Center=�6�   $
��Bold"�6�    �� 	MaxLength$ 3��6�   ��6J   �� *	Resultado+ �� UpdateSourceTrigger$ PropertyChanged=�{�5m   '   �� *
Executando+��6H   �� *
FontFamily+5n      5o      �� 5p   
   $��0,5,0,0q�6   
�������$��1q�65   $��40��6I   ._�5q      � $��5q�6    5r      �� 5s      $
��Auto �6'   �� 5t      $
��Auto �6'   �� 5u      $
��Auto �6'   .+�5x      �� $��0��6   $��0��6)   $��Center=�6U   $
��Bold"�6p   $��15(�6�   ��69   �� *
Cronometro+��6�   �� *
FontFamily+5y      5z      5{      5|      