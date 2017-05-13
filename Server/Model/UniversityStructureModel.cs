namespace Server
{
    using System.Data.Entity;

    public class UniversityStructureModel : DbContext
    {
        public UniversityStructureModel()
            : base("name=UniversityStructureModel")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teacher>()
                .HasMany((Teacher teacher) => teacher.Disciplines)
                .WithMany((Discipline discipline) => discipline.Teachers);
        }

        public virtual DbSet<Faculty> Faculties { get; set; }
        public virtual DbSet<Chair> Chairs { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<Discipline> Disciplines { get; set; }
    }
}