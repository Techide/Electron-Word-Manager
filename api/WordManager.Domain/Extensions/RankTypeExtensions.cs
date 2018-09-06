using System;
using System.Linq.Expressions;
using Wordmanager.Data.Models.Entities;
using WordManager.Common.DTO;

namespace WordManager.Domain.Extensions
{
    public static class RankTypeExtensions
    {
        public static Expression<Func<RankType, RankTypeDTO>> ToDTO = x => new RankTypeDTO
        {
            Id = x.Id,
            Name = x.Name
        };
    }
}
