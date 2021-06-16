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
using System.Windows.Shapes;
using System.Data.SqlClient;

namespace FirstProject
{
    /// <summary>
    /// Territories.xaml etkileşim mantığı
    /// </summary>
    public partial class Territories : Window
    {
        public Territories()
        {
            InitializeComponent();
        }

        private void LoadDataClicked(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=UTKUGOKCEN\SQLEXPRESS; Integrated Security = True;");
            try
            {
                if (sqlConnection.State == System.Data.ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }
                String query = "SELECT TerritoryID,TerritoryDescription,RegionID from Territories";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.ExecuteNonQuery();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
                System.Data.DataTable dt = new System.Data.DataTable("Categories");
                dataAdapter.Fill(dt);
                DataGrid2.ItemsSource = dt.DefaultView;
                dataAdapter.Update(dt);


                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }

        private void RemoveDataClicked(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=UTKUGOKCEN\SQLEXPRESS; Integrated Security = True;");
            try
            {
                if (sqlConnection.State == System.Data.ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }
                String query = "SELECT TerritoryID,TerritoryDescription,RegionID from Territories";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.ExecuteNonQuery();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
                System.Data.DataTable dt = new System.Data.DataTable("Categories");
                dataAdapter.Fill(dt);
                DataGrid2.ItemsSource = dt.DefaultView;
                dataAdapter.Update(dt);


                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }
    }
}
