using System.Threading.Tasks;
using Wordmanager.Data;
using Wordmanager.Data.Entities;
using WordManager.Common.DTO;

namespace WordManager.Domain.WriteServices
{
    public class RankTypeWriteService : ABaseService, IWriteService<RankTypeModel, RankType>
    {
        public RankTypeWriteService(WordManagerContext context) : base(context) { }

        public RankType Create(RankTypeModel model)
        {
            var entity = new RankType
            {
                Name = model.Name,
                SortOrderId = model.SortOrderId
            };

            return CreateAsync(entity).Result;
        }

        private async Task<RankType> CreateAsync(RankType entity)
        {
            var change = _context.Add(entity);
            await _context.SaveChangesAsync();
            return change.Entity;
        }

        public bool Delete(dynamic id)
        {
            var entity = _context.RankTypes.Find(id);
            return DeleteAsync(entity).Result;
        }

        private async Task<bool> DeleteAsync(RankType entity)
        {
            _context.RankTypes.Remove(entity);
            var count = await _context.SaveChangesAsync();
            return count == 1;
        }

        public RankType Update(RankTypeModel model)
        {
            var entity = _context.RankTypes.Find(model.Id);
            entity.Name = model.Name;
            entity.SortOrderId = model.SortOrderId;

            return UpdateAsync(entity).Result;
        }

        private async Task<RankType> UpdateAsync(RankType entity)
        {
            var change = _context.Update(entity);
            await _context.SaveChangesAsync();
            return change.Entity;
        }
    }
}
