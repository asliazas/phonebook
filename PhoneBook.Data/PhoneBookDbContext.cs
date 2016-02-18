using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration.Conventions;
using PhoneBook.Business.Entities;

namespace PhoneBook.Data
{
    public class PhoneBookDbContext : DbContext
    {
        public PhoneBookDbContext() : base("PhoneBookEntities")
        {
            
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<ContactType> ContactTypes { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Phone> Phones { get; set; }

        public virtual void Commit()
        {
            SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // Person
            modelBuilder.Entity<Person>()
                .HasKey(e => e.Id)
                .Ignore(e => e.EntityId)
                .ToTable("Persons");
                
            modelBuilder.Entity<Person>()
                .Property(e => e.Name).HasMaxLength(450).HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute { IsUnique = false }));
            modelBuilder.Entity<Person>()
                .Property(e => e.Surname).HasMaxLength(450).HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute { IsUnique = false }));

            // ContactType
            modelBuilder.Entity<ContactType>()
                .HasKey(e => e.Id)
                .Ignore(e => e.EntityId)
                .ToTable("ContactTypes");

            // Email
            modelBuilder.Entity<Email>()
                .HasKey(e => e.Id)
                .Ignore(e => e.EntityId)
                .ToTable("Emails")
                .HasRequired(e => e.Person).WithMany(e => e.Emails).WillCascadeOnDelete(true);

            modelBuilder.Entity<Email>().HasOptional(e => e.ContactType);

            modelBuilder.Entity<Email>()
                .Property(e => e.EmailAddress).HasMaxLength(450).HasColumnAnnotation(
                IndexAnnotation.AnnotationName,
                new IndexAnnotation(new IndexAttribute { IsUnique = false }));



            // Phone
            modelBuilder.Entity<Phone>()
                .HasKey(e => e.Id)
                .Ignore(e => e.EntityId)
                .ToTable("Phones")
                .HasRequired(e => e.Person).WithMany(e => e.Phones).WillCascadeOnDelete(true); ;

            modelBuilder.Entity<Phone>().HasOptional(e => e.ContactType);

            modelBuilder.Entity<Phone>()
                .Property(e => e.PhoneNumber).HasMaxLength(450).HasColumnAnnotation(
                IndexAnnotation.AnnotationName,
                new IndexAnnotation(new IndexAttribute { IsUnique = false }));
        }
    }
}
