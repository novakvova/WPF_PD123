using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppTest.Models
{
    public class User
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
    }
}
