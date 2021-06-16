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
    /// RemoveCategory.xaml etkileşim mantığı
    /// </summary>
    public partial class RemoveCategory : Window
    {
        public RemoveCategory()
        {
            InitializeComponent();
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
                String query = "delete from Categories where CategoryName='" + txtCategoryName.Text+"'";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.ExecuteNonQuery();
                //SqlCommand sqlCommand = new SqlCommand();
                //sqlCommand.CommandType = System.Data.CommandType.Text;
                // sqlCommand.Parameters.AddWithValue("@CategoryName", CategoryName.Text);
                // sqlCommand.Parameters.AddWithValue("@Description", Description.Text);



                sqlConnection.Close();

                Categories back = new Categories();
                back.Show();
                this.Close();
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
