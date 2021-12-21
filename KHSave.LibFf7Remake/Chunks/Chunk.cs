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

using System.IO;
using Xe.BinaryMapper;

namespace KHSave.LibFf7Remake.Chunks
{
    public class ChunkHeader
    {
        [Data] public byte Unknown00 { get; set; }
        [Data] public byte Unknown01 { get; set; }
        [Data] public byte Unknown02 { get; set; }
        [Data] public byte Unused03 { get; set; }
        [Data] public int NextChunkOffset { get; set; }
        [Data] public int Unused08 { get; set; }
        [Data] public int Unused0c { get; set; }

        public bool IsTail =>
            NextChunkOffset == 0 &&
            Unknown00 == 4 &&
            Unknown01 == 0 &&
            Unknown02 == 1;
    }

    public class ChunkContent
    {
        [Data(Count = 0x10)] public string MagicCode { get; set; }
        [Data] public int Unknown10 { get; set; }
        [Data] public int ChunkLength { get; set; }
        public byte[] RawData { get; set; }
    }

    public class Chunk
    {
        public enum Type
        {
            RESD = 0x0004ffe8,
            LOSD = 0x660e8,
            TAIL = 0
        }

        public const int HeaderLength = 0x10;
        public const int ContentHeaderLength = 0x18;
        public const int TotalHeaderLength = HeaderLength + ContentHeaderLength;

        public ChunkHeader Header { get; }
        public ChunkContent Content { get; }

        public bool IsLastChunk => Header.IsTail;
        public bool IsEmpty => Content.ChunkLength == 0;

        public Chunk(ChunkHeader header, ChunkContent content)
        {
            Header = header;
            Content = content;
        }

        public static Chunk Read(Stream stream, Type type)
        {
            var header = BinaryMapping.ReadObject<ChunkHeader>(stream);
            if (header.IsTail)
                return new Chunk(header, null);

            var content = BinaryMapping.ReadObject<ChunkContent>(stream);
            var expectedSize = (int)type;
            content.RawData = stream.ReadBytes(expectedSize);

            if (header.NextChunkOffset > 0)
                stream.Position = header.NextChunkOffset;

            return new Chunk(header, content);
        }

        public void Write(Stream stream)
        {
            BinaryMapping.WriteObject(stream, Header);
            if (!IsLastChunk)
            {
                BinaryMapping.WriteObject(stream, Content);
                stream.Write(Content.RawData, 0, Content.RawData.Length);
            }
        }

        public override string ToString()
        {
            var h = $"H({Header.Unknown00:X02}, {Header.Unknown01:X02}, {Header.Unknown02:X02})";
            if (IsEmpty)
                return $"{h} EMPTY";
            if (!IsLastChunk)
                return $"{h} C({Content.MagicCode}, {Content.Unknown10:X}";
            else
                return $"{h} END";
        }
    }
}
