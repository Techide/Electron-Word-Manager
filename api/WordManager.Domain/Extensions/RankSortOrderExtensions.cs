using System;
using Wordmanager.Data.Models.Entities;
using WordManager.Common.DTO;

namespace WordManager.Domain.Extensions
{
    public static class RankSortOrderExtensions
    {
        public static Func<RankSortOrder, RankSortOrderDTO> ToDTO = x => new RankSortOrderDTO
        {
            Id = x.Id,
            Direction = x.Direction,
            Value = x.Value
        };
    }
}
