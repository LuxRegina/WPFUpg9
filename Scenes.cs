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
        public Room(int self, string name, string text, int N, int E, int S, int W)
        {
            this.self = self; this.title = name; this.text = text;
            north = N; east = E; south = S; west = W;
        }
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
        public string Image { get { return text; } }
    }
    public class Labyrinth
    {
        static string warning = "";
        static Room help = new Room(-1, "Help",
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
                N:3, E:Room.NoDoor, S:Room.NoDoor, W:Room.NoDoor),
            new Room(1, "Ingången",
                "Du står i ett rum med rött\n" +
                "tegel. Väggarna fladdrar i\n" +
                "facklornas sken. Du ser en\n" +
                "hög med tyg nere till vänster. ",
                N:3, E:Room.NoDoor, S:Room.NoDoor, W:Room.NoDoor),
            new Room(2, "Början av äventyret",
                "Du står i ett rum med rött\n" +
                "tegel. Väggarna fladdrar i\n" +
                "facklornas sken. Du ser en\n" +
                "hög med tyg nere till vänster. ",
                N:3, E:Room.NoDoor, S:Room.NoDoor, W:Room.NoDoor),
            new Room(3, "Lagerrum väst",
                "Du står i ett rum utan vägar\n" +
                "framåt. Du ser en hög med\n" +
                "skräp nere till vänster.",
                N:Room.NoDoor, E:2, S:Room.NoDoor, W:Room.NoDoor),
            new Room(4, "Vaktrum väst",
                "Du står i ett övergivet vaktrum.",
                N:Room.NoDoor, E: 3, S:Room.NoDoor, W:1),
            new Room(5, "Korsvägen",
                "Du står i korsväg. Det går\n" +
                "gångar i alla riktningar.",
                N:6, E:4, S:0, W:2)
        };
        static int current = 0;
        public static string HelpTitle() { return help.Title; }
        public static string HelpText() { return help.Text; }
        //public static string HelpImage() { return help.Image; }  // ToDo
        public static void DoCommand(string command)
        {
            if (command == "w")
            {
                int next = labyrinth[current].North;
                warning = "";
                if (next == Room.NoDoor) warning = "Du gick in i väggen!\n";
                else current = next;
            }
            else if (command == "s")
            {
                int next = labyrinth[current].South;
                warning = "";
                if (next == Room.NoDoor) warning = "Du gick in i väggen!\n";
                else current = next;
            }
            else if (command == "d")
            {
                int next = labyrinth[current].East;
                warning = "";
                if (next == Room.NoDoor) warning = "Du gick in i väggen!\n";
                else current = next;
            }
            else if (command == "a")
            {
                int next = labyrinth[current].West;
                warning = "";
                if (next == Room.NoDoor) warning = "Du gick in i väggen!\n";
                else current = next;
            }
            else if (command == "f")
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
