using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MvcApplication1.Models 
{
    public class Context : DbContext
    {
         public Context(): base("myBd")
    {
 
    }
    public DbSet<Cipher> CipherTable { get; set; }
    public DbSet<MessageFromClient> DateMessage { get; set; }
    }
}