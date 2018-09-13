using DP.CqsLite;

namespace WordManager.Domain
{
    public class GetRankTypeByNameQuery : IQuery<GetRankTypeByNameQueryResult>
    {
        public GetRankTypeByNameQuery(string name) => Name = name ?? throw new System.ArgumentNullException(nameof(name));

        public string Name { get; set; }
    }
}
