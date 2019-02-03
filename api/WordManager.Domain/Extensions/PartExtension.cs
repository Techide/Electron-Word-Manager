using System;
using System.Linq;
using Wordmanager.Data.Models.Entities;
using WordManager.Common.DTO;

namespace WordManager.Domain.Extensions
{
    public static class PartExtension
    {

        public static Func<Part, PartDTO> ToDTO = x => new PartDTO
        {
            Id = x.Id,
            Name = x.Category.Name,
            CategoryId = x.Category.Id,
            ParentPartId = x.ParentPartId,
            Words = x.Words?.Select(WordExtensions.ToDTO),
            SubParts = x.SubParts?.Select(ToDTO)
        };

    }
}
