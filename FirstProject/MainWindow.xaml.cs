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

namespace FirstProject
{
	/// <summary>
	/// MainWindow.xaml etkileşim mantığı
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void loginButtonClicked(object sender, RoutedEventArgs e)
        {
			SqlConnection sqlConnection = new SqlConnection(@"Data Source=UTKUGOKCEN\SQLEXPRESS; Integrated Security = True;");
            try
            {
				if(sqlConnection.State == System.Data.ConnectionState.Closed)
                {
					sqlConnection.Open();
                }
				String query = "SELECT COUNT(1) from Users WHERE Username=@username AND Password=@password";
				SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
				sqlCommand.CommandType = System.Data.CommandType.Text;
				sqlCommand.Parameters.AddWithValue("@Username",txtUsername.Text);
				sqlCommand.Parameters.AddWithValue("@Password", txtPassword.Password);
				int count = Convert.ToInt32(sqlCommand.ExecuteScalar());
				if (count == 1)
                {
					Window1 win = new Window1();
					win.Show();
					this.Close();
				}
                else
                {
					MessageBox.Show("Username or password is incorrect");
                }
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
