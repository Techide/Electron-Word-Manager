using Wordmanager.Data;
using Wordmanager.Data.Entities;

namespace WordManager.Domain.WriteServices
{
    public class RankTypeWriteService : ABaseService<RankType>, IWriteService<RankType>
    {
        public RankTypeWriteService(WordManagerContext context) : base(context) { }

        public RankType Create(RankType entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(RankType entity)
        {
            throw new System.NotImplementedException();
        }

        public RankType Update(RankType entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
