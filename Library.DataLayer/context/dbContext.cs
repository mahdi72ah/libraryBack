using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using library.DataLayer.Entities.menu;
using Microsoft.EntityFrameworkCore;

namespace library.DataLayer.context
{
    public class dbContext : DbContext
    {
        #region constractor
        public dbContext(DbContextOptions<dbContext> options) : base(options)
        {

        }
        #endregion


        #region DB Sets

        public DbSet<menu> menu { get; set; }

        #endregion




        #region disable cascading delete in database

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cascades = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascades)
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelBuilder);
        }

        #endregion
    }
}
