﻿namespace WordManager.Common.DTO
{
    public class WordModel : IModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public byte[] Pronounciation { get; set; }

        public string Description { get; set; }
    }
}
