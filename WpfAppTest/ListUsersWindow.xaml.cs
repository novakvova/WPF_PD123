using Bogus;
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
        private MyDataContext context;
        public ListUsersWindow()
        {
            InitializeComponent();
            context = new MyDataContext();
            //users.Add(new UserVM()
            //{
            //    Id = 1,
            //    Name="Сашко",
            //    ImageUrl = "https://image.cnbcfm.com/api/v1/image/105992231-1561667465295gettyimages-521697453.jpeg?v=1561667497&w=1600&h=900"
            //});
            //users.Add(new UserVM()
            //{
            //    Id = 2,
            //    Name = "Петро Васильович",
            //    ImageUrl = @"C:\mydata\Study\2022\26. WPF PD123\Lesson 1. Begin\WpfAppTest\WpfAppTest\bin\Debug\net5.0-windows\images\150_lkfaxb4p.4uf.jpg"
            //});
            var data = context.Users.Select(x => new UserVM
            {
                Id = x.Id,
                Name = x.Name,
                ImageUrl=x.Image
            }).ToList();
            users = new ObservableCollection<UserVM>(data);
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
                    //userView.Id
                    userView.Name = "Катюха";
                    userView.ImageUrl = "https://kasta.ua/image/1035/uploads/product_image/2020/07/157/3a47b1be23f77bc5ad1d76137250bcc5.jpeg";
                }
            }
        }

        private void btnRandomUser_Click(object sender, RoutedEventArgs e)
        {
            //uk-ua
            var faker = new Faker<User>("uk")
                .RuleFor(u => u.Name, 
                    (f, u) => f.Name.FullName())
                .RuleFor(u=>u.Phone, f=>f.Phone.PhoneNumber())
                .RuleFor(u=>u.Email, f=>f.Internet.Email())
                .RuleFor(u=>u.Password, f=>f.Internet.Password())
                .RuleFor(u=>u.Image, f=>f.Image.PicsumUrl());

            MyDataContext context = new MyDataContext();
            for (int i = 0; i < 1000; i++)
            {
                var user = faker.Generate();
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        private void btnSearchUser_Click(object sender, RoutedEventArgs e)
        {
            string firstName= "Олександр";

            MyDataContext context = new MyDataContext();
            var query = context.Users.AsQueryable();
            if(!string.IsNullOrEmpty(firstName))
            {
                query = query.Where(x => x.Name.Contains(firstName));
            }

            var result = query.ToList();
        }
    }
}
