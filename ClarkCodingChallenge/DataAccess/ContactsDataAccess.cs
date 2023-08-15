/* DB implementation using EF Core
 * Supported Database Providors: 
 * https://learn.microsoft.com/en-us/ef/core/providers/?tabs=dotnet-core-cli
 */

using Microsoft.EntityFrameworkCore;
using ClarkCodingChallenge.Models;

namespace ClarkCodingChallenge.DataAccess
{
    public class ContactsDataAccess : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }

        public ContactsDataAccess(DbContextOptions<ContactsDataAccess> options)
            :base(options)
        {

        }
    }
}
