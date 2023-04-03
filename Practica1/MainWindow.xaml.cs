using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
using Practica1.PRACTICADataSetTableAdapters;

namespace Practica1
{
    public partial class MainWindow : Window
    {
        ClientsTableAdapter client = new ClientsTableAdapter();
        PaymentsTableAdapter payment = new PaymentsTableAdapter();
        OrdersTableAdapter order = new OrdersTableAdapter();
        public MainWindow()
        {
            InitializeComponent();
            clientdatagrid.ItemsSource = client.GetData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new Clients();
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new Orders();
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new Payments();
        }


        private void Button_Click_add(object sender, RoutedEventArgs e)
        {
            Add addbutton = new Add();
            this.Visibility = Visibility.Hidden;
            addbutton.Show();
        }

        private void Button_Click_change(object sender, RoutedEventArgs e)
        {

        }

        private void PageFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void clientdatagrid_CurrentCellChanged(object sender, EventArgs e)
        {
            client.Update(clientdatagrid.ItemsSource as PRACTICADataSet.ClientsDataTable);
        }
    }
}
