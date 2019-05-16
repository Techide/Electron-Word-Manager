using System.Linq;
using System.Threading.Tasks;
using Wordmanager.Data;
using Wordmanager.Data.Entities;
using WordManager.Common.DTO;

namespace WordManager.Domain.WriteServices
{
    public class CurriculumWriteService : ABaseService, IWriteService<CurriculumModel, Curriculum>
    {
        public CurriculumWriteService(WordManagerContext context) : base(context) { }

        public Curriculum Create(CurriculumModel model)
        {
            var rankType = GetRankType(model);
            var entity = new Curriculum
            {
                Color = model.Color,
                Rank = model.Rank,
                RankType = rankType
            };

            return CreateAsync(entity).Result;
        }

        private async Task<Curriculum> CreateAsync(Curriculum entity)
        {
            var change = _context.Curricula.Add(entity);
            await _context.SaveChangesAsync();

            return change.Entity;
        }

        public bool Delete(dynamic id)
        {
            var entity = _context.Curricula.Find((long)id);
            return DeleteAsync(entity).Result;
        }

        private async Task<bool> DeleteAsync(Curriculum entity)
        {
            _context.Curricula.Remove(entity);
            var count = await _context.SaveChangesAsync();
            return count == 1;
        }

        public Curriculum Update(CurriculumModel model)
        {
            var rankType = GetRankType(model);
            var entity = _context.Curricula.Find(model.Id);
            entity.RankTypeId = rankType.Id;
            entity.Rank = model.Rank;
            entity.Color = model.Color;

            return UpdateAsync(entity).Result;
        }

        private async Task<Curriculum> UpdateAsync(Curriculum entity)
        {
            var change = _context.Curricula.Update(entity);
            await _context.SaveChangesAsync();

            return change.Entity;
        }

        private RankType GetRankType(CurriculumModel model)
        {
            return _context.RankTypes
                .AsParallel()
                .First(x => x.Name.ToLowerInvariant().Equals(model.RankType.ToLowerInvariant()));
        }

    }
}
