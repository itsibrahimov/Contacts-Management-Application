using Contacts_Management_Application.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Contacts_Management_Application.Models.Context
{
    public class ContactContext : DbContext
    {
        public ContactContext() : base("Server=RIRI;Database=ContactDb;Trusted_Connection=True;")
        {
             
        }
        public DbSet<Persons> Persons { get; set; }
    }
}