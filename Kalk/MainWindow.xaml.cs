using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Kalk
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double num1 = 0;
        private double num2 = 0;
        private string dzialanie = "";
        private bool podzialaniu = false;
        private string number = System.String.Empty;
        private string separator = "";

        public MainWindow()
        {
            InitializeComponent();
            separator = Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            Comma.Content = separator;
        }

        private void Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string buttonContent = button.Content.ToString();

            if (char.IsDigit(buttonContent, 0))
            {
                if (dzialanie == "")
                {
                    if (txtBox.Text == "0" || txtBox.Text == "Dzielenie przez 0!" || txtBox.Text == "Nieokreślony wynik.")
                    {
                        EnableButtons();
                        txtBox.Text = "";
                    }
                    if (podzialaniu == true)
                    {
                        txtBox.Text = "";
                        podzialaniu = false;
                    }
                    txtBox.Text += buttonContent;

                }
                else
                {
                    if (txtBox.Text == "0" || txtBox.Text == "Dzielenie przez 0!" || txtBox.Text == "Nieokreślony wynik.")
                    {
                        EnableButtons();
                        txtBox.Text = "";
                    }
                    if (podzialaniu == true)
                    {
                        txtBox.Text = "";
                        podzialaniu = false;
                    }
                    txtBox.Text += buttonContent;
                    try
                    {
                        num2 = Convert.ToDouble(txtBox.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Liczba jest większa niż double");
                    }

                }
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                num1 = Double.Parse(txtBox.GetLineText(0));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nie mozna przekonwertowac liczby");
            }
            dzialanie = "+";
            txt2Box.Text = txtBox.GetLineText(0) + " +";

            try
            {
                num2 = Convert.ToDouble(txtBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Liczba jest większa niż double");
            }
            podzialaniu = true;
        }

        private void Sub_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                num1 = Double.Parse(txtBox.GetLineText(0));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nie mozna przekonwertowac liczby");
            }
            dzialanie = "-";
            txt2Box.Text = txtBox.GetLineText(0) + " -";

            try
            {
                num2 = Convert.ToDouble(txtBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Liczba jest większa niż double");
            }
            podzialaniu = true;
        }

        private void Multiply_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                num1 = Double.Parse(txtBox.GetLineText(0));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nie mozna przekonwertowac liczby");
            }
            dzialanie = "*";
            txt2Box.Text = txtBox.GetLineText(0) + " *";

            try
            {
                num2 = Convert.ToDouble(txtBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Liczba jest większa niż double");
            }
            podzialaniu = true;
        }

        private void Div_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                num1 = Double.Parse(txtBox.GetLineText(0));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nie mozna przekonwertowac liczby");
            }
            dzialanie = "/";
            txt2Box.Text = txtBox.GetLineText(0) + " /";

            try
            {
                num2 = Convert.ToDouble(txtBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Liczba jest większa niż double");
            }
            podzialaniu = true;
        }

        private void Result_Click(object sender, RoutedEventArgs e)
        {
            switch (dzialanie)
            {
                case "+":
                    txtBox.Text = (num1 + num2).ToString();
                    txt2Box.Text = "";
                    dzialanie = "";
                    try
                    {
                        num1 = Convert.ToDouble(txtBox.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Liczba jest większa niż double");
                    }
                    break;
                case "-":
                    txtBox.Text = (num1 - num2).ToString();
                    txt2Box.Text = "";
                    dzialanie = "";
                    try
                    {
                        num1 = Convert.ToDouble(txtBox.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Liczba jest większa niż double");
                    }
                    break;
                case "/":
                    if (num1 == 0 && num2 == 0)
                    {
                        txt2Box.Text = "";
                        txtBox.Text = "Nieokreślony wynik.";
                        DisableButtons();
                    }
                    else if (num2 == 0)
                    {
                        txt2Box.Text = "";
                        txtBox.Text = "Dzielenie przez 0!";
                        DisableButtons();
                    }
                    else
                    {
                        txtBox.Text = (num1 / num2).ToString();
                        txt2Box.Text = "";
                        dzialanie = "";
                        try
                        {
                            num1 = Convert.ToDouble(txtBox.Text);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Liczba jest większa niż double");
                        }
                    }
                    break;
                case "*":
                    txtBox.Text = (num1 * num2).ToString();
                    txt2Box.Text = "";
                    dzialanie = "";
                    try
                    {
                        num1 = Convert.ToDouble(txtBox.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Liczba jest większa niż double");
                    }
                    break;
            }
        }

        private void CE_Click(object sender, RoutedEventArgs e)
        {
            if (txtBox.Text == "Dzielenie przez 0!" || txtBox.Text == "Nieokreślony wynik.")
            {
                EnableButtons();
            }
            txtBox.Text = "0";
            if (dzialanie == "")
            {
                num1 = 0;
            }
            else
            {
                num2 = 0;
            }
        }

        private void C_Click(object sender, RoutedEventArgs e)
        {
            if (txtBox.Text == "Dzielenie przez 0!" || txtBox.Text == "Nieokreślony wynik.")
            {
                EnableButtons();
            }
            txtBox.Text = "0";
            num1 = 0;
            num2 = 0;
            dzialanie = "";
            txt2Box.Text = "";
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (txtBox.Text == "Dzielenie przez 0!" || txtBox.Text == "Nieokreślony wynik.")
            {
                EnableButtons();
                txtBox.Text = "0";
                num1 = 0;
                num2 = 0;
                dzialanie = "";
                txt2Box.Text = "";
            }
            else
            {
                if (dzialanie == "")
                {
                    txtBox.Text = txtBox.Text.Substring(0, (txtBox.Text.Length - 1));
                    if (txtBox.Text == "")
                    {
                        txtBox.Text = "0";
                    }
                    if (txtBox.Text == "-")
                    {
                        txtBox.Text = "0";
                    }
                    num1 = Convert.ToDouble(txtBox.Text);
                }
                else
                {
                    txtBox.Text = txtBox.Text.Substring(0, (txtBox.Text.Length - 1));
                    num2 = 0;
                    if (txtBox.Text == "")
                    {
                        txtBox.Text = "0";
                    }
                    if (txtBox.Text == "-")
                    {
                        txtBox.Text = "0";
                    }
                    num2 = Convert.ToDouble(txtBox.Text);
                }
            }
        }

        private void Znak_Click(object sender, RoutedEventArgs e)
        {
            string textBoxContent = txtBox.Text;

            if (char.IsNumber(textBoxContent, 0))
            {
                List<char> source = new List<char>(this.txtBox.Text.ToList<char>());
                if (source.Count > 0)
                {
                    if (source.ElementAt<char>(0) == '-')
                    {
                        if (dzialanie == "")
                        {
                            source.RemoveAt(0);
                            num1 *= -1.0;
                            txtBox.Text = num1.ToString();
                        }
                        else
                        {
                            source.RemoveAt(0);
                            num2 *= -1.0;
                            txtBox.Text = num2.ToString();
                        }
                    }
                    else
                    {
                        if (source.ElementAt<char>(0) != '0')
                        {
                            if (dzialanie == "")
                            {
                                source.Insert(0, '-');
                                num1 *= -1.0;
                                txtBox.Text = num1.ToString();
                            }
                            else
                            {
                                source.Insert(0, '-');
                                num2 *= -1.0;
                                txtBox.Text = num2.ToString();
                            }
                        }

                        if ((source.Count > 1) && ((source.ElementAt<char>(0) == '0') && (source.ElementAt<char>(1) == ',')))
                        {
                            if (dzialanie == "")
                            {
                                source.Insert(0, '-');
                                num1 *= -1.0;
                                txtBox.Text = num1.ToString();
                            }
                            else
                            {
                                source.Insert(0, '-');
                                num2 *= -1.0;
                                txtBox.Text = num2.ToString();
                            }
                        }


                    }
                    this.txtBox.Text = this.listaString(source);
                }
            }

        }

        private void Comma_Click(object sender, RoutedEventArgs e)
        {
            List<char> lista = new List<char>(this.txtBox.Text.ToList<char>());
            if (!lista.Contains(',') && !lista.Contains('.'))
            {
                if (lista.Count == 0)
                {
                    lista.Add('0');
                }
                if (separator == ".")
                {
                    lista.Add('.');
                }
                else if (separator == ",")
                {
                    lista.Add(',');
                }
                this.txtBox.Text = this.listaString(lista);
            }
        }

        private string listaString(List<char> lista)
        {
            string str = "";
            foreach (char ch in lista)
            {
                str = str + ch.ToString();
            }
            return str;
        }

        private void EnableButtons()
        {
            Div.IsEnabled = true;
            Sub.IsEnabled = true;
            Multiply.IsEnabled = true;
            Add.IsEnabled = true;
            Result.IsEnabled = true;
            Znak.IsEnabled = true;
            Comma.IsEnabled = true;
        }
        private void DisableButtons()
        {
            Div.IsEnabled = false;
            Sub.IsEnabled = false;
            Multiply.IsEnabled = false;
            Add.IsEnabled = false;
            Result.IsEnabled = false;
            Znak.IsEnabled = false;
            Comma.IsEnabled = false;
        }

        private void Grid_KeyDown_1(object sender, KeyEventArgs e)
        {
            Key clickedKey = e.Key;
            switch (clickedKey)
            {
                case Key.D0:
                    Click(bt0, null);
                    break;
                case Key.D1:
                    Click(bt1, null);
                    break;
                case Key.D2:
                    Click(bt2, null);
                    break;
                case Key.D3:
                    Click(bt3, null);
                    break;
                case Key.D4:
                    Click(bt4, null);
                    break;
                case Key.D5:
                    Click(bt5, null);
                    break;
                case Key.D6:
                    Click(bt6, null);
                    break;
                case Key.D7:
                    Click(bt7, null);
                    break;
                case Key.D8:
                    Click(bt8, null);
                    break;
                case Key.D9:
                    Click(bt9, null);
                    break;

                case Key.LeftShift:
                    Znak_Click(null, null);
                    break;

                case Key.Multiply:
                    Multiply_Click(null, null);
                    break;
                case Key.X:
                    Multiply_Click(null, null);
                    break;

                case Key.Add:
                    Add_Click(null, null);
                    break;
                case Key.OemPlus:
                    Add_Click(null, null);
                    break;

                case Key.Subtract:
                    Sub_Click(null, null);
                    break;
                case Key.OemMinus:
                    Sub_Click(null, null);
                    break;

                case Key.Divide:
                    Div_Click(null, null);
                    break;
                case Key.OemQuestion:
                    Div_Click(null, null);
                    break;

                case Key.Back:
                    Back_Click(null, null);
                    break;

                case Key.Enter:
                    Result_Click(null, null);
                    break;

                case Key.Escape:
                    CE_Click(null, null);
                    break;

                case Key.C:
                    C_Click(null, null);
                    break;

                case Key.OemPeriod:
                    if (separator == ".")
                    {
                        Comma_Click(null, null);

                    }
                    break;

                case Key.OemComma:
                    if (separator == ",")
                    {
                        Comma_Click(null, null);

                    }
                    break;
            }
        }

        private void TheGrid_OnLoaded(object sender, RoutedEventArgs e)
        {
            theGrid.Focus();
        }


    }
}
