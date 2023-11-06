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
                N:2, E:Room.NoDoor, S:0, W:Room.NoDoor),
            new Room(2, "Början av äventyret", "ingang-stangd.png",
                "Du står i ett rum med kala\n" +
                "väggar. Ljuset från facklorna\n" +
                "lyser upp rummet. Du ser en\n" +
                "hög med tyg nere till vänster. ",
                N:3, E:Room.NoDoor, S:1, W:Room.NoDoor),
            new Room(3, "Lagerrum väst", "z-lagerrum-vast.png",
                "Du står i ett rum med en dörr\n" +
                "till vänster. Du ser en hög med\n" +
                "skräp nere till vänster.",
                N:Room.NoDoor, E:4, S:2, W:Room.NoDoor),
            new Room(4, "Korsvägen", "z-korsvag-oppet.png",
                "Du står i korsväg. Det går\n" +
                "gångar i alla riktningar.",
                N:7, E:5, S:3, W:6),
            new Room(5, "Återvändsgränd", "room-base.png",
                "Du kommer in i ett rum\n" +
                "helt utan dörrar. Gå tillbaka\n" +
                "och välj en annan väg.",
                N:Room.NoDoor, E:Room.NoDoor, S:4, W:Room.NoDoor),
            new Room(6, "Mörk gång", "z-gang.png",
                "Du hör forsande vatten.\n" +
                "Det är väldigt mörkt framåt.\n" +
                "Dina steg ekar bakom dig.",
                N:8, E:Room.NoDoor, S:4, W:Room.NoDoor),
            new Room(7, "Illabådande ljud", "fram.png",
                "Du ser en öppning med rött ljus.\n" +
                "Ifrån öppningen hör du ett\n" +
                "blött, ploppande ljud.",
                N:9, E:Room.NoDoor, S:4, W:Room.NoDoor),
            new Room(8, "Bro", "bro.png",
                "Du kommer fram till en bro\n" +
                "som leder över ett kraftigt \n" +
                "vattendrag. Gå försiktigt!",
                N:10, E:Room.NoDoor, S:6, W:Room.NoDoor),
            new Room(9, "Uh-Oh", "septopus.png",
                "Ett stort monster drar\n" +
                "sig framåt mot dig med\n" +
                "sina långa blöta tentakler!\n" +
                "SPRIIIING!",
                N:Room.NoDoor, E:Room.NoDoor, S:7, W:Room.NoDoor),
            new Room(10, "Hinder", "grind.jpg",
                "Du kommer fram till en låst grind. \n" +
                "Bortanför den ser du en öppen dörr\n" +
                "som ger en glimt av grönt gräs och träd.",
                N:11, E:Room.NoDoor, S:8, W:Room.NoDoor),
             new Room(11, "Freedom", "exit.jpg",
                "Långt bort ser du en öppen dörr \n" +
                "Genom öppningen ser du\n" +
                "grönt gräs och träd.\n" +
                "Fåglarna kvittrar när du kliver ut genom slottets bakdörr!",
                N:Room.NoDoor, E:Room.NoDoor, S:8, W:Room.NoDoor)
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
                if (next >= labyrinth.Count)
                {
                    warning = "Room not implemented.";
                    return;
                }
                warning = "";
                if (next == Room.NoDoor) warning = "Du gick in i väggen!\n";
                else current = next;
            }
            else if (command == "S")
            {
                int next = labyrinth[current].South;
                if (next >= labyrinth.Count)
                {
                    warning = "Room not implemented.";
                    return;
                }
                warning = "";
                if (next == Room.NoDoor) warning = "Du gick in i väggen!\n";
                else current = next;
            }
            else if (command == "D")
            {
                int next = labyrinth[current].East;
                if (next >= labyrinth.Count)
                {
                    warning = "Room not implemented.";
                    return;
                }
                warning = "";
                if (next == Room.NoDoor) warning = "Du gick in i väggen!\n";
                else current = next;
            }
            else if (command == "A")
            {
                int next = labyrinth[current].West;
                if (next >= labyrinth.Count)
                {
                    warning = "Room not implemented.";
                    return;
                }
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
