using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
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
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        private string fileImage="";
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.ShowDialog();
            var uriSource = new Uri(openDialog.FileName);
            image.Source = new BitmapImage(uriSource);
            fileImage= openDialog.FileName;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            String dir = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "images");
            if(!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            string fileSaveName = System.IO.Path.GetRandomFileName() + ".jpg";
            

            Bitmap bmp = new Bitmap(fileImage);
            for (int i = 1; i < 6; i++)
            {
                var bmpSave = ImageWorker.CompressImage(bmp, i*50, i*50);
                string imageSave = System.IO.Path.Combine(dir, $"{i*50}_"+fileSaveName);
                bmpSave.Save(imageSave, ImageFormat.Jpeg);
            }
            
            //File.Copy(fileImage, imageSave);
        }
    }
}
