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
using System.Data.SqlClient;
using System.Data;

namespace Alligator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
          
        }
        public static SqlConnection GetConnection(string param = "Data Source=.;Initial Catalog=AggregatorAlligator;Integrated Security=True;")
        {
            SqlConnection connection = new SqlConnection(param);
            return connection;
        }

        public static void InsertClient(int id, string fName, string sName, string tName, string phoneNumber, string email)
        {
            SqlConnection connection = GetConnection();
            connection.Open();
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            string sql = "";

            sql = $"insert into [dbo].[Client] (Id, FirstName, LastName, Patronymic, PhoneNumber, Email) values ({id},'{fName}','{sName}', '{tName}','{phoneNumber}','{email}')";
            command = new SqlCommand(sql, connection);

            adapter.InsertCommand = command;
            adapter.InsertCommand.ExecuteNonQuery();

            command.Dispose();
            connection.Close();
        }
        public static void SelectClient()
        {
            SqlConnection connection = GetConnection();
            connection.Open();
            SqlCommand command;
            SqlDataReader dataReader;
            string sql, output = "";
            sql = "Select Id,FirstName,LastName,Patronymic,honeNumber,Email from Client";
            command = new SqlCommand(sql, connection);
            dataReader = command.ExecuteReader();
            while(dataReader.Read())
            {

            }
        }
       
    }
}
