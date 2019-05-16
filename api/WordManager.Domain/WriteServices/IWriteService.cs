using Wordmanager.Data.Entities;
using WordManager.Common.DTO;

namespace WordManager.Domain.WriteServices
{
    public interface IWriteService<Tmodel, Tentity> where Tentity : IEntity where Tmodel : IModel
    {
        Tentity Create(Tmodel model);
        bool Delete(dynamic id);
        Tentity Update(Tmodel model);
    }
}
