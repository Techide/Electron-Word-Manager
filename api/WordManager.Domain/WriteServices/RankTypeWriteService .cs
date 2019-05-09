using Wordmanager.Data;
using Wordmanager.Data.Entities;

namespace WordManager.Domain.WriteServices
{
    public class RankTypeWriteService : ABaseService<RankType>
    {
        public RankTypeWriteService(WordManagerContext context) : base(context) { }

        public override RankType Create(RankType entity)
        {
            throw new System.NotImplementedException();
        }

        public override bool Delete(RankType entity)
        {
            throw new System.NotImplementedException();
        }

        public override RankType Update(RankType entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
