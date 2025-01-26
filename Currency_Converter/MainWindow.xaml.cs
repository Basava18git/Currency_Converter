using System;
using System.Collections.Generic;
using System.Data;
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

namespace Currency_Converter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            BindArray();
            Input_currency.Focus();
        }

        #region events
        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void ComboBox_From_CRCY(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void Convert_Click(object sender, RoutedEventArgs e)
        {
            double converted_value;

            if (Input_currency.Text == "" || Input_currency.Text == null)
            {
                MessageBox.Show("please enter the some amount in amount tab", "No Amount Entered", MessageBoxButton.OK, MessageBoxImage.Information);

                Input_currency.Focus();
            }
            else if (Cmb_currency_from.SelectedValue == null || Cmb_currency_from.SelectedIndex == 0)
            {
                MessageBox.Show("Please select currency you want to convert from", "Currencyfrom", MessageBoxButton.OK, MessageBoxImage.Information);
                Cmb_currency_from.Focus();
            }

            else if (Cmb_currency_to.SelectedValue == null || Cmb_currency_to.SelectedIndex == 0)
            {
                MessageBox.Show("Please select currency you want to convert to", "Currencyfrom", MessageBoxButton.OK, MessageBoxImage.Information);
                Cmb_currency_to.Focus();
            }
            else if (Cmb_currency_from.SelectedIndex == Cmb_currency_to.SelectedIndex)
            {
                converted_value = double.Parse(Input_currency.Text);
                Converted_amt.Content = $"{Cmb_currency_from.Text} {converted_value.ToString("N3")}";

            }
            else
            {
                converted_value = ((double.Parse(Cmb_currency_from.SelectedValue.ToString())) *
                    double.Parse(Input_currency.Text)) /
                    double.Parse(Cmb_currency_to.SelectedValue.ToString());

                Converted_amt.Content = Cmb_currency_to.Text + " " +converted_value;
            }
        }

        private void Clear_click(object sender, RoutedEventArgs e)
        {
            Converted_amt.Content = "";
            Input_currency.Clear();
            Cmb_currency_from.SelectedIndex = 0;
            Cmb_currency_to.SelectedIndex = 0;
            Input_currency.Focus();
            
        }

        private void ComboBox_To_CRCY(object sender, SelectionChangedEventArgs e)
        {

        }

        #endregion


        #region methods

        private void BindArray()
        {
            DataTable dtcurrency = new DataTable();
            dtcurrency.Columns.Add("Text");
            dtcurrency.Columns.Add("Value");

            dtcurrency.Rows.Add("--SELECT--", 0);
            dtcurrency.Rows.Add("INR", 1);
            dtcurrency.Rows.Add("USD", 85);
            dtcurrency.Rows.Add("EUR", 90);
            dtcurrency.Rows.Add("PND", 106);

            Cmb_currency_from.ItemsSource = dtcurrency.DefaultView;
            Cmb_currency_from.DisplayMemberPath = "Text";
            Cmb_currency_from.SelectedValuePath = "Value";
            Cmb_currency_from.SelectedIndex = 0;

            Cmb_currency_to.ItemsSource = dtcurrency.DefaultView;
            Cmb_currency_to.DisplayMemberPath = "Text";
            Cmb_currency_to.SelectedValuePath = "Value";
            Cmb_currency_to.SelectedIndex = 0;

        }

        #endregion
    }
}
