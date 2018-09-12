using Microsoft.EntityFrameworkCore;
using Wordmanager.Data.Models;

namespace WordManager.Domain
{
    public static class DomainInitiator
    {

        public static void Initiate()
        {
            using (var db = new WordManagerContext())
            {
                db.Database.Migrate();
            }
        }
    }
}
