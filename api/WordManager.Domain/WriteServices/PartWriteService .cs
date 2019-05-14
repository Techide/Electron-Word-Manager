using Wordmanager.Data;
using Wordmanager.Data.Entities;

namespace WordManager.Domain.WriteServices
{
    public class PartWriteService : ABaseService<Part>, IWriteService<Part>
    {
        public PartWriteService(WordManagerContext context) : base(context) { }

        public Part Create(Part entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(Part entity)
        {
            throw new System.NotImplementedException();
        }

        public Part Update(Part entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
