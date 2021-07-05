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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Microsoft.Win32;
using WMPLib;
using System.IO;
namespace MPlayer
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<MP3File> m_listmp3 = new ObservableCollection<MP3File>();
        private ObservableCollection<MP3File> m_boxmp3 = new ObservableCollection<MP3File>();
        private ObservableCollection<MP3File> m_mp3file = new ObservableCollection<MP3File>();
        private string filename = String.Empty;
        private string name = String.Empty;
        WindowsMediaPlayer Player = new WindowsMediaPlayer();
        private DispatcherTimer timer = new DispatcherTimer();
        private int minute = 0;
        private int second = 0;
        private double time = 0;
        private Boolean Stopped = false;
        private Boolean Paused = false;
        private Double Position = 0;
        private Boolean flag = true;
        public MainWindow()
        {
            InitializeComponent();
            m_listBox.ItemsSource = m_boxmp3;
            m_listView.ItemsSource = m_listmp3;
            try
            {
               ObservableCollection<MP3File> mp3col = MP3File.DeserializeObject();

               for (int i = 0; i < mp3col.Count; i++)
               {
                   m_listmp3.Add(mp3col[i]);
                   m_boxmp3.Add(mp3col[i]);
                }
            }
            catch
            {

            }
            m_listmp.ItemsSource = m_mp3file;
            Player.PlayStateChange += OnStateChanged;
            timer.Interval = new TimeSpan(10000000);
            timer.Tick += OnTick;
            m_Volume.Maximum = 50;
            m_Volume.Minimum = 0;
            m_Volume.Value = 25;
            Player.settings.volume = (int)m_Volume.Value;
      }
        private void OnStateChanged(Int32 state) {

           
           
            if (state == 1) 
            {
                if (Stopped)
                {
                    timer.Stop();
                  
                    m_TextBlock.Text = "";
                    m_Slider.Value = 0;
                  
                }
                else if (state == 1 && !Stopped) {
                    if (flag)
                    {
                        timer.Stop();
                        
                        var currentindex = m_listBox.SelectedIndex + 1;

                        if (currentindex >= m_listBox.Items.Count)
                        {

                            currentindex = 0;
                        }

                        m_listBox.SelectedIndex = currentindex;
                        Player.URL = (this.m_listBox.Items[currentindex] as MP3File).Path;
                        AddToListMP3();
                        time = Math.Round((this.m_listBox.Items[currentindex] as MP3File).Duration);
                        m_Slider.Maximum = time;
                        m_Slider.Minimum = 0;
                        m_Slider.Value = 0;
                        
                        timer.Interval = new TimeSpan(10000000);
                       
                        timer.Start();
                        flag = false;
                    }
                }
            }
            else if (state == 2) {

                timer.Stop();
            }
          
        }
        private void OnTick(object sender, EventArgs e) {

            m_Slider.Value++;
            double dif = m_Slider.Maximum - m_Slider.Value;
            int m = GetMinutes(dif);
            int s = GetSeconds(dif, m);
            m_TextBlock.Text = String.Format("{0}:{1}", m, s);
           
            if (!flag)
            {
                flag = !flag;
                Player.controls.play();
            }
        }
        private void OnClickBrowsButton(object sender, RoutedEventArgs e)
        {
            OpenFileDialog m_openfiledlg = new OpenFileDialog();
            m_openfiledlg.Filter = "File (*.mp3)|*.mp3";
            
            if(m_openfiledlg.ShowDialog() == true){
                bool flag = true;
                this.filename = m_openfiledlg.FileName;
                this.name = System.IO.Path.GetFileNameWithoutExtension(this.filename);
                for (int i = 0; i < m_listmp3.Count; i++)
                {
                    if (m_listmp3[i].Path == this.filename)
                        flag = false;
                }
                if (flag)
                {
                    m_listmp3.Add(TrackCreate(this.filename, this.name));
                    m_boxmp3.Add(TrackCreate(this.filename, this.name));
                   
                }
                else
                    MessageBox.Show("Такая запись есть уже!", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            
        }

        private MP3File TrackCreate(string filename, string name)
        {
            MP3File file = new MP3File();
            ReadMP3File(ref file, filename);
            file.Path = filename;
            file.Name = name;
            file.MPtime = Player.newMedia(this.filename).durationString;
            file.Duration = Player.newMedia(this.filename).duration;
            GetMinutes(file.Duration);
            return file;
        }

        private void ReadMP3File(ref MP3File file, string filename) { 
           
            byte[] buffer = new byte[128];

            using(FileStream fstream = new FileStream(filename, FileMode.Open, FileAccess.Read)){
                 
                 fstream.Seek(-128 , SeekOrigin.End);
                 fstream.Read(buffer, 0, 128);
            }

            String id3Tag = Encoding.GetEncoding(1251).GetString(buffer);

            if (id3Tag.Substring(0, 3) == "TAG")
            {

                file.Id3Album = id3Tag.Substring(63, 30).Trim();
                file.Id3Artist = id3Tag.Substring(33, 30).Trim();
                file.Id3Commnet = id3Tag.Substring(97, 28).Trim();
                file.Id3Title = id3Tag.Substring(3, 30).Trim();
                file.Id3Year = id3Tag.Substring(93, 4).Trim();

                if (id3Tag[125] == 0)
                {

                    file.Id3TrackNumber = buffer[126];
                }
                else
                {

                    file.Id3TrackNumber = 0;
                }
                file.Id3Genre = buffer[127];
                file.Genre = (Genres)file.Id3Genre;
                file.HasID3Tag = true;
            }
          
        }

        private void OnClickButtonPlay(object sender, RoutedEventArgs e)
        {
            if (this.m_listBox.SelectedItems.Count != 0)
            {
                if (!Paused)
                {
                    Player.URL = (this.m_listBox.Items[this.m_listBox.SelectedIndex] as MP3File).Path;
                    time = Math.Round((this.m_listBox.Items[this.m_listBox.SelectedIndex] as MP3File).Duration);
                    AddToListMP3();
                    m_Slider.Maximum = time;
                    m_Slider.Minimum = 0;
                    m_Slider.Value = 0;
                    Player.controls.play();
                    
                    timer.Start();
                }
                else
                    OnClickPause(this, new RoutedEventArgs());
              
                  if (Stopped)
                      Stopped = false;

                  
            }
            else
                MessageBox.Show("Выберите трек для проигрывания!", "Выбор трека", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void OnClickSelect(object sender, RoutedEventArgs e)
        {
            if (this.m_listView.SelectedItems.Count != 0)
            {
                if (this.m_listView.SelectedItems.Count == 1) {
                    if (m_boxmp3.Count != m_listmp3.Count)
                    {
                        if (m_boxmp3.Count > 0)
                            m_boxmp3.Clear();
                        for (int i = 0; i < m_listmp3.Count; i++)
                        {
                            m_boxmp3.Add(m_listmp3[i]);
                        }
                    }
                    this.m_listBox.SelectedIndex = this.m_listView.SelectedIndex;
                }
                else if (this.m_listView.SelectedItems.Count > 1) {

                    if (m_boxmp3.Count > 0)
                        m_boxmp3.Clear();

                    for (int i = 0; i < this.m_listView.SelectedItems.Count; i++)
                    {
                        m_boxmp3.Add(this.m_listView.SelectedItems[i] as MP3File);
                    }
                    
                    if(this.m_listBox.Items.Count != 0){
                        this.m_listBox.SelectedIndex = 0;
                    }
                    
                    Player.URL = m_boxmp3[this.m_listBox.SelectedIndex].Path;
                    timer.Stop();
                    time = Math.Round((this.m_listBox.Items[this.m_listBox.SelectedIndex] as MP3File).Duration);
                    AddToListMP3();
                    m_Slider.Maximum = time;
                    m_Slider.Minimum = 0;
                    m_Slider.Value = 0;
                    timer.Start();
                }
            }
            else {

                MessageBox.Show("Выберите треки", "Ошибка выбора", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
        }

        private int GetMinutes(double time) 
        {
           return minute = (int)(time / 60); 
        }
        private int GetSeconds(double time, int minute)
        {   
            return second = (int)(time - minute * 60);
        }

        private void OnClickStop(object sender, RoutedEventArgs e)
        {
            Paused = false;
            Stopped = true;
            m_mp3file.Clear();
            Player.controls.stop();
        }

        private void OnClickPause(object sender, RoutedEventArgs e)
        {
            if (!Paused)
            {
                Player.controls.pause();
                Position = Player.controls.currentPosition;
                if(Position != 0)
                Paused = !Paused;
            }
            else {

                Player.controls.currentPosition = Position;

                if (Player.controls.currentPosition != 0)
                {
                    Player.controls.play();
                    timer.Start();
                    Paused = !Paused;
                }
            }
          
        }

        private void OnClickPrev(object sender, RoutedEventArgs e)
        {
            Stopped = true;
            Player.controls.stop();
            Stopped = false;

            var previndex = m_listBox.SelectedIndex - 1;
            if (previndex < 0) {

                previndex = m_listBox.Items.Count - 1;
            }

            m_listBox.SelectedIndex = previndex;
            Player.URL = (m_listBox.Items[previndex] as MP3File).Path;
            AddToListMP3();
            time = (m_listBox.Items[previndex] as MP3File).Duration;
            m_Slider.Maximum = time;
            m_Slider.Minimum = 0;
            m_Slider.Value = 0;
            Player.controls.play();
            timer.Start();
        }

        private void OnClickNext(object sender, RoutedEventArgs e)
        {
            Stopped = true;
            Player.controls.stop();
            Stopped = false;

            var nextrack = m_listBox.SelectedIndex + 1;
            if (nextrack >= m_listBox.Items.Count) {

                nextrack = 0;
            }

            m_listBox.SelectedIndex = nextrack;
            Player.URL = (m_listBox.Items[nextrack] as MP3File).Path;
            AddToListMP3();
            time = (m_listBox.Items[nextrack] as MP3File).Duration;
            m_Slider.Maximum = time;
            m_Slider.Minimum = 0;
            m_Slider.Value = 0;
            Player.controls.play();
            timer.Start();
            

        }

        private void OnValueChange(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Player.settings.volume = (int)m_Volume.Value;
        }
        private void AddToListMP3() {

            if (m_mp3file.Count != 0)
                m_mp3file.Clear();
            m_mp3file.Add(m_boxmp3[this.m_listBox.SelectedIndex]);
        }

        private void m_Slider_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var item = e.GetPosition(m_Slider);
            double result = m_Slider.Maximum * item.X / 183;
            m_Slider.Value = result;
            Player.controls.currentPosition = m_Slider.Value;
        }

        private void Window_Closing_1(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MP3File.SerializeObject(m_listmp3);
        }
        private void OnClickEdit(object sender, RoutedEventArgs e) {
            var file = new MP3File();
            if (this.m_listView.SelectedItems.Count != 0)
            {
                file = this.m_listmp3[this.m_listView.SelectedIndex];
                EditTrackWindow editrck = new EditTrackWindow(ref file);
                if (editrck.ShowDialog() == true)
                {
                    WriteId3Tag(editrck.Mp3);
                }
            }
            else {

                MessageBox.Show("Выберите элемент из списка!", "Редактирование Id3тега", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void WriteId3Tag(MP3File file) {

            byte[] arrbid3 = new byte[128];
            for (int i = 0; i < arrbid3.Length; i++)
            {
                arrbid3[i] = 0;
            }
            var buffer = Encoding.GetEncoding(1251).GetBytes("TAG");
            Array.Copy(buffer, 0, arrbid3, 0, buffer.Length);
            buffer = Encoding.GetEncoding(1251).GetBytes(file.Id3Title);
            Array.Copy(buffer, 0, arrbid3, 3, buffer.Length);
            buffer = Encoding.GetEncoding(1251).GetBytes(file.Id3Artist);
            Array.Copy(buffer, 0, arrbid3, 33, buffer.Length);
            buffer = Encoding.GetEncoding(1251).GetBytes(file.Id3Album);
            Array.Copy(buffer, 0, arrbid3, 63, buffer.Length);
            buffer = Encoding.GetEncoding(1251).GetBytes(file.Id3Year);
            Array.Copy(buffer, 0, arrbid3, 93, buffer.Length);
            buffer = Encoding.GetEncoding(1251).GetBytes(file.Id3Commnet);
            Array.Copy(buffer, 0, arrbid3, 97, buffer.Length);

            arrbid3[126] = file.Id3TrackNumber;
            arrbid3[127] = file.Id3Genre;

            using(FileStream fstream = new FileStream(file.Path, FileMode.Open, FileAccess.Write)){

                fstream.Seek(-128, SeekOrigin.End);
                fstream.Write(arrbid3, 0, 128);
            }
            file.HasID3Tag = true;
        }
        private void OnClickDelete(object sender, RoutedEventArgs e) {
            var index = 0;
            if (this.m_listView.SelectedItems.Count != 0)
                for (int i = 0; i < this.m_listView.SelectedItems.Count;)
                {
                    index = this.m_listView.SelectedIndex;
                    m_listmp3.RemoveAt(i);
                }
        }
        private void OnClickExit(object sender, RoutedEventArgs e) {

            Close();
        }

       }

 
}
