using System.Threading.Tasks;
using Wordmanager.Data;
using Wordmanager.Data.Entities;

namespace WordManager.Domain.WriteServices
{
    public class CurriculumWriteService : ABaseService<Curriculum>, IWriteService<Curriculum>
    {
        public CurriculumWriteService(WordManagerContext context) : base(context) { }

        public Curriculum Create(Curriculum entity)
        {
            return CreateAsync(entity).Result;
        }

        private async Task<Curriculum> CreateAsync(Curriculum entity)
        {
            var rankType = _context.RankTypes.Find(entity.RankTypeId);
            entity.RankType = rankType;
            var change = _context.Curricula.Add(entity);
            await _context.SaveChangesAsync();
            return change.Entity;
        }

        public bool Delete(Curriculum entity)
        {
            return DeleteAsync(entity).Result;
        }

        private async Task<bool> DeleteAsync(Curriculum entity)
        {
            var change = _context.Curricula.Remove(entity);
            var count = await _context.SaveChangesAsync();
            return count == 1;
        }

        public Curriculum Update(Curriculum entity)
        {
            return UpdateAsync(entity).Result;
        }

        private async Task<Curriculum> UpdateAsync(Curriculum entity)
        {
            var change = _context.Curricula.Update(entity);
            await _context.SaveChangesAsync();
            return change.Entity;

        }


    }
}
