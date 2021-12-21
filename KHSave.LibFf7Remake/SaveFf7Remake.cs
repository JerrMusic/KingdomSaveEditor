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

using KHSave.LibFf7Remake.Chunks;
using KHSave.LibFf7Remake.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xe.BinaryMapper;

namespace KHSave.LibFf7Remake
{
    public class SaveFf7Remake
    {
        public const bool _EnableLastChapter = false;
        public const int ChapterCount = 18;
        public const int CharacterCount = 8;
        public const int Cloud = 0;
        public const int Barret = 1;
        public const int Tifa = 2;
        public const int Aerith = 3;
        public const int Red13 = 4;
        public const int Yuffie = 5;
        public const int Sonon = 6;
        public const int LastKnownCharacter = Sonon;
        public const int Unequipped = 9;

        private SaveFf7Remake(List<Chunk> chunks)
        {
            Chunks = chunks.ToArray();
            if (_EnableLastChapter)
                Chapters = new ChunkChapter[ChapterCount + 1];
            else
                Chapters = new ChunkChapter[ChapterCount];
            ReimportChunks();
        }

        public SaveFf7Remake Write(Stream stream)
        {
            WriteChunk(ChunkCommon, 0, 0);
            for (var i = 0; i < ChapterCount; i++)
                WriteChunk(Chapters[i], 1, i);
            if (_EnableLastChapter)
                WriteChunk(Chapters[ChapterCount], 3);

            foreach (var chunk in Chunks)
                chunk.Write(stream);

            return this;
        }

        public ChunkCommon ChunkCommon { get; private set; }

        public Chunk[] Chunks { get; private set; }

        public byte CurrentChapterChunk { get => ChunkCommon.CurrentChapterChunk; set => ChunkCommon.CurrentChapterChunk = value; }
        public byte CurrentChapterId { get => ChunkCommon.CurrentChapterId; set => ChunkCommon.CurrentChapterId = value; }
        public byte CurrentChapterChunk2 { get => ChunkCommon.CurrentChapterChunk2; set => ChunkCommon.CurrentChapterChunk2 = value; }
        public Character[] Characters { get => ChunkCommon.Characters; set => ChunkCommon.Characters = value; }
        public CharacterStats[] CharactersStats { get => ChunkCommon.CharactersStats; set => ChunkCommon.CharactersStats = value; }
        public CharacterEquipment[] CharactersEquipment { get => ChunkCommon.CharactersEquipment; set => ChunkCommon.CharactersEquipment = value; }
        public Materia[] Materia { get => ChunkCommon.Materia; set => ChunkCommon.Materia = value; }
        public Inventory[] Inventory { get => ChunkCommon.Inventory; set => ChunkCommon.Inventory = value; }
        public MateriaEquipment[] CharacterMateria { get => ChunkCommon.CharacterMateria; set => ChunkCommon.CharacterMateria = value; }
        public MateriaEquipment[] WeaponMateria { get => ChunkCommon.WeaponMateria; set => ChunkCommon.WeaponMateria = value; }
        public WeaponFound[] WeaponFound { get => ChunkCommon.WeaponFound; set => ChunkCommon.WeaponFound = value; }
        public byte PlayableCharacter { get => ChunkCommon.PlayableCharacter; set => ChunkCommon.PlayableCharacter = value; }
        public byte CurrentChapter { get => ChunkCommon.CurrentChapter; set => ChunkCommon.CurrentChapter = value; }
        public int[] SummonMateria { get => ChunkCommon.SummonMateria; set => ChunkCommon.SummonMateria = value; }
        public ChunkChapter[] Chapters { get; set; }

        public void ReimportChunks()
        {
            ChunkCommon = ReadChunk<ChunkCommon>(0, 0);
            for (var i = 0; i < ChapterCount; i++)
            {
                var chapter = ReadChunk<ChunkChapter>(1, i);
                if (chapter == null)
                    chapter = new ChunkChapter();

                Chapters[i] = chapter;
            }

            if (_EnableLastChapter)
                Chapters[ChapterCount] = ReadChunk<ChunkChapter>(3);
        }

        private Chunk GetChunk(int type, int index = -1)
        {
            var chunk = Chunks.FirstOrDefault(x =>
                x.Header.Unknown00 == type &&
                (index == -1 || x.Header.Unknown01 == index));
            if (chunk == null)
                return null;//throw new ArgumentException($"Unable to find the chunk ({type}, {index}).");

            if (chunk.Content == null)
                throw new ArgumentException($"The chunk ({type}, {index}) does not contain any data.");

            return chunk;
        }

        private T ReadChunk<T>(int type, int index = -1)
            where T : class
        {
            var chunk = GetChunk(type, index);
            if ((chunk?.Content?.RawData?.Length ?? 0) == 0)
                return default;

            using var stream = new MemoryStream(chunk.Content.RawData);
            return BinaryMapping.ReadObject<T>(stream);
        }

        private void WriteChunk<T>(T item, int type, int index = -1)
            where T : class
        {
            var chunk = GetChunk(type, index);
            using var stream = new MemoryStream(chunk.Content.RawData);
            BinaryMapping.WriteObject(stream, item);
        }

        public static bool IsValid(Stream stream)
        {
            stream.Position = 0x10;
            return stream.ReadByte() == 0x52 && stream.ReadByte() == 0x45 &&
                stream.ReadByte() == 0x53 && stream.ReadByte() == 0x44 &&
                stream.ReadByte() == 0x52 && stream.ReadByte() == 0x45 &&
                stream.ReadByte() == 0x53 && stream.ReadByte() == 0x44 &&
                stream.ReadByte() == 0x52 && stream.ReadByte() == 0x45 &&
                stream.ReadByte() == 0x53 && stream.ReadByte() == 0x44 &&
                stream.ReadByte() == 0x52 && stream.ReadByte() == 0x45 &&
                stream.ReadByte() == 0x53 && stream.ReadByte() == 0x44;
        }

        private static readonly Chunk.Type[] ReadPattern = new[]
        {
            Chunk.Type.RESD,
            Chunk.Type.LOSD,
            Chunk.Type.LOSD,
            Chunk.Type.LOSD,
            Chunk.Type.LOSD,
            Chunk.Type.LOSD,
            Chunk.Type.LOSD,
            Chunk.Type.LOSD,
            Chunk.Type.LOSD,
            Chunk.Type.LOSD,
            Chunk.Type.LOSD,
            Chunk.Type.LOSD,
            Chunk.Type.LOSD,
            Chunk.Type.LOSD,
            Chunk.Type.LOSD,
            Chunk.Type.LOSD,
            Chunk.Type.LOSD,
            Chunk.Type.LOSD,
            Chunk.Type.LOSD,
            Chunk.Type.RESD,
            Chunk.Type.LOSD,
            Chunk.Type.LOSD,
            Chunk.Type.LOSD,
            Chunk.Type.TAIL,
        };

        public static SaveFf7Remake Read(Stream stream)
        {
            stream.SetPosition(0);
            var chunks = ReadPattern
                .Select(x => Chunk.Read(stream, x))
                .ToList();
            return new SaveFf7Remake(chunks);
        }
    }
}
