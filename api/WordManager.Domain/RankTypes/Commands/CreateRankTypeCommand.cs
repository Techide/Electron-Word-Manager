using System;
using DP.CqsLite;
using WordManager.Common.DTO;

namespace WordManager.Domain
{
    public class CreateRankTypeCommand : ICommand
    {
        public CreateRankTypeCommand(RankTypeDTO dTO) => DTO = dTO ?? throw new ArgumentNullException(nameof(dTO));

        public RankTypeDTO DTO { get; }
    }
}
