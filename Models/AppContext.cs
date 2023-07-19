using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Whatsapp_clone.Models.Group;
using Whatsapp_clone.Models.Message;
using Whatsapp_clone.Models.User;

namespace Whatsapp_clone.Models
{
    public class AppContext : DbContext
    {
        public AppContext() : base("Messenger.Com")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<AppContext>());
        }

        //User
        public DbSet<UserLogin> Logins { get; set; } 
        public DbSet<UserDetails> Details { get; set; }

        //Group
        public DbSet<GroupDetails> GroupDetails { get; set; }
        public DbSet<GroupMember> Members { get; set; }

        //Message
        public DbSet<MessageDetails> Messages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MessageDetails>()
                .HasRequired(m => m.Sender)
                .WithMany()
                .HasForeignKey(m => m.SenderId)
                .WillCascadeOnDelete(false);

            // Configure other relationships and entities here
            base.OnModelCreating(modelBuilder);
        }
    }
}