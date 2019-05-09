using Wordmanager.Data;
using Wordmanager.Data.Entities;

namespace WordManager.Domain.WriteServices
{
    public class PartWriteService : ABaseService<Part>
    {
        public PartWriteService(WordManagerContext context) : base(context) { }

        public override Part Create(Part entity)
        {
            throw new System.NotImplementedException();
        }

        public override bool Delete(Part entity)
        {
            throw new System.NotImplementedException();
        }

        public override Part Update(Part entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
