using System.Threading.Tasks;
using Wordmanager.Data;
using Wordmanager.Data.Entities;
using WordManager.Common.DTO;

namespace WordManager.Domain.WriteServices
{
    public class PartWriteService : ABaseService, IWriteService<PartModel, Part>
    {
        public PartWriteService(WordManagerContext context) : base(context) { }

        public Part Create(PartModel model)
        {
            var entity = new Part
            {
                CategoryId = model.CategoryId,
                CurriculumId = model.CurriculumId,
                ParentPartId = model.ParentPartId,
            };

            return CreateAsync(entity).Result;
        }

        private async Task<Part> CreateAsync(Part entity)
        {
            var change = _context.Parts.Add(entity);
            await _context.SaveChangesAsync();
            return change.Entity;
        }

        public bool Delete(dynamic id)
        {
            var entity = _context.Parts.Find(id);
            return DeleteAsync(entity).Result;
        }

        private async Task<bool> DeleteAsync(Part entity)
        {
            _context.Remove(entity);
            var count = await _context.SaveChangesAsync();
            return count == 1;
        }

        public Part Update(PartModel model)
        {
            throw new System.NotImplementedException();
        }
    }
}
