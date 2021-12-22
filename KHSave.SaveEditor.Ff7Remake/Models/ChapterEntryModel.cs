/*
    Kingdom Save Editor
    Copyright (C) 2020 Luciano Ciccariello

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using KHSave.LibFf7Remake;
using KHSave.LibFf7Remake.Chunks;
using KHSave.LibFf7Remake.Models;
using KHSave.LibFf7Remake.Types;
using KHSave.SaveEditor.Common;
using KHSave.SaveEditor.Common.Models;
using KHSave.SaveEditor.Ff7Remake.Data;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Xe.Tools;

namespace KHSave.SaveEditor.Ff7Remake.Models
{
    public class ChapterEntryModel : BaseNotifyPropertyChanged
    {
        private readonly ChunkChapter _chapter;
        private readonly int _index;

        public ChapterEntryModel(ChunkChapter chapter, int index, Vector3f cloudPosition)
        {
            _chapter = chapter;
            _index = index;
            CharacterStatusTypes = new KhEnumListModel<CharacterStatusType>(() => default, x => { });

            if (Global.IsAdvancedMode)
            {
                Objects = new Xe.Tools.Wpf.Models.GenericListModel<ChapterObjectEntry>(
                    chapter.Npc.Select(x => new ChapterObjectEntry(x, chapter.Npc, cloudPosition)));
                Objects2 = new Xe.Tools.Wpf.Models.GenericListModel<ChapterObjectEntry>(
                    chapter.Objects.Select(x => new ChapterObjectEntry(x, chapter.Objects, cloudPosition)));
                Objects3 = new Xe.Tools.Wpf.Models.GenericListModel<ChapterObjectEntry>(
                    chapter.Enemies.Select(x => new ChapterObjectEntry(x, chapter.Enemies, cloudPosition)));
            }
            else
            {
                // Speed up loading times on basic mode
                Objects = new Xe.Tools.Wpf.Models.GenericListModel<ChapterObjectEntry>(new ChapterObjectEntry[0]);
                Objects2 = Objects;
                Objects3 = Objects;
            }
        }

        public Visibility SimpleVisibility => Global.IsAdvancedMode ? Visibility.Collapsed : Visibility.Visible;
        public Visibility AdvancedVisibility => Global.IsAdvancedMode ? Visibility.Visible : Visibility.Collapsed;
        public KhEnumListModel<CharacterStatusType> CharacterStatusTypes { get; }

        public bool IsChapterEnabled => !(_chapter.CharacterStatus?.All(x => x == 0) ?? true);
        public Visibility ChapterVisibility => IsChapterEnabled ? Visibility.Visible : Visibility.Collapsed;
        public Visibility ChapterDisabledVisibility => !IsChapterEnabled ? Visibility.Visible : Visibility.Collapsed;

        public string Name
        {
            get
            {
                var chunkIdDesc = _index switch
                {
                    0 => "Chapter 1",
                    1 => "Chapter 2",
                    2 => "Chapter 3,12",
                    3 => "Chapter 4",
                    4 => "Chapter 5",
                    5 => "Chapter 6",
                    6 => "Chapter 7",
                    7 => "Unused",
                    8 => "Ch. 8,9,13,14",
                    9 => "Ch. 10",
                    10 => "Ch. 11",
                    11 => "Unused",
                    12 => "Unused",
                    13 => "?????",
                    14 => "Unused",
                    15 => "Chapter 15",
                    16 => "Ch. 16,17,18",
                    17 => "Unused",
                    18 => "DLC Chapter 1",
                    19 => "DLC Chapter 2",
                    _ => "",
                };

                return $"#{_index:D02} {chunkIdDesc}";
            }
        }

        public IEnumerable<BgmModel> BgmList => BgmPreset.Get();
        public bool IsChapterInPlay { get => _chapter.IsChapterInPlay != 0; set => _chapter.IsChapterInPlay = (byte)(value ? 1 : 0); }
        public byte ChapterId { get => _chapter.ChapterId; set => _chapter.ChapterId = value; }
        public int Bgm { get => _chapter.Bgm; set { _chapter.Bgm = (ushort)value; OnPropertyChanged(); } }

        public ChapterCharacterEntryModel Entity0 => new ChapterCharacterEntryModel(_chapter, 0);
        public ChapterCharacterEntryModel Entity1 => new ChapterCharacterEntryModel(_chapter, 1);
        public ChapterCharacterEntryModel Entity2 => new ChapterCharacterEntryModel(_chapter, 2);
        public ChapterCharacterEntryModel Entity3 => new ChapterCharacterEntryModel(_chapter, 3);
        public ChapterCharacterEntryModel Entity4 => new ChapterCharacterEntryModel(_chapter, 4);
        public ChapterCharacterEntryModel Entity5 => new ChapterCharacterEntryModel(_chapter, 5);
        public ChapterCharacterEntryModel Entity6 => new ChapterCharacterEntryModel(_chapter, 6);
        public ChapterCharacterEntryModel Entity7 => new ChapterCharacterEntryModel(_chapter, 7);
        public ChapterCharacterEntryModel Entity8 => new ChapterCharacterEntryModel(_chapter, 8);
        public ChapterCharacterEntryModel Entity9 => new ChapterCharacterEntryModel(_chapter, 9);
        public ChapterCharacterEntryModel Entity10 => new ChapterCharacterEntryModel(_chapter, 10);
        public ChapterCharacterEntryModel Entity11 => new ChapterCharacterEntryModel(_chapter, 11);

        public Xe.Tools.Wpf.Models.GenericListModel<ChapterObjectEntry> Objects { get; }
        public Xe.Tools.Wpf.Models.GenericListModel<ChapterObjectEntry> Objects2 { get; }
        public Xe.Tools.Wpf.Models.GenericListModel<ChapterObjectEntry> Objects3 { get; }
    }
}
