using System;
using System.Data.SqlClient;
using System.Windows;

namespace FirstProject
{
    /// <summary>
    /// Categories.xaml etkileşim mantığı
    /// </summary>
    public partial class Categories : Window
    {
        public Categories()
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
                String query = "SELECT CategoryName,Description from Categories";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.ExecuteNonQuery();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
                System.Data.DataTable dt = new System.Data.DataTable("Categories");
                dataAdapter.Fill(dt);
                DataGrid1.ItemsSource = dt.DefaultView;
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

        private void AddDataClicked(object sender, RoutedEventArgs e)
        {
            GetInfo infoWindow = new GetInfo();
            infoWindow.Show();
            this.Close();
        }
        private void RemoveDataClicked(object sender, RoutedEventArgs e)
        {
            RemoveCategory removeWindow = new RemoveCategory();
            removeWindow.Show();
            this.Close();

        }


    }
}
