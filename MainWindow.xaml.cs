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

namespace DTP9_MUD_WPF_stub
{
    public partial class MainWindow : Window
    {
        string imgDir = "..\\..\\..\\images\\";
        public MainWindow()
        {
            InitializeComponent();
            // Gör all initiering nedanför den här texten!
            Title.Text = "Slottet";
            StoryField.Text = "Du hittar ett gammalt slott. \nNyfikenheten tar över.\nDu går in.";
            Uri img = new Uri(imgDir+"slott.jpg", UriKind.RelativeOrAbsolute);
            MainImage.Source = BitmapFrame.Create(img);
        }
        private void ApplicationKeyPress(object sender, KeyEventArgs e)
        {
            string output = "Key pressed: ";
            output += e.Key.ToString();
            KeyPressDisplay.Text = output;
            if (e.Key == Key.Escape)
            {
                System.Windows.Application.Current.Shutdown();
            }
            else if (e.Key == Key.W)
            {
                Title.Text = "AAAAAAAAAH!";
                StoryField.Text = "Namen aaaaah!\nÅååååh!\nÄäääää!";
                Uri img = new Uri(imgDir + "illusion2.png", UriKind.RelativeOrAbsolute);
                MainImage.Source = BitmapFrame.Create(img);
            }
            else if (e.Key == Key.A)
            {
                Title.Text = "IIIIIIIIIH!";
                StoryField.Text = "Jasäjabah iiiiiiiih!";
                Uri img = new Uri(imgDir + "winterbath.png", UriKind.RelativeOrAbsolute);
                MainImage.Source = BitmapFrame.Create(img);
            }
            else if (e.Key == Key.S)
            {
                Title.Text = "IIIIIIIIIH!";
                StoryField.Text = "Jasäjabah iiiiiiiih!";
                Uri img = new Uri(imgDir + "winterbath.png", UriKind.RelativeOrAbsolute);
                MainImage.Source = BitmapFrame.Create(img);
            }
            else if (e.Key == Key.D)
            {
                Title.Text = "IIIIIIIIIH!";
                StoryField.Text = "Jasäjabah iiiiiiiih!";
                Uri img = new Uri(imgDir + "winterbath.png", UriKind.RelativeOrAbsolute);
                MainImage.Source = BitmapFrame.Create(img);
            }
            else if (e.Key == Key.F)
            {
                Title.Text = "IIIIIIIIIH!";
                StoryField.Text = "Jasäjabah iiiiiiiih!";
                Uri img = new Uri(imgDir + "winterbath.png", UriKind.RelativeOrAbsolute);
                MainImage.Source = BitmapFrame.Create(img);
            }
        }
    }
}
