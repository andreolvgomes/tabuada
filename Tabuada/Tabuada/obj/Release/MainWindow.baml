   M S B A M L   `   `   `  ���� B  >Tabuada, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Tabuada.ThemeTabuada.Theme  !clr-namespace:TabuadaTabuada  5clr-namespace:Tabuada.ExtendersTabuada.Extenders  7 clr-namespace:Tabuada.ConvertersTabuada.Converters      Tabuada.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     .windowclr-namespace:Tabuada.Theme     'localclr-namespace:Tabuada     5	extendersclr-namespace:Tabuada.Extenders     7
converters clr-namespace:Tabuada.Converters       � Title$  TABUADA��$	��700�� � SizeToContent$ Height=�   StyleWindow#��[   � WindowStartupLocation$ CenterScreen=� � 	Resources    BooleanToVisibilityConverter(   "Tabuada.Converters.BooleanToInvert  BooleanToInvert;   5Tabuada.Converters.BooleanToVisibilityConverterInvert & "BooleanToVisibilityConverterInvert �� DataType   Tabuada.ResultadosSoma��%w   &	       &	      &	 
     (��      *, +)��     �� "  .R��� ���� *	Resultado+���� *Cor+.���� .+��� 
�������$��1q� �� Padding$ 10q�._��� .+���  �� Orientation$ 
Horizontal=�.+��� -    ��Name$ chkTudoAleatorio��$#��Toda Tabuada Aleatoriamente ?��{��� *
Executando+ �� 	Converter# [ 	 d� 	IsChecked	 �� *Aleatoriamente+�� -   $ chkAleatorio��$��10,0,0,0q�$��Pergunta sequencial ?��{��� *
Executando+# [ 	 �� *PerguntaSequencial+y��� 
 �� ElementName$
 chkTudoAleatorio�� �� Path$ 	IsChecked�# [ �� -   $ chkAudio��$��Pergunta com Audio ?��$��10,0,0,0q�	 �� *
ComAudio+�� �� y��� $
 chkAudio��$ 	IsChecked�# [ .+��� $��Velocidade da pergunta����  � Maximum$ 10Q� � Value �� *SpeechSynthesizer.Rate+� $��0,5,0,0q� � RowDefinitions �� $
��Auto ��� $
��Auto � � ColumnDefinitions �� $
��Auto ��� $
��Auto ��� $��* ��� $��* �.+��� $��0��$��0��$��Tabuada de:��y��� $
 chkTudoAleatorio��$ 	IsChecked�# [ �� -   $��1��$��0��$��75��$��25(� �� SelectedIndex$ 0��$��0,0,10,0q����� *	Tabuada+y��� $
 chkTudoAleatorio��$ 	IsChecked�# [ {��� *
Executando+# [ �� $��0��$��1��$��
Operação���� -    ��Name$ cmbOperacao��$��1��$��1��$	��150��$��25(�$ 0������ *	Operacoes+{��� *
Executando+# [ �� -    ��Name$ 	btnInicar��$��1��$��2��$	��150��$��Inicia��{��� *
Executando+# [ �� -   $ 
btnCancela��$��1��$��3��$	��150��$��Cancela��{��� *
Executando+� $��0,10,0,0q� �� $��* ��� $��* �.+��� $��0��$	��300��
�������$��1q�$ 2q�._��� ,   &Tabuada.Extenders.ScrollViewerToBottom   ScrollToBottom . .���� $��25(����� *
Resultados+� $��1�� �� $��* ��� $
��Auto ��� $
��Auto �.+��� $��5,0,0,0q�.+��� $��0��$��Center=�$��60(�$
��Bold"�
���  ������ *
Pergunta+�� -    ��Name$ 	stkStatus��.+��� $��25(����� *Status.Status+���� *Status.Brush+�� $��25(�
��� $�Erros: �� �� ��� *Status.Erros+�� $��25(�
��� $�Tempo: �� �� ��� *Status.Tempo+�� $��1��$��Reposta��$��Center=�"   Tabuada.Extenders.TextBoxInt  -	     Name$ txtResultado��"   Tabuada.Extenders.TextBoxInt   PreviewKeyDown$ TextBox_PreviewKeyDown��$��2��$	��100��$��50(� �� TextAlignment$ Center=�$
��Bold"� �� 	MaxLength$ 3������ *	Resultado+ �� UpdateSourceTrigger$ PropertyChanged=�{��� *
Executando+�� $��0,5,0,0q�
�������$��1q�$��40��._�� $��5q� �� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��0��$��0��$��Center=�$
��Bold"�$��15(����� *
Cronometro+