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
using Practica1.PRACTICADataSetTableAdapters;

namespace Practica1
{
    
    public partial class Clients : Page
    {
        ClientsTableAdapter client = new ClientsTableAdapter();
        public Clients()
        {
            InitializeComponent();
            ClientsGrid.ItemsSource = client.GetData();
        }

        private void DelPayment_Click(object sender, RoutedEventArgs e)
        {
            object id = (ClientsGrid.SelectedItem as DataRowView).Row[0];
            client.DeleteQuery(Convert.ToInt32(id));
            ClientsGrid.ItemsSource = client.GetData();
        }

        private void ClientsGrid_CurrentCellChanged(object sender, EventArgs e)
        {
            client.Update(ClientsGrid.ItemsSource as PRACTICADataSet.ClientsDataTable);
        }
    }
}
