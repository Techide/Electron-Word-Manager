using DP.CqsLite;

namespace WordManager.Domain
{
    public class GetPartsFromCollectionIdQuery : IQuery<GetPartsFromCollectionIdQueryResult>
    {
        public GetPartsFromCollectionIdQuery(long id)
        {
            Id = id;
        }

        public long Id { get; private set; }
    }
}
