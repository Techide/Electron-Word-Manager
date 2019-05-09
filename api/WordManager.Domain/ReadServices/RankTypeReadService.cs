using System.Linq;
using Wordmanager.Data;
using Wordmanager.Data.Entities;

namespace WordManager.Domain.ReadServices
{
    public class RankTypeReadService : ABaseService<RankType>
    {
        public RankTypeReadService(WordManagerContext context) : base(context) { }

        public IQueryable<RankType> ReadAll()
        {
            return _context.RankTypes;
        }

        public RankType ReadByName(string name)
        {
            var nameLower = name.ToLower();
            var result = _context.RankTypes.Where(x => x.Name.ToLower().Equals(nameLower)).SingleOrDefault();

            return result;
        }

    }
}
