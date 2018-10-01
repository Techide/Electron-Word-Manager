using System;
using DP.CqsLite;
using WordManager.Common.DTO;

namespace WordManager.Domain
{
    public class UpdateRankTypeCommand : ICommand
    {
        public UpdateRankTypeCommand(RankTypeDTO rankType) => RankType = rankType ?? throw new ArgumentNullException(nameof(rankType));

        public RankTypeDTO RankType { get; }
    }
}
