using System;
using System.Linq.Expressions;
using Wordmanager.Data.Models.Entities;
using WordManager.Common.DTO;

namespace WordManager.Domain.Extensions
{
    public static class CurriculumExtensions
    {
        public static Expression<Func<Curriculum, CurriculumDTO>> ToDTO = x => new CurriculumDTO
        {
            Id = x.Id,
            Color = x.Color,
            Rank = x.Rank,
            RankType = x.RankType.Name
        };
    }
}
