using System.Collections.Generic;
using System.Linq;
using WordManager.Common.DTO;

namespace WordManager.Domain
{
    public class GetPartsFromCollectionIdQueryResult
    {
        public IEnumerable<PartDTO> Data;
    }
}
