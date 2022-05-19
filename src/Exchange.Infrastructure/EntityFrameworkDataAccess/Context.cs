using Microsoft.EntityFrameworkCore;



namespace Exchange.Infrastructure.EntityFrameworkDataAccess
{
    public partial class Context : DbContext
    {
        public Context()
        { }
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public virtual DbSet<Entities.Currency> Currencies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //            if (!optionsBuilder.IsConfigured)
            //            {
            ////warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            //                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=BDPRUEBA;Trusted_Connection=True;");
            //            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entities.Currency>(entity =>
            {
                entity.ToTable("currencies");
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
