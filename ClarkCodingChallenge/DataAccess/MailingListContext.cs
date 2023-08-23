/* DB implementation using EF Core
 * Supported Database Providors: 
 * https://learn.microsoft.com/en-us/ef/core/providers/?tabs=dotnet-core-cli
 */

/* This DataAccess namespace is for services relating to data retrieval.
 *
 */

using Microsoft.EntityFrameworkCore;
using MailingList.Models;

namespace MailingList.DataAccess
{
    /* mailing list context is derived drop DbContext and creates the database context for the web app */
    public class MailingListContext : DbContext
    {
        // this is the variable for the Contacts table
        // it contains all entries for the contact entity
        public DbSet<Contact> Contacts { get; set; }

        // constructor for the context class
        public MailingListContext(DbContextOptions<MailingListContext> options)
            : base(options)
        {

        }
    }
}
