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
using System.Data.Sql;
using System.Collections;
using System.Data.SqlClient;
using System.Configuration;

namespace pro1
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
        


            

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "proj1.database.windows.net";
                builder.UserID = "quiz";
                builder.Password = "Ao09!556";
                builder.InitialCatalog = "app1";

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    Console.WriteLine("\nQuery data example:");
                    Console.WriteLine("=========================================\n");

                    StringBuilder sb = new StringBuilder();
                    //MessageBox.Show("Got here");
                    //sb.Append("INSERT INTO [dbo].[Table] (Id, Email, Name, Type, Date, Location, Description) ");
                    //sb.Append("VALUES ( " +"\'1\'," + "\'" +email_Box.Text + "\', \'" + name_Box.Text + "\', " + type.Text + "\', \'" + DateTime.Now.ToString() + "\' , \'" + Location.Text + "\', " + Descript.Text + "\');");

                    sb.Append("INSERT INTO proj (Name, Place, Date, Accident) ");
                    //sb.Append("VALUES ('user', 'School', "+ "'"+DateTime.Now.ToString()+"', 'crAsh'" );
                    sb.Append("VALUES ('user', 'School', 'i', 'crAsh' );");
                    //sb.Append("VALUES ('1', 'email', 'Sekol', 'crAsh', '" + DateTime.Now.ToString() + "', 'Ohio', 'Hit by a truck' );");

                    

                    String sql = sb.ToString();

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
                            }
                        }
                    }
                }
            }
            catch (SqlException b)
            {
                Console.WriteLine(b.ToString());
            }



            //MessageBox.Show(email_Box.Text);
            //MessageBox.Show(type.Text);
            //MessageBox.Show(DateTime.Now.ToString());
            //MessageBox.Show(Location.Text);
            //MessageBox.Show(Descript.Text);
        }
        }
    }





    

