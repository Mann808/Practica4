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
    public partial class Orders : Page
    {
        OrdersTableAdapter order = new OrdersTableAdapter();
        public Orders()
        {
            InitializeComponent();
            OrdersGrid.ItemsSource = order.GetData();
        }

        private void DelPayment_Click(object sender, RoutedEventArgs e)
        {
            object id = (OrdersGrid.SelectedItem as DataRowView).Row[0];
            order.DeleteQuery(Convert.ToInt32(id));
            OrdersGrid.ItemsSource = order.GetData();
        }

        private void OrdersGrid_CurrentCellChanged(object sender, EventArgs e)
        {
            order.Update(OrdersGrid.ItemsSource as PRACTICADataSet.OrdersDataTable);
        }
    }
}
