   M S B A M L   `   `   `  ����^  ZPRN221_SE1704_PhanHoangDuy_SE161125, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Candidate_WPF_GUICandidate_WPF_GUI  5   	   "    Candidate_WPF_GUI.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:Candidate_WPF_GUI     5   	   -   5          �Name$  LoginWindowForm��5   	    � Title$ Login Screen��5   	   $	��450��6   $	��800��6+    � WindowStartupLocation$ CenterScreen=�67    � WindowStyle$
 None=�6\   ��5	      �� 5
   
    �� EndPoint$ 0.5,1&�6    �� 
StartPoint$ 0.5,0&�6/   .��5      �  � Color$ 	#FFE58A8A��6   � 5      $ 	#FF64E6EB��6    � Offset$ 1Q�6-   5      .��5      � -   5         �Name$ LoginWindowGrid��5      	 J� RenderTransformOrigin$	 0.506,0.508&�6$   $��0,0,10,0q�6H   .+�5   
   �� -   5        
 ��Name$
 
EmailLabel��5      $��Email��6$   $��
93,133,0,0q�64   $��42��6H   $��85��6T   $��22(�6_   $
��Left=�6m   $	��Top=�6�   �� 5   
   -   5        $
 PasswordLabel��5      $��Password��6'   $
��Left=�6:   $��42��6U   $��
93,207,0,0q�6a   $	��Top=�6u   $	��109��6�   $��22(�6�   �� 5   
   -   5         ��Name$ TxtEmail��5      $
��Left=�6$   $��202,140,0,0q�6?    �� TextWrapping$
 Wrap=�6T   $	��Top=�6h   $	��410��6�   $��35��6�   $��20(�6�   $��admin@hr.com.vn��6�   �� 5   
   -   5         ��Name$ BtnLogin��5      $��Login��6#   $
��Left=�63   $��222,317,0,0q�6N   $	��Top=�6c   $��60��6{   $	��128��6�   $��20(�6�   ���	#FFD9E0E8��5      �� 5      $ 0.5,1&�6&   $ 0.5,0&�67   .��5      � $ 	#FF318736��6#   � 5      $ 	#FF6FDA76��6#   $ 1Q�65   5      5      �� 5   
   -   5        $ 	BtnCancel��5      $��Cancel��6$   $
��Left=�65   $��467,317,0,0q�6P   $	��Top=�6e   $��60��6}   $	��130��6�   $��20(�6�   ��5      �� 5      $ 0.5,1&�6&   $ 0.5,0&�67   .��5      � $ 	#FFCE3B3B��6#   � 5      $ 	#FFE67B7B��6#   $ 1Q�65   5       5"      �� 5#   
   $��Login Screen��6   $��Center=�6'   $��0,49,0,0q�6D   $	��228��6V   $��59��6b   $��36(�6n   $	��Top=�6|   $
��Bold"�6�   G� 5$   
   -   5         G�Name$ TxtPassword��5$      $
��Left=�6+   $��202,214,0,0q�6F   $	��Top=�6[   $	��410��6s   $��35��6   $��20(�6�    G� Password$
 123@��6�   5&      5'      