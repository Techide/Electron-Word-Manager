using System;
using System.Linq.Expressions;
using Wordmanager.Data.Models.Entities;
using WordManager.Common.DTO;

namespace WordManager.Domain.Extensions
{
    public static class CurriculumExtensions
    {
        public static Expression<Func<Curriculum, CurriculumDTO>> ToDTOExpression = x => _toDTOFunc(x);

        public static CurriculumDTO ToDTO(this Curriculum x) => _toDTOFunc(x);

        private static Func<Curriculum, CurriculumDTO> _toDTOFunc = x => new CurriculumDTO
        {
            Id = x.Id,
            Color = x.Color,
            Rank = x.Rank,
            RankType = x.RankType.Name
        };

    }
}
