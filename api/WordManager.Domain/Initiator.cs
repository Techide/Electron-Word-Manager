using System;
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
                try
                {
                    db.Database.Migrate();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
        }
    }
}
