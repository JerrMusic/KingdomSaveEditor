using System.Collections.Generic;

namespace KHSave.LibPersona3
{
    public static partial class Presets
    {
        public record Field
        {
            public int Zone { get; set; }
            public int Room { get; set; }
            public GameVersion Game { get; set; }
            public string Description { get; set; }
        }

        private static Field FieldVF_(int category, int map, string description) => new()
            { Zone = category, Room = map, Description = description, Game = GameVersion.Vanilla | GameVersion.FES };
        private static Field FieldVFP(int category, int map, string description) => new()
            { Zone = category, Room = map, Description = description, Game = GameVersion.Vanilla | GameVersion.FES | GameVersion.Portable };
        private static Field Field_F_(int category, int map, string description) => new()
            { Zone = category, Room = map, Description = description, Game = GameVersion.FES };
        private static Field Field_FP(int category, int map, string description) => new()
            { Zone = category, Room = map, Description = description, Game = GameVersion.FES | GameVersion.Portable };
        private static Field Field__P(int category, int map, string description) => new()
            { Zone = category, Room = map, Description = description, Game = GameVersion.Portable };

        public static List<Field> Fields = new()
        {
            FieldVFP(  0,   0, ""),
            FieldVF_(  0,   2, ""),
            FieldVF_(  1,   0, ""),
            FieldVFP(  1,   1, "City map"),
            Field_F_(  4,   2, ""),
            Field_F_(  4,   3, ""),
            Field_F_(  4,   4, ""),
            Field_F_(  4,   5, ""),
            Field_F_(  4,   6, ""),
            Field_F_(  4,   7, ""),
            Field_F_(  4,  10, ""),
            Field_F_(  5,   1, ""),
            Field_F_(  5,   2, ""),
            Field_F_(  5,   3, ""),
            FieldVFP(  6,   1, "Gekkoukan High, 1st Floor, Main Lobby"),
            FieldVFP(  6,   2, "Gekkoukan High, School Entranceway"),
            FieldVFP(  6,   3, "Gekkoukan High, Classroom 2-F"),
            FieldVFP(  6,   4, "Gekkoukan High, 2nd Floor, Hallway"),
            FieldVFP(  6,   5, "Gekkoukan High, Rooftop"),
            FieldVFP(  6,   6, "Gekkoukan High, School Entranceway"),
            FieldVFP(  6,   7, "Gekkoukan High, 1st Floor, Hallway"),
            FieldVFP(  6,   8, "Gekkoukan High, Faculty Office"),
            FieldVFP(  6,   9, "Gekkoukan High, (TODO)"),
            FieldVFP(  6,  10, "Gekkoukan High, Library"),
            FieldVFP(  6,  11, "Gekkoukan High, 1st Floor, Hallway"),
            FieldVFP(  6,  12, "Gekkoukan High, Fashion club"),
            FieldVFP(  6,  13, "Gekkoukan High, Photography club"),
            FieldVFP(  6,  14, "Gekkoukan High, Music club"),
            FieldVFP(  6,  15, "Gekkoukan High, Art club"),
            FieldVFP(  6,  16, "Gekkoukan High, 1st Floor, Corridor"),
            FieldVFP(  6,  17, "Gekkoukan High, Track Team"),
            FieldVFP(  6,  18, "Gekkoukan High, Swim Team"),
            FieldVFP(  6,  19, "Gekkoukan High, Kendo Team"),
            FieldVFP(  6,  20, "Gekkoukan High, 1st Floor, Hallway (team)"),
            FieldVFP(  6,  21, "Gekkoukan High, Speech room"),
            FieldVFP(  6,  22, "Gekkoukan High, Classroom unused"),
            FieldVFP(  6,  23, "Gekkoukan High, (TODO)"),
            Field__P(  6,  24, "Gekkoukan High, (TODO)"),
            Field__P(  6,  25, "Gekkoukan High, (TODO)"),
            Field__P(  6,  26, "Gekkoukan High, (TODO)"),
            FieldVFP(  7,   1, "Dorm, Your Room"),
            FieldVFP(  7,   2, "Dorm, 1st Floor, Lounge"),
            FieldVFP(  7,   3, "Dorm, 2nd Floor, Hallway"),
            FieldVFP(  7,   4, "Dorm, 3rd Floor, Hallway"),
            FieldVFP(  7,   5, "Dorm, 4th Floor, Hallway"),
            FieldVFP(  7,   6, "Dorm, Meeting Room"),
            FieldVFP(  7,   7, "Dorm, 5th Floor, Hallway"),
            FieldVFP(  7,   8, "Dorm, Terrace"),
            FieldVFP(  7,   9, "Dorm, Entrance"),
            FieldVFP(  7,  10, "Dorm, Aegis Room"),
            FieldVFP(  7,  11, "Dorm, (TODO)"),
            FieldVFP(  7,  12, "Dorm, (TODO)"),
            FieldVFP(  7,  13, "Dorm, (TODO)"),
            FieldVFP(  7,  14, "Dorm, Vacant Room"),
            FieldVFP(  7,  15, "Dorm, Vacant Room"),
            Field_FP(  7,  16, "Dorm, (TODO)"),
            Field_FP(  7,  17, "Dorm, (TODO)"),
            Field_FP(  7,  18, "Dorm, (TODO)"),
            Field__P(  7,  19, "Dorm, (TODO)"),
            Field__P(  7,  20, "Dorm, (TODO)"),
            Field__P(  7,  21, "Dorm, (TODO)"),
            Field__P(  7,  22, "Dorm, (TODO)"),
            FieldVFP(  8,   1, "Paulownia Mall"),
            FieldVFP(  8,   2, "Paulownia Mall, Club Escapade"),
            FieldVFP(  8,   3, "Paulownia Mall, Velvet Room"),
            FieldVFP(  8,   4, "Paulownia Mall, Grocery Shop"),
            FieldVFP(  8,   5, "Paulownia Mall, Police Station"),
            FieldVFP(  8,   6, "Paulownia Mall, Jewlery Shop"),
            FieldVFP(  8,   7, "Paulownia Mall, (TODO)"),
            FieldVFP(  8,   8, "Paulownia Mall, (TODO)"),
            FieldVFP(  8,   9, "Paulownia Mall, Back Alley"),
            Field__P(  8,  10, "Paulownia Mall, (TODO)"),
            Field__P(  8,  11, "Paulownia Mall, (TODO)"),
            Field__P(  8,  12, "Paulownia Mall, (TODO)"),
            Field__P(  8,  13, "Paulownia Mall, (TODO)"),
            Field__P(  8,  14, "Paulownia Mall, (TODO)"),
            Field__P(  8,  15, "Paulownia Mall, (TODO)"),
            Field__P(  8,  16, "Paulownia Mall, (TODO)"),
            Field__P(  8,  17, "Paulownia Mall, (TODO)"),
            Field__P(  8,  18, "Paulownia Mall, (TODO)"),
            FieldVFP(  9,   1, "Iwatodai Strip Mall"),
            FieldVFP(  9,   2, "Iwatodai Strip Mall, Iwatoday Station"),
            FieldVFP(  9,   3, "Iwatodai Strip Mall, Fast food"),
            FieldVFP(  9,   4, "Iwatodai Strip Mall, (TODO)"),
            FieldVFP(  9,   5, "Iwatodai Strip Mall, Ramen Restaurant"),
            FieldVFP(  9,   6, "Iwatodai Strip Mall, (TODO)"),
            FieldVFP(  9,   7, "Iwatodai Strip Mall, (TODO)"),
            Field__P(  9,   8, "Iwatodai Strip Mall, (TODO)"),
            Field__P(  9,   9, "Iwatodai Strip Mall, (TODO)"),
            FieldVFP( 10,   1, "Port Island Station"),
            FieldVFP( 10,   2, "Station Outskirts"),
            FieldVF_( 10,   3, ""),
            FieldVFP( 12,   1, "Naganaki Shrine"),
            FieldVFP( 13,   1, ""),
            FieldVFP( 13,   2, "Mansion - Corridor"),
            FieldVF_( 13,   3, ""),
            FieldVFP( 14,   1, "Fishing area"),
            FieldVFP( 14,   2, "Godaigo, 1st Floor"),
            FieldVFP( 14,   3, "Godaigo, 2st Floor"),
            FieldVFP( 14,   4, "Godaigo, 3st Floor"),
            FieldVFP( 14,   5, "Godaigo, Big Hot Spring"),
            FieldVFP( 14,   6, "Godaigo, Men's Room"),
            FieldVFP( 14,   7, "Godaigo, Men's Room"),
            FieldVFP( 14,   8, "Godaigo, Men's Room"),
            FieldVFP( 14,   9, "Godaigo, Men's Room"),
            FieldVFP( 14,  10, "Godaigo, Men's Room"),
            Field__P( 14,  11, ""),
            Field__P( 14,  12, ""),
            Field__P( 14,  13, ""),
            Field__P( 14,  14, ""),
            Field__P( 14,  15, ""),
            Field__P( 14,  16, ""),
            FieldVFP( 15,   1, "Hospital Room"),
            FieldVFP( 15,   2, "Hospital Room"),
            FieldVFP( 15,   3, "Hospital Room"),
            FieldVFP( 15,   4, "Champs De Fleurs Entrance"),
            FieldVFP( 15,   5, ""),
            FieldVFP( 15,   6, ""),
            Field_F_( 15,   7, ""),
            Field_FP( 15,   8, ""),
            Field_F_( 15,   9, ""),
            Field_FP( 15,  10, ""),
            Field__P( 15,  11, ""),
            Field__P( 15,  12, ""),
            Field__P( 15,  13, ""),
            Field__P( 15,  14, ""),
            Field__P( 15,  15, ""),
            Field__P( 15,  16, ""),
            Field__P( 15,  17, ""),
            Field__P( 15,  18, ""),
            Field__P( 15,  19, ""),
            Field__P( 15,  20, ""),
            Field__P( 15,  21, ""),
            Field__P( 15,  22, ""),
            Field__P( 15,  23, ""),
            Field__P( 15,  24, ""),
            Field__P( 15,  25, ""),
            Field__P( 15,  26, ""),
            Field__P( 15,  27, ""),
            Field__P( 15,  28, ""),
            Field__P( 15,  29, ""),
            FieldVFP( 16,   1, ""),
            FieldVFP( 16,   2, ""),
            FieldVFP( 16,   3, ""),
            FieldVFP( 16,   4, ""),
            FieldVFP( 16,   5, ""),
            FieldVF_( 20,   1, ""),
            FieldVF_( 20,   2, ""),
            FieldVF_( 20,   3, ""),
            FieldVF_( 20,   4, ""),
            FieldVF_( 20,   5, ""),
            FieldVF_( 20,   6, ""),
            FieldVF_( 20,   7, ""),
            FieldVF_( 20,   8, ""),
            FieldVF_( 20,   9, ""),
            FieldVF_( 20,  10, ""),
            FieldVF_( 20,  11, ""),
            FieldVF_( 20,  12, ""),
            FieldVF_( 20,  13, ""),
            FieldVF_( 20,  14, ""),
            FieldVF_( 20,  15, ""),
            FieldVF_( 20,  16, ""),
            FieldVF_( 20,  17, ""),
            FieldVF_( 20,  18, ""),
            FieldVF_( 20,  19, ""),
            FieldVFP( 21,   0, ""),
            FieldVFP( 21,   1, ""),
            FieldVFP( 21,   2, ""),
            FieldVFP( 21,   3, ""),
            FieldVFP( 21,   4, ""),
            FieldVFP( 21,   5, ""),
            FieldVFP( 21,   6, ""),
            FieldVFP( 21,   7, ""),
            FieldVFP( 21,   8, ""),
            FieldVFP( 21,   9, ""),
            FieldVFP( 21,  11, ""),
            FieldVFP( 21,  13, ""),
            FieldVFP( 21,  14, ""),
            FieldVFP( 21,  16, ""),
            FieldVFP( 21,  17, ""),
            FieldVFP( 21,  18, ""),
            FieldVFP( 21,  19, ""),
            FieldVFP( 21,  30, ""),
            FieldVFP( 21,  50, ""),
            FieldVFP( 22,   0, ""),
            FieldVFP( 22,   1, ""),
            FieldVFP( 22,   2, ""),
            FieldVFP( 22,   3, ""),
            FieldVFP( 22,   4, ""),
            FieldVFP( 22,   5, ""),
            FieldVFP( 22,   6, ""),
            FieldVFP( 22,   7, ""),
            FieldVFP( 22,   8, ""),
            FieldVFP( 22,  18, ""),
            FieldVFP( 22,  50, ""),
            FieldVFP( 22,  51, ""),
            FieldVFP( 23,   0, ""),
            FieldVFP( 23,   1, ""),
            FieldVFP( 23,   2, ""),
            FieldVFP( 23,   3, ""),
            FieldVFP( 23,   4, ""),
            FieldVFP( 23,   5, ""),
            FieldVFP( 23,   6, ""),
            FieldVFP( 23,   7, ""),
            FieldVFP( 23,   8, ""),
            FieldVFP( 23,  18, ""),
            FieldVFP( 23,  50, ""),
            FieldVFP( 23,  51, ""),
            FieldVFP( 24,   0, ""),
            FieldVFP( 24,   1, ""),
            FieldVFP( 24,   2, ""),
            FieldVFP( 24,   3, ""),
            FieldVFP( 24,   4, ""),
            FieldVFP( 24,   5, ""),
            FieldVFP( 24,   6, ""),
            FieldVFP( 24,   7, ""),
            FieldVFP( 24,   8, ""),
            FieldVFP( 24,  18, ""),
            FieldVFP( 24,  50, ""),
            FieldVFP( 24,  51, ""),
            FieldVFP( 25,   0, ""),
            FieldVFP( 25,   1, ""),
            FieldVFP( 25,   2, ""),
            FieldVFP( 25,   3, ""),
            FieldVFP( 25,   4, ""),
            FieldVFP( 25,   5, ""),
            FieldVFP( 25,   6, ""),
            FieldVFP( 25,   7, ""),
            FieldVFP( 25,   8, ""),
            FieldVFP( 25,  18, ""),
            FieldVFP( 25,  50, ""),
            FieldVFP( 26,   0, ""),
            FieldVFP( 26,   1, ""),
            FieldVFP( 26,   2, ""),
            FieldVFP( 26,   3, ""),
            FieldVFP( 26,   4, ""),
            FieldVFP( 26,   5, ""),
            FieldVFP( 26,   6, ""),
            FieldVFP( 26,   7, ""),
            FieldVFP( 26,   8, ""),
            FieldVFP( 26,  18, ""),
            FieldVFP( 26,  50, ""),
            FieldVFP( 26,  51, ""),
            FieldVF_( 26,  52, ""),
            FieldVF_( 26,  53, ""),
            FieldVFP( 27,   0, ""),
            FieldVFP( 27,   1, ""),
            FieldVFP( 27,   2, ""),
            FieldVFP( 27,   3, ""),
            FieldVFP( 27,   4, ""),
            FieldVFP( 27,   5, ""),
            FieldVFP( 27,   6, ""),
            FieldVFP( 27,   7, ""),
            FieldVFP( 27,   8, ""),
            FieldVFP( 27,  18, ""),
            FieldVFP( 27,  50, ""),
            FieldVF_( 28,   0, ""),
            FieldVFP( 31,   1, "Monoral Bridge"),
            FieldVFP( 31,   2, "10th/11th Carriage"),
            FieldVFP( 31,   3, "8th/9th Carriage"),
            FieldVFP( 31,   4, "6th/7th Carriage"),
            FieldVFP( 31,   5, "4th/5th Carriage"),
            FieldVFP( 31,   6, "2th/3rd Carriage"),
            FieldVFP( 31,   7, "1st Carriagewe"),
            FieldVFP( 32,   1, "Tartarus, School Entrance"),
            FieldVFP( 32,   2, "Tartarus, Entrance"),
            Field_FP( 32,   3, ""),
            FieldVFP( 32,   4, ""),
            FieldVFP( 32,   5, "Tartarus, Last Floor"),
            FieldVFP( 32,   6, "Tartarus, Rooftop"),
            FieldVFP( 32,   7, ""),
            FieldVFP( 32,   8, "Tartarus, School Entrance"),
            FieldVFP( 32,   9, "Tartarus, Entrance (cutscene)"),
            FieldVFP( 33,   1, ""),
            FieldVFP( 33,   2, "Forest"),
            FieldVFP( 33,   3, "Forest"),
            FieldVFP( 34,   1, "Hallway, 1st Floor"),
            FieldVFP( 34,   2, "Hallway, 2nd Floor"),
            FieldVFP( 34,   3, "Hallway, 2nd Floor"),
            FieldVFP( 34,   4, "Hallway, 3rd Floor"),
            FieldVFP( 34,   5, "Room 101"),
            FieldVFP( 34,   6, "Room 201"),
            FieldVFP( 34,   7, "Room 202"),
            FieldVFP( 34,   8, "Room 203"),
            FieldVFP( 34,   9, "Room 204"),
            FieldVFP( 34,  10, "Room 205"),
            FieldVFP( 34,  11, "Room 201"),
            FieldVFP( 34,  12, "Room 202"),
            FieldVFP( 34,  13, "Room 203"),
            FieldVFP( 34,  14, "Room 204"),
            FieldVFP( 34,  15, "Room 205"),
            FieldVFP( 34,  16, "Room 301"),
            FieldVFP( 34,  17, "Room 302"),
            FieldVFP( 34,  18, "Room 303"),
            FieldVFP( 34,  19, "Room 304"),
            FieldVFP( 34,  20, "Hierophant's Chamber"),
            FieldVFP( 35,   1, "13m Underground"),
            FieldVFP( 35,   2, "17m Underground"),
            FieldVFP( 35,   3, "21m Underground"),
            FieldVFP( 35,   4, "27m Underground"),
            FieldVFP( 35,   5, "30m Underground"),
            FieldVFP( 35,   6, "30m Underground"),
            FieldVFP( 35,   7, "21m Underground"),
            FieldVFP( 35,   8, "Station Outskirts"),
            FieldVFP( 35,   9, "Station Outskirts"),
            FieldVFP( 35,  10, "33m Underground"),
            FieldVFP( 35,  11, "33m Underground"),
            FieldVFP( 35,  12, "33m Underground"),
            FieldVFP( 35,  13, "33m Underground"),
            FieldVFP( 35,  14, "33m Underground"),
            FieldVFP( 35,  15, "33m Underground"),
            FieldVFP( 35,  16, "33m Underground"),
            FieldVFP( 35,  17, "38m Underground"),
            FieldVFP( 37,   1, "Moonlight Bridge"),
            Field__P( 37,   2, ""),
            Field__P( 38,   1, ""),
            Field_FP( 39,   1, ""),
            Field_F_( 39,   2, ""),
            Field_F_( 39,   3, ""),
            Field_FP( 40,   1, ""),
            Field_F_( 41,   0, ""),
            Field_FP( 41,   1, ""),
            Field_F_( 41,   2, ""),
            Field_F_( 41,   3, ""),
            Field_F_( 41,   4, ""),
            Field_F_( 41,   5, ""),
            Field_F_( 41,   6, ""),
            Field_F_( 41,   7, ""),
            Field_F_( 41,   8, ""),
            Field_F_( 41,  18, ""),
            Field_F_( 41,  50, ""),
            Field_F_( 42,   0, ""),
            Field_FP( 42,   1, ""),
            Field_F_( 42,   2, ""),
            Field_F_( 42,   3, ""),
            Field_F_( 42,   4, ""),
            Field_F_( 42,   5, ""),
            Field_F_( 42,   6, ""),
            Field_F_( 42,   7, ""),
            Field_F_( 42,   8, ""),
            Field_F_( 42,  18, ""),
            Field_F_( 42,  50, ""),
            Field_F_( 43,   0, ""),
            Field_FP( 43,   1, ""),
            Field_F_( 43,   2, ""),
            Field_F_( 43,   3, ""),
            Field_F_( 43,   4, ""),
            Field_F_( 43,   5, ""),
            Field_F_( 43,   6, ""),
            Field_F_( 43,   7, ""),
            Field_F_( 43,   8, ""),
            Field_F_( 43,  18, ""),
            Field_F_( 43,  50, ""),
            Field_F_( 44,   0, ""),
            Field_FP( 44,   1, ""),
            Field_F_( 44,   2, ""),
            Field_F_( 44,   3, ""),
            Field_F_( 44,   4, ""),
            Field_F_( 44,   5, ""),
            Field_F_( 44,   6, ""),
            Field_F_( 44,   7, ""),
            Field_F_( 44,   8, ""),
            Field_F_( 44,  18, ""),
            Field_F_( 44,  50, ""),
            Field_F_( 45,   0, ""),
            Field_FP( 45,   1, ""),
            Field_F_( 45,   2, ""),
            Field_F_( 45,   3, ""),
            Field_F_( 45,   4, ""),
            Field_F_( 45,   5, ""),
            Field_F_( 45,   6, ""),
            Field_F_( 45,   7, ""),
            Field_F_( 45,   8, ""),
            Field_F_( 45,  18, ""),
            Field_F_( 45,  50, ""),
            Field__P( 46,   1, ""),
            Field_F_( 46,  50, ""),
            Field__P( 47,   1, ""),
            Field_F_( 47,  50, ""),
            Field__P( 48,   1, ""),
            Field__P( 49,   1, ""),
            Field__P( 50,   1, ""),
            FieldVFP( 51,   1, "Block 1, Boss Room"),
            FieldVFP( 51,   2, "Block 1, Boss Room"),
            FieldVFP( 51,   3, "Block 1, Boss Room"),
            FieldVFP( 51,   4, "Block 1, Boss Room"),
            FieldVFP( 52,   1, "Block 2, Boss Room"),
            FieldVFP( 52,   2, "Block 2, Boss Room"),
            FieldVFP( 52,   3, "Block 2, Boss Room"),
            FieldVFP( 52,   4, "Block 2, Boss Room"),
            FieldVFP( 52,   5, "Block 2, Boss Room"),
            FieldVFP( 52,   6, "Block 2, Boss Room"),
            FieldVFP( 52,   7, "Block 2, Boss Room"),
            FieldVFP( 53,   1, "Block 3, Boss Room"),
            FieldVFP( 53,   2, "Block 3, Boss Room"),
            FieldVFP( 53,   3, "Block 3, Boss Room"),
            FieldVFP( 53,   4, "Block 3, Boss Room"),
            FieldVFP( 54,   1, "Block 4, Boss Room"),
            FieldVFP( 54,   2, "Block 4, Boss Room"),
            FieldVFP( 54,   3, "Block 4, Boss Room"),
            FieldVFP( 54,   4, "Block 4, Boss Room"),
            FieldVFP( 55,   1, "Block 5, Boss Room"),
            FieldVFP( 55,   2, "Block 5, Boss Room"),
            FieldVFP( 55,   3, "Block 5, Boss Room"),
            FieldVFP( 55,   4, "Block 5, Boss Room"),
            FieldVFP( 55,   5, "Block 5, Boss Room"),
            FieldVFP( 56,   1, "Block 6, Boss Room"),
            FieldVFP( 56,   2, "Block 6, Boss Room"),
            FieldVFP( 56,   3, "Block 6, Boss Room"),
            FieldVFP( 56,   4, "Block 6, Boss Room"),
            FieldVFP( 56,   5, "Block 6, Boss Room"),
            Field_F_( 71,   1, ""),
            Field_F_( 71,   2, ""),
            Field_F_( 71,   3, ""),
            Field_F_( 71,   4, ""),
            Field_F_( 71,   5, ""),
            Field_F_( 71,   6, ""),
            Field_F_( 72,   1, ""),
            Field_F_( 72,   2, ""),
            Field_F_( 72,   3, ""),
            Field_F_( 72,   4, ""),
            Field_F_( 73,   1, ""),
            Field_F_( 73,   2, ""),
            Field_F_( 73,   3, ""),
            Field_F_( 73,   4, ""),
            Field_F_( 73,   5, ""),
            Field_F_( 73,   6, ""),
            Field_F_( 74,   1, ""),
            Field_F_( 74,   2, ""),
            Field_F_( 74,   3, ""),
            Field_F_( 74,   4, ""),
            Field_F_( 75,   1, ""),
            Field_F_( 75,   2, ""),
            Field_F_( 75,   3, ""),
            Field_F_( 75,   4, ""),
            Field_F_( 75,   5, ""),
            FieldVFP(200,   0, ""),
            FieldVFP(221,   0, ""),
            FieldVFP(221,   1, ""),
            FieldVFP(221,   2, ""),
            FieldVFP(221,   3, ""),
            Field__P(221,  50, ""),
            FieldVFP(222,   1, ""),
            FieldVFP(222,   2, ""),
            Field__P(222,  50, ""),
            Field__P(222,  51, ""),
            FieldVFP(223,   1, ""),
            FieldVFP(223,   2, ""),
            Field__P(223,  50, ""),
            Field__P(223,  51, ""),
            FieldVFP(224,   1, ""),
            FieldVFP(224,   2, ""),
            FieldVFP(224,   3, ""),
            Field__P(224,  50, ""),
            Field__P(224,  51, ""),
            FieldVFP(225,   1, ""),
            FieldVFP(225,   2, ""),
            Field__P(225,  50, ""),
            FieldVFP(226,   1, ""),
            FieldVFP(226,   2, ""),
            Field__P(226,  50, ""),
            Field__P(226,  51, ""),
            FieldVFP(227,   1, ""),
            FieldVFP(227,   2, ""),
            Field__P(227,  50, ""),
            FieldVFP(228,   1, ""),
            FieldVFP(228,   2, ""),
            FieldVFP(230,   1, ""),
            Field_F_(230,   2, ""),
            FieldVFP(231,   1, ""),
            FieldVFP(231,   2, ""),
            FieldVFP(232,   1, ""),
            FieldVFP(232,   2, ""),
            FieldVFP(232,   3, ""),
            FieldVFP(232,   4, ""),
            FieldVFP(232,   5, ""),
            FieldVFP(232,   6, ""),
            FieldVFP(232,   7, ""),
            FieldVFP(234,   1, ""),
            FieldVFP(234,   2, ""),
            FieldVFP(234,   3, ""),
            FieldVFP(235,   1, ""),
            FieldVFP(235,   2, ""),
            FieldVFP(235,   3, ""),
            FieldVFP(236,   1, ""),
            FieldVFP(237,   2, ""),
            FieldVFP(237,   3, ""),
            FieldVFP(238,   1, ""),
            Field_F_(239,   1, ""),
            Field_F_(239,   4, ""),
            Field_F_(239,   5, ""),
            Field_F_(241,   1, ""),
            Field_F_(242,   1, ""),
            Field_F_(243,   1, ""),
            Field_F_(244,   1, ""),
            Field_F_(245,   1, ""),
            FieldVFP(251,   1, ""),
            Field__P(251,   2, ""),
            FieldVFP(251,   3, ""),
            Field__P(251,   4, ""),
            FieldVFP(252,   1, ""),
            Field__P(252,   2, ""),
            Field__P(252,   3, ""),
            Field__P(252,   4, ""),
            Field__P(252,   5, ""),
            Field__P(252,   6, ""),
            Field__P(252,   7, ""),
            FieldVFP(253,   1, ""),
            Field__P(253,   2, ""),
            Field__P(253,   3, ""),
            Field__P(253,   4, ""),
            FieldVFP(254,   1, ""),
            Field__P(254,   2, ""),
            Field__P(254,   3, ""),
            Field__P(254,   4, ""),
            FieldVFP(255,   1, ""),
            Field__P(255,   2, ""),
            Field__P(255,   3, ""),
            Field__P(255,   4, ""),
            Field__P(255,   5, ""),
            FieldVFP(256,   1, ""),
            Field__P(256,   2, ""),
            Field__P(256,   3, ""),
            Field__P(256,   4, ""),
            Field__P(256,   5, ""),
            FieldVF_(257,   1, ""),
            Field_F_(271,   1, ""),
            Field_F_(272,   1, ""),
            Field_F_(273,   1, ""),
            Field_F_(274,   1, ""),
            Field_F_(275,   1, ""),
        };
    }
}
