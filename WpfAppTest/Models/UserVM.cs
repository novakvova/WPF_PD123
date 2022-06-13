using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WpfAppTest.Models
{
    public class UserVM : INotifyPropertyChanged
    {
        public int Id { get; set; }
        //propfull
        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                if (this.name != value)
                {
                    name = value;
                    NotifyPropertyChanged("Name");
                }
            }
        }

        private string image;


        public string ImageUrl
        {
            get {
                return image;
            }
            set {
                if (this.image != value)
                {
                    image = value;
                    NotifyPropertyChanged("ImageUrl");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            //if (this.PropertyChanged != null)
            //    this.PropertyChanged(this, new PropertyChangedEventArgs(propName));

            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }


    }
}
