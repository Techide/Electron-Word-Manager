using Wordmanager.Data;
using Wordmanager.Data.Entities;

namespace WordManager.Domain.WriteServices
{
    public class CurriculumWriteService : ABaseService<Curriculum>
    {
        public CurriculumWriteService(WordManagerContext context) : base(context) { }

        public override Curriculum Create(Curriculum entity)
        {
            throw new System.NotImplementedException();
        }

        public override bool Delete(Curriculum entity)
        {
            throw new System.NotImplementedException();
        }

        public override Curriculum Update(Curriculum entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
