using System;
using Wordmanager.Data.Models.Entities;
using WordManager.Common.DTO;

namespace WordManager.Domain.Extensions
{
    public static class WordExtensions
    {
        public static Func<Word, WordDTO> ToDTO = x => new WordDTO {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description?.Word?.Name,
            Pronounciation = x.Pronounciation
        };
    }
}
