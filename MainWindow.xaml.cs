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
            Title.Text = Labyrinth.CurrentTitle();
            StoryField.Text = Labyrinth.CurrentText() +"\n"+ 
                Labyrinth.WarningText() +
            Labyrinth.CurrentImage();  //  MainImage= Labyrinth.CurrentImage();
            Uri img = new Uri(imgDir+ Labyrinth.CurrentImage(), UriKind.RelativeOrAbsolute);
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
                Title.Text = Labyrinth.CurrentTitle();
                StoryField.Text = Labyrinth.CurrentText();
                Uri img = new Uri(imgDir + Labyrinth.CurrentImage(), UriKind.RelativeOrAbsolute);
                MainImage.Source = BitmapFrame.Create(img);
            }
            else if (e.Key == Key.A)
            {
                Title.Text = Labyrinth.CurrentTitle();
                StoryField.Text = Labyrinth.CurrentText();
                Uri img = new Uri(imgDir + Labyrinth.CurrentImage(), UriKind.RelativeOrAbsolute);
                MainImage.Source = BitmapFrame.Create(img);
            }
            else if (e.Key == Key.S)
            {
                Title.Text = Labyrinth.CurrentTitle();
                StoryField.Text = Labyrinth.CurrentText();
                Uri img = new Uri(imgDir + Labyrinth.CurrentImage(), UriKind.RelativeOrAbsolute);
                MainImage.Source = BitmapFrame.Create(img);
            }
            else if (e.Key == Key.D)
            {
                Title.Text = Labyrinth.CurrentTitle();
                StoryField.Text = Labyrinth.CurrentText();
                Uri img = new Uri(imgDir + Labyrinth.CurrentImage(), UriKind.RelativeOrAbsolute);
                MainImage.Source = BitmapFrame.Create(img);
            }
            else if (e.Key == Key.F)
            {
                Title.Text = Labyrinth.CurrentTitle();
                StoryField.Text = Labyrinth.CurrentText();
                Uri img = new Uri(imgDir + Labyrinth.CurrentImage(), UriKind.RelativeOrAbsolute);
                MainImage.Source = BitmapFrame.Create(img);
            }
        }
    }
}
