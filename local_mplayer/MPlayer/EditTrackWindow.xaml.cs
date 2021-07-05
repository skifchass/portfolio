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

namespace MPlayer
{
    /// <summary>
    /// Логика взаимодействия для EditTrackWindow.xaml
    /// </summary>
    public partial class EditTrackWindow : Window
    {
        private MP3File mp3 = new MP3File();

        private ObservableCollection<Genres> genre = new ObservableCollection<Genres>();
        public EditTrackWindow(ref MP3File filemp3)
        {
            InitializeComponent();
            this.mp3 = filemp3;
            BoxGenre.ItemsSource = genre;
            for (byte i = (byte)Genres.Blues; i < (byte)Genres.None; i++)
            {
                genre.Add((Genres)i);
            }
            BoxGenre.SelectedIndex = 0;
            this.TextBoxAlbum.Text = this.mp3.Id3Album;
            this.TextBoxArtist.Text = this.mp3.Id3Artist;
            this.TextBoxComment.Text = this.mp3.Id3Commnet;
            this.TextBoxTitle.Text = this.mp3.Id3Title;
            this.TextBoxYear.Text = this.mp3.Id3Year;
            this.TextBoxNumberTrack.Text = this.mp3.Id3TrackNumber.ToString();
            this.BoxGenre.SelectedIndex = (int)this.mp3.Id3Genre;
        }
        public MP3File Mp3{

            get {

                return this.mp3;
            }
            set {

                this.mp3 = value;
            }
        }

        private void OnClickCancel(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void OnClickOK(object sender, RoutedEventArgs e) {

            Mp3.Id3Album = TextBoxAlbum.Text.Trim();
            Mp3.Id3Artist = TextBoxArtist.Text.Trim();
            Mp3.Id3Commnet = TextBoxComment.Text.Trim();
            Mp3.Id3Title = TextBoxTitle.Text.Trim();
            Mp3.Id3Year = TextBoxYear.Text.Trim();
            try
            {
                Mp3.Id3TrackNumber = Convert.ToByte(TextBoxNumberTrack.Text);
            }
            catch(Exception exp){

                MessageBox.Show(exp.Message, "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                TextBoxNumberTrack.Text = null;
                return;
            }
            try
            {
                Mp3.Id3Genre = (byte)BoxGenre.SelectedIndex;
            }
            catch(Exception exp){

                MessageBox.Show(exp.Message, "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                BoxGenre.SelectedIndex = 0;
                return;
            }

            if (Mp3.Id3Album.Length > 30)
                Mp3.Id3Album = Mp3.Id3Album.Substring(0, 30);
            if (Mp3.Id3Artist.Length > 30)
                Mp3.Id3Artist = Mp3.Id3Artist.Substring(0, 30);
            if (Mp3.Id3Commnet.Length > 28)
                Mp3.Id3Commnet = Mp3.Id3Commnet.Substring(0, 28);
            if (Mp3.Id3Title.Length > 30)
                Mp3.Id3Title = Mp3.Id3Title.Substring(0, 30);
            if (Mp3.Id3Year.Length > 4)
                Mp3.Id3Year = Mp3.Id3Year.Substring(0, 4);
            DialogResult = true;
        }

     
    }
}
