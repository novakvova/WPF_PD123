using Microsoft.Win32;
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

namespace WpfAppTest
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        MyDataContext data = new MyDataContext();
        public LoginWindow()
        {
            //var users = data.Users.ToList();
            //data.Users.Add(new User
            //{
            //    Name="Іван"
            //});
            //data.SaveChanges();
            //var count = data.Users.Count();
            OpenFileDialog openFileDialog = new OpenFileDialog();

            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var text = txtEmail.Text;
            MessageBox.Show("Email: "+ text);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AuthUser.UserEmail = "Сало";
            //var user = MyDataContext.
            RegisterWindow register = new RegisterWindow();
            register.ShowDialog();
        }

        private void btnShowData_Click(object sender, RoutedEventArgs e)
        {
            ListUsersWindow register = new ListUsersWindow();
            register.ShowDialog();
        }
    }
}
