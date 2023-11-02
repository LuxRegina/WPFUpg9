using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTP9_MUD_WPF_stub
{
    public class Room
    {
        public static int NoDoor = -997;
        int self;
        string title;
        string text;
        int north, east, south, west;
        string image;
        public Room(int self, string name, string image, string text, int N, int E, int S, int W)
        {
            this.self = self; this.title = name; this.image = image; this.text = text;
            north = N; east = E; south = S; west = W;
        }
        public string Image { get { return image; } }
        public string Title { get { return title; } }
        public string Text { get { return text; } }
        public int North { get { return north; } }
        public int East { get { return east; } }
        public int South { get { return south; } }
        public int West { get { return west; } }
        public string Directions
        {
            get
            {
                string dir = "Det går dörrar till:\n";
                if (north != NoDoor) dir += "  w - norr\n";
                if (east != NoDoor) dir += "  d - öster\n";
                if (south != NoDoor) dir += "  s - söder\n";
                if (west != NoDoor) dir += "  a - väster\n";
                return dir;
            }
        }
        
    }
    public class Labyrinth
    {
        static string warning = "";
        static Room help = new Room(-1, "Help", "galler.png",
               "Följande kommandon finns:\n" +
               "  w - gå genom dörren norrut\n" +
               "  s - gå genom dörren söderut\n" +
               "  d - gå genom dörren österut\n" +
               "  a - gå genom dörren västerut\n" +
               "  l - leta\n" +
               "  h - hjälp\n" +
               "  z - avsluta\n",
               Room.NoDoor, Room.NoDoor, Room.NoDoor, Room.NoDoor);
        static List<Room> labyrinth = new List<Room>() {
             new Room(0, "Slottet", "slott.jpg",
                "Du ser ett slott framför dig.\n" +
                "Nyfikenheten kittlar dig.\n" +
                "För att gå in trycker du\n" +
                "'w'. ",
                N:1, E:Room.NoDoor, S:Room.NoDoor, W:Room.NoDoor),
            new Room(1, "Ingången","room-020.png",
                "Du står framför en röd dörr.\n" +
                "Väggarna är av kallt tegel. \n" +
                "Du trycker försiktigt ned handtaget\n" +
                "och går in i slottets gångar. ",
                N:2, E:Room.NoDoor, S:Room.NoDoor, W:Room.NoDoor),
            new Room(2, "Början av äventyret", "ingang-stangd.png",
                "Du står i ett rum med kala\n" +
                "väggar. Ljuset från facklorna\n" +
                "lyser upp rummet. Du ser en\n" +
                "hög med tyg nere till vänster. ",
                N:3, E:Room.NoDoor, S:Room.NoDoor, W:Room.NoDoor),
            new Room(3, "Lagerrum väst", "z-lagerrum-vast.png",
                "Du står i ett rum utan vägar\n" +
                "framåt. Du ser en hög med\n" +
                "skräp nere till vänster.",
                N:Room.NoDoor, E:4, S:Room.NoDoor, W:Room.NoDoor),
            new Room(4, "Vaktrum väst", "z-vaktrum-vast.png",
                "Du står i ett övergivet vaktrum.",
                N:Room.NoDoor, E: 5, S:Room.NoDoor, W:1),
            new Room(5, "Korsvägen", "z-korsvag-oppet.png",
                "Du står i korsväg. Det går\n" +
                "gångar i alla riktningar.",
                N:6, E:4, S:0, W:2)
        };
        static int current = 0;
        public static string HelpTitle() { return help.Title; }
        public static string HelpText() { return help.Text; }
        public static string HelpImage() { return help.Image; }
        public static void DoCommand(string command)
        {
            if (command == "W")
            {
                int next = labyrinth[current].North;
                warning = "";
                if (next == Room.NoDoor) warning = "Du gick in i väggen!\n";
                else current = next;
            }
            else if (command == "S")
            {
                int next = labyrinth[current].South;
                warning = "";
                if (next == Room.NoDoor) warning = "Du gick in i väggen!\n";
                else current = next;
            }
            else if (command == "D")
            {
                int next = labyrinth[current].East;
                warning = "";
                if (next == Room.NoDoor) warning = "Du gick in i väggen!\n";
                else current = next;
            }
            else if (command == "A")
            {
                int next = labyrinth[current].West;
                warning = "";
                if (next == Room.NoDoor) warning = "Du gick in i väggen!\n";
                else current = next;
            }
            else if (command == "F")
            {
                warning = "Du hittade ingenting\n";
            }
            else
            {
                warning = "Okänt kommando\n";
            }
        }
        internal static string CurrentTitle()
        {
            return labyrinth[current].Title;
        }
        internal static string CurrentText()
        {
            return labyrinth[current].Text;
        }
        internal static string WarningText()
        {
            return warning;
        }
        internal static string Directions()
        {
            return labyrinth[current].Directions;
        }
        internal static string CurrentImage()
        {
            return labyrinth[current].Image;
        }
    }
}
