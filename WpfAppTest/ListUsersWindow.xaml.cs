using Bogus;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
            var data = context.Users.ToList();
            var collection = new ObservableCollection<User>(data);
            dgUsers.ItemsSource = collection;
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
            MessageBox.Show("Complete " + context.Users.Count());
        }

        private void btnSearchUser_Click(object sender, RoutedEventArgs e)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            string firstName = "";//"Олександр";

            
            var query = context.Users.AsQueryable();
            if(!string.IsNullOrEmpty(firstName))
            {
                query = query.Where(x => x.Name.Contains(firstName));
            }

            //page =1;
            int page = 1;
            int pageSize = 10;
            int skip = (page - 1) * pageSize;
            int count = query.Count();
            int pages = (int)Math.Ceiling((double)count/(double)pageSize);
            MessageBox.Show("Pages "+ pages);
            query = query.Skip(skip).Take(10);


            var result = query.ToList();

            var collection = new ObservableCollection<User>(result);
            dgUsers.ItemsSource = collection;

            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            MessageBox.Show("Working " + elapsedTime);

        }
    }
}
