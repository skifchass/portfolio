using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Windows;
using WMPLib;

namespace MPlayer
{
    public enum Genres : byte
    {
        Blues,
        ClassicRock,
        Country,
        Dance,
        Disco,
        Funk,
        Grunge,
        HipHop,
        Jazz,
        Metal,
        NewAge,
        Oldies,
        Other,
        Pop,
        RnB,
        Rap,
        Reggae,
        Rock,
        Techno,
        Industrial,
        Alternative,
        Ska,
        DeathMetal,
        Pranks,
        Soundtrack,
        EuroTechno,
        Ambient,
        TripHop,
        Vocal,
        JazzFunk,
        Fusion,
        Trance,
        Classical,
        Instrumental,
        Acid,
        House,
        Game,
        SoundClip,
        Gospel,
        Noise,
        AlternRock,
        Bass,
        Soul,
        Punk,
        Space,
        Mediative,
        InstrumentalPop,
        InstrumentalRock,
        Ethnic,
        Gothic,
        Darkwave,
        TechnoIndustrial,
        Electronic,
        PopFolk,
        Eurodance,
        Dream,
        SouthernRock,
        Comedy,
        Cult,
        Gangsta,
        Top40,
        ChristianRap,
        PopFunk,
        Jungle,
        NativeAmerican,
        Cabaret,
        NewWave,
        Psychadelic,
        Rave,
        Showtunes,
        Trailer,
        LoFi,
        Tribal,
        AcidPunk,
        AcidJazz,
        Polka,
        Retro,
        Musical,
        RocknRoll,
        HardRock,
        None = 255
    };
    [Serializable]
    public class MP3File
    {
        private String name;
        private String path;
        private Boolean hasID3Tag;
        private String id3Album;
        private String id3Artist;
        private String id3Comment;
        private Byte id3Genre;
        private Genres genre;
        private String id3Title;
        private Byte id3TrackNumber;
        private String id3Year;
        private String mptime;
        private Double duration;

        public MP3File() {

            this.hasID3Tag = false;
            this.id3Album = String.Empty;
            this.name = String.Empty;
            this.path = String.Empty;
            this.id3Comment = String.Empty;
            this.id3Title = String.Empty;
            this.id3Year = String.Empty;
            this.id3Artist = String.Empty;
            this.id3Genre = 0;
            this.id3TrackNumber = 0;
            this.mptime = String.Empty;
            this.duration = 0;
            this.genre = Genres.None;
        }
        public static void SerializeObject(ObservableCollection<MP3File> mp3col) {

            BinaryFormatter binary = new BinaryFormatter();
            using(FileStream fstream = new FileStream("listmp3.dat", FileMode.OpenOrCreate, FileAccess.Write)){

                binary.Serialize(fstream, mp3col);
            }
        }
        public static ObservableCollection<MP3File> DeserializeObject() {
            
            BinaryFormatter binary = new BinaryFormatter();
            ObservableCollection<MP3File> mp3col = new ObservableCollection<MP3File>();
                using (FileStream fstream = new FileStream("listmp3.dat", FileMode.Open, FileAccess.Read))
                {

                    mp3col = (ObservableCollection<MP3File>)binary.Deserialize(fstream);
                }
                return mp3col;
         }
      
        public Genres Genre {

            get {

                return this.genre;
            }
            set {

                this.genre = value;
            }
        }
        public Double Duration {

            get {

                return this.duration;
            }
            set {

                this.duration = value;
            }
        }
        public String MPtime { 
        
            get{

                return this.mptime;
              }
            set {

                this.mptime = value;
            }
        }
        public Boolean HasID3Tag {

            get {

                return this.hasID3Tag;
            }
            set {

                this.hasID3Tag = value;
            }
        }
        public String Id3Album {

            get {

                return this.id3Album;
            }
            set {

                this.id3Album = value;
            }
        }
        public String Name {

            get {

                return this.name;
            }
            set {

                this.name = value;
            }
        }
        public String Path {

            get {

                return this.path;
            }
            set {

                this.path = value;
            }
        }
        public String Id3Commnet {

            get {

                return this.id3Comment;
            }
            set {

                this.id3Comment = value;
            }
        }
        public String Id3Title {

            get {

                return this.id3Title;
            }
            set {

                this.id3Title = value;
            }

        }
        public String Id3Artist {

            get {

                return this.id3Artist;
            }
            set {

                this.id3Artist = value;
            }
        }
        public String Id3Year {

            get {

                return this.id3Year;
            }
            set {

                this.id3Year = value;
            }
        }
        public Byte Id3Genre {

            get {

                return this.id3Genre;
            }
            set {

                this.id3Genre = value;
            }
        }
        public Byte Id3TrackNumber {

            get {

                return this.id3TrackNumber;
            }
            set {

                this.id3TrackNumber = value;
            }
        }
    }
}
