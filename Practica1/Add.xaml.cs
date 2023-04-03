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
using System.Windows.Shapes;
using Practica1.PRACTICADataSetTableAdapters;

namespace Practica1
{
    public partial class Add : Window
    {
        OrdersTableAdapter order = new OrdersTableAdapter();
        ClientsTableAdapter client = new ClientsTableAdapter();
        PaymentsTableAdapter payments = new PaymentsTableAdapter();
        public Add()
        {
            InitializeComponent();
            id_client.ItemsSource = client.GetData();
            id_client.DisplayMemberPath = "ID";
            Orders_ID.ItemsSource = order.GetData();
            Orders_ID.DisplayMemberPath = "Product";
        }


        private void change_Click(object sender, RoutedEventArgs e)
        {
            if ((String.IsNullOrEmpty(client_id.Text)) && (String.IsNullOrEmpty(order_id.Text)) && (String.IsNullOrEmpty(payments_id.Text)))
            {
                MessageBox.Show(@" Ошибка: Вы не заполнили ни одну таблицу данными данные.");
            }
            else if ((String.IsNullOrEmpty(order_id.Text)) && (String.IsNullOrEmpty(payments_id.Text)))
            {
                client.InsertQuery(Convert.ToInt32(client_id.Text), client_name.Text, client_email.Text, client_phone.Text);
                MessageBox.Show(@" Вы заполнили таблицу Клиенты!");
            }
            else if ((String.IsNullOrEmpty(client_id.Text)) && (String.IsNullOrEmpty(payments_id.Text)))
            {
                order.InsertQuery((Convert.ToInt32(order_id.Text)), (int)(id_client.SelectedValue as DataRowView).Row[0], order_product.Text, Convert.ToInt32(order_quanity.Text), Convert.ToDecimal(order_price.Text));
                MessageBox.Show(@" Вы заполнили таблицу Заказы!");
            }
            else if ((String.IsNullOrEmpty(client_id.Text)) && (String.IsNullOrEmpty(order_id.Text)))
            {
                payments.InsertQuery((Convert.ToInt32(payments_id.Text)),(int)(Orders_ID.SelectedValue as DataRowView).Row[0], (Convert.ToDecimal(payments_amount.Text)), (Convert.ToString(Payment_method.Text)));
                MessageBox.Show(@" Вы заполнили таблицу Оплата!");
            }
            else if (String.IsNullOrEmpty(client_id.Text))
            {
                order.InsertQuery((Convert.ToInt32(order_id.Text)), (int)(id_client.SelectedValue as DataRowView).Row[0], order_product.Text, Convert.ToInt32(order_quanity.Text), Convert.ToDecimal(order_price.Text));
                payments.InsertQuery((Convert.ToInt32(payments_id.Text)), (int)(Orders_ID.SelectedValue as DataRowView).Row[0], (Convert.ToDecimal(payments_amount.Text)), (Convert.ToString(Payment_method.Text)));
                MessageBox.Show(@" Вы заполнили таблицы Заказы и Оплата.");
            }
            else if (String.IsNullOrEmpty(order_id.Text))
            {
                client.InsertQuery(Convert.ToInt32(client_id.Text), client_name.Text, client_email.Text, client_phone.Text);
                payments.InsertQuery((Convert.ToInt32(payments_id.Text)), (int)(Orders_ID.SelectedValue as DataRowView).Row[0], (Convert.ToDecimal(payments_amount.Text)), (Convert.ToString(Payment_method.Text)));
                MessageBox.Show(@" Вы заполнили таблицы Клиенты и Оплата.");
            }
            else if (String.IsNullOrEmpty(payments_id.Text))
            {
                client.InsertQuery(Convert.ToInt32(client_id.Text), client_name.Text, client_email.Text, client_phone.Text);
                order.InsertQuery((Convert.ToInt32(order_id.Text)), (int)(id_client.SelectedValue as DataRowView).Row[0], order_product.Text, Convert.ToInt32(order_quanity.Text), Convert.ToDecimal(order_price.Text));
                MessageBox.Show(@" Вы заполнили таблицы Клиенты и Заказы.");
            }
            else
            {
                client.InsertQuery(Convert.ToInt32(client_id.Text), client_name.Text, client_email.Text, client_phone.Text);
                order.InsertQuery((Convert.ToInt32(order_id.Text)), (int)(id_client.SelectedValue as DataRowView).Row[0], order_product.Text, Convert.ToInt32(order_quanity.Text), Convert.ToDecimal(order_price.Text));
                payments.InsertQuery((Convert.ToInt32(payments_id.Text)), (int)(Orders_ID.SelectedValue as DataRowView).Row[0], (Convert.ToDecimal(payments_amount.Text)), (Convert.ToString(Payment_method.Text)));
                MessageBox.Show(@" Вы заполнили все таблицы!");
            }
            MainWindow mw = new MainWindow();
            this.Visibility = Visibility.Hidden;
            mw.Show();
        }
    }
}
