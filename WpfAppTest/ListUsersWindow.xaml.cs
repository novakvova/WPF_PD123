using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using WpfAppTest.Models;

namespace WpfAppTest
{
    /// <summary>
    /// Interaction logic for ListUsersWindow.xaml
    /// </summary>
    public partial class ListUsersWindow : Window
    {
        private ObservableCollection<UserVM> users = new ObservableCollection<UserVM>();

        public ListUsersWindow()
        {
            InitializeComponent();
            users.Add(new UserVM()
            {
                Id = 1,
                Name="Сашко",
                ImageUrl = "https://image.cnbcfm.com/api/v1/image/105992231-1561667465295gettyimages-521697453.jpeg?v=1561667497&w=1600&h=900"
            });
            users.Add(new UserVM()
            {
                Id = 2,
                Name = "Петро Васильович",
                ImageUrl = @"C:\mydata\Study\2022\26. WPF PD123\Lesson 1. Begin\WpfAppTest\WpfAppTest\bin\Debug\net5.0-windows\images\150_lkfaxb4p.4uf.jpg"
            });
            dgUsers.ItemsSource = users;
        }

        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            users.Add(new UserVM
            {
                Id=3,
                Name="No name",
                ImageUrl= "https://i.pinimg.com/originals/43/06/3c/43063c8162fbbae1cf37df742d2afa1c.jpg"
            });
        }

        private void btnChangeUser_Click(object sender, RoutedEventArgs e)
        {
            if (dgUsers.SelectedItem != null)
            {
                if (dgUsers.SelectedItem is UserVM)
                {
                    var userView = (dgUsers.SelectedItem as UserVM);
                    userView.Name = "Катюха";
                    userView.ImageUrl = "https://kasta.ua/image/1035/uploads/product_image/2020/07/157/3a47b1be23f77bc5ad1d76137250bcc5.jpeg";
                }
            }
        }
    }
}
