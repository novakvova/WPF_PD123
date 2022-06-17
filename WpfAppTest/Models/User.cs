using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppTest.Models
{
    public class User : INotifyPropertyChanged 
    {
        //Ідентифікатор
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        //Імя файлу, В нашалтуваннях шлях до файлу.
        public string Image { get; set; }
        //Зберігаємо у шифрованому виді
        public string Password { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
