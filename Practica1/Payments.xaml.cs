using Practica1.PRACTICADataSetTableAdapters;
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

namespace Practica1
{
    public partial class Payments : Page
    {
        PaymentsTableAdapter payment = new PaymentsTableAdapter();
        public Payments()
        {
            InitializeComponent();
            PaymentsGrid.ItemsSource = payment.GetData();
        }

        private void DelPayment_Click(object sender, RoutedEventArgs e)
        {
            object id = (PaymentsGrid.SelectedItem as DataRowView).Row[0];
            payment.DeleteQuery(Convert.ToInt32(id));
            PaymentsGrid.ItemsSource = payment.GetData();
        }

        private void PaymentsGrid_CurrentCellChanged(object sender, EventArgs e)
        {
            payment.Update(PaymentsGrid.ItemsSource as PRACTICADataSet.PaymentsDataTable);
        }
    }
}
