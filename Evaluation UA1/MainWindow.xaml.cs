using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

/* 

 Prénom et Nom : Mamadou Aliou Diallo 
 Numero Etudiant : 2716260 
 Programme : Programmation Informatique
 Etape : 03

 */

namespace Evaluation_UA1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double lastNumber, result;
        SelectedOperator selectedOperator;
        public MainWindow()
        {
            InitializeComponent();
            resultLabel.Content = "";

            cBouton.Click += AcButton_Click;
            negativeBouton.Click += NegativeButton_Click;
            pourcentageButton.Click += PercentageButton_Click;
            egalBouton.Click += EgalBouton_Click;
        }

        // La méthode du bouton égal lorsqu'il est clické
        private void EgalBouton_Click(object sender, RoutedEventArgs e)
        {
            double newNumber;
            int size = resultLabel.Content.ToString().Length;
            resultLabel.Content = resultLabel.Content.ToString().Remove(0, size - 1);
            if (double.TryParse(resultLabel.Content.ToString(), out newNumber))
            {
                switch (selectedOperator)
                {
                    case SelectedOperator.Addition:
                        {
                            result = SimpleMath.Add(lastNumber, newNumber);
                            additBouton.Background = new SolidColorBrush(Colors.Orange);
                            additBouton.Foreground = new SolidColorBrush(Colors.White);
                            
                        }
                        
                        break;
                    case SelectedOperator.Subtaction:
                        {
                            result = SimpleMath.Sub(lastNumber, newNumber);
                            soustraBouton.Background = new SolidColorBrush(Colors.Orange);
                            soustraBouton.Foreground = new SolidColorBrush(Colors.White);
                        }
                        
                        break;
                    case SelectedOperator.Multiplication:
                        {
                            result = SimpleMath.Multiply(lastNumber, newNumber);
                            multipliBouton.Background = new SolidColorBrush(Colors.Orange);
                            multipliBouton.Foreground = new SolidColorBrush(Colors.White);
                        }
                        
                        break;
                    case SelectedOperator.Division:
                        {
                            result = SimpleMath.Divide(lastNumber, newNumber);
                            divisionBouton.Background = new SolidColorBrush(Colors.Orange);
                            divisionBouton.Foreground = new SolidColorBrush(Colors.White);
                        }
                        
                        break;
                }
                resultLabel.Content = result.ToString();
            }
        }

        // La méthode qui calcul le pourcentage lorsque le bouton poucentage est clické
        private void PercentageButton_Click(object sender, RoutedEventArgs e)
        {
            double tempNumber;
            if (double.TryParse(resultLabel.Content.ToString(), out tempNumber))
            {
                tempNumber = (tempNumber / 100);
                if (lastNumber != 0)
                    tempNumber *= lastNumber;
                resultLabel.Content = tempNumber.ToString();
            }
        }

        private void NegativeButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                lastNumber = lastNumber * (-1);
                resultLabel.Content = lastNumber.ToString();
            }
        }

        // la méthode qui permet de réinitialiser le label
        private void AcButton_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = "0";
            result = 0;
            lastNumber = 0; 
            additBouton.Background = new SolidColorBrush(Colors.Orange);
            additBouton.Foreground = new SolidColorBrush(Colors.White);

            soustraBouton.Background = new SolidColorBrush(Colors.Orange);
            soustraBouton.Foreground = new SolidColorBrush(Colors.White);

            multipliBouton.Background = new SolidColorBrush(Colors.Orange);
            multipliBouton.Foreground = new SolidColorBrush(Colors.White);

            divisionBouton.Background = new SolidColorBrush(Colors.Orange);
            divisionBouton.Foreground = new SolidColorBrush(Colors.White);
        }

        // la méthode qui gère les boutons oppérations lorqu'ils sont clickés
        private void OpBoutonClick(object sender, RoutedEventArgs e)
        {

            if (sender == additBouton)
            {
                selectedOperator = SelectedOperator.Addition;
                additBouton.Background = new SolidColorBrush(Colors.White);
                additBouton.Foreground = new SolidColorBrush(Colors.Orange);
                
            }
                
            if (sender == soustraBouton)
            {
                selectedOperator = SelectedOperator.Subtaction;
                soustraBouton.Background = new SolidColorBrush(Colors.White);
                soustraBouton.Foreground = new SolidColorBrush(Colors.Orange);
                
            }
                
            if (sender == multipliBouton)
            {
                selectedOperator = SelectedOperator.Multiplication;
                multipliBouton.Background = new SolidColorBrush(Colors.White);
                multipliBouton.Foreground = new SolidColorBrush(Colors.Orange);
            }
                
            if (sender == divisionBouton)
            {
                selectedOperator = SelectedOperator.Division;
                divisionBouton.Background = new SolidColorBrush(Colors.White);
                divisionBouton.Foreground = new SolidColorBrush(Colors.Orange);
            }
                
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                
                if (selectedOperator == SelectedOperator.Addition)
                {
                   
                    resultLabel.Content = $"{resultLabel.Content}";
                    resultLabel.Content = "";
                }
                    

                else if (selectedOperator == SelectedOperator.Subtaction)
                {
                    resultLabel.Content = $"{resultLabel.Content}";
                    resultLabel.Content = "";
                }
                    

                else if (selectedOperator == SelectedOperator.Multiplication)
                {
                    resultLabel.Content = $"{resultLabel.Content}";
                    resultLabel.Content = "";
                }
                    

                else
                {
                    resultLabel.Content = $"{resultLabel.Content}";
                    resultLabel.Content = "";
                }
                    
            }

            
        }

        private void PointBoutonClick(object sender, RoutedEventArgs e)
        {
            if (!resultLabel.Content.ToString().Contains(","))
                resultLabel.Content = $"{resultLabel.Content},";
        }

        // La méthode qui gère les nombres lorsque un bouton est clické
        private void NumBoutonClick(object sender, RoutedEventArgs e)
        {
            int selectedValue = 0;

            if (sender == bouton0)
                selectedValue = 0;
            if (sender == bouton1)
                selectedValue = 1;
            if (sender == bouton2)
                selectedValue = 2;
            if (sender == bouton3)
                selectedValue = 3;
            if (sender == bouton4)
                selectedValue = 4;
            if (sender == bouton5)
                selectedValue = 5;
            if (sender == bouton6)
                selectedValue = 6;
            if (sender == bouton7)
                selectedValue = 7;
            if (sender == bouton8)
                selectedValue = 8;
            if (sender == bouton9)
                selectedValue = 9;

            if (resultLabel.Content.ToString() == "0")
                resultLabel.Content = $"{selectedValue}";

            else
                resultLabel.Content = $"{resultLabel.Content}{selectedValue}";
        }
    }

    public enum SelectedOperator
    {
        Addition,
        Subtaction,
        Multiplication,
        Division
    }

    // La class où les oppération sont calculés
    public class SimpleMath
    {
        public static double Add(double n1, double n2)
        {
            return n1 + n2;
        }

        public static double Sub(double n1, double n2)
        {
            return n1 - n2;
        }

        public static double Multiply(double n1, double n2)
        {
            return n1 * n2;
        }

        public static double Divide(double n1, double n2)
        {
            if (n2 == 0)
            {
                
                 MessageBox.Show("Division par 0 n'est pas possible", "Erreur!!!", MessageBoxButton.OK, MessageBoxImage.Error);
                 return 0;
               
            }
            return n1 / n2;
        }

    }
}