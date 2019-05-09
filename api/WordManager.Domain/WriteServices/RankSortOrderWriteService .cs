using Wordmanager.Data;
using Wordmanager.Data.Entities;

namespace WordManager.Domain.WriteServices
{
    public class RankSortOrderWriteService : ABaseService<RankSortOrder>
    {
        public RankSortOrderWriteService(WordManagerContext context) : base(context) { }

        public override RankSortOrder Create(RankSortOrder entity)
        {
            throw new System.NotImplementedException();
        }

        public override bool Delete(RankSortOrder entity)
        {
            throw new System.NotImplementedException();
        }

        public override RankSortOrder Update(RankSortOrder entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
