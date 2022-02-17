namespace SBC.Data
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using SBC.Data.Common.Models;
    using SBC.Data.Models;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        private static readonly MethodInfo SetIsDeletedQueryFilterMethod =
            typeof(ApplicationDbContext).GetMethod(
                nameof(SetIsDeletedQueryFilter),
                BindingFlags.NonPublic | BindingFlags.Static);

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Setting> Settings { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<CategoryCoach> CategoryCoaches { get; set; }

        public DbSet<Coach> Coaches { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<CourseLecture> CourseLectures { get; set; }

        public DbSet<Language> Languages { get; set; }

        public DbSet<LanguageCoach> LanguageCoaches { get; set; }

        public DbSet<Lecture> Lectures { get; set; }

        public DbSet<Request> Requests { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<UserCoachSession> UserCoachSessions { get; set; }

        public DbSet<UserCourse> UserCourses { get; set; }

        public DbSet<CompanyCourse> CompaniesCourses { get; set; }

        public DbSet<CompanyCoach> CompanyCoaches { get; set; }

        public override int SaveChanges() => this.SaveChanges(true);

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
            this.SaveChangesAsync(true, cancellationToken);

        public override Task<int> SaveChangesAsync(
            bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default)
        {
            this.ApplyAuditInfoRules();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Needed for Identity models configuration
            base.OnModelCreating(builder);

            this.ConfigureUserIdentityRelations(builder);

            EntityIndexesConfiguration.Configure(builder);

            var entityTypes = builder.Model.GetEntityTypes().ToList();

            // Set global query filter for not deleted entities only
            var deletableEntityTypes = entityTypes
                .Where(et => et.ClrType != null && typeof(IDeletableEntity).IsAssignableFrom(et.ClrType));
            foreach (var deletableEntityType in deletableEntityTypes)
            {
                var method = SetIsDeletedQueryFilterMethod.MakeGenericMethod(deletableEntityType.ClrType);
                method.Invoke(null, new object[] { builder });
            }

            // Disable cascade delete
            var foreignKeys = entityTypes
                .SelectMany(e => e.GetForeignKeys().Where(f => f.DeleteBehavior == DeleteBehavior.Cascade));
            foreach (var foreignKey in foreignKeys)
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }

            builder
                .Entity<CategoryCoach>()
                .HasKey(c => new { c.CategoryId, c.CoachId });

            builder
                .Entity<CourseLecture>()
                .HasKey(c => new { c.CourseId, c.LectureId });

            builder
                .Entity<CompanyCourse>()
                .HasKey(c => new { c.CompanyId, c.CourseId });

            builder
                .Entity<CompanyCoach>()
                .HasKey(c => new { c.CompanyId, c.CoachId });

            builder
                .Entity<LanguageCoach>()
                .HasKey(l => new { l.LanguageId, l.CoachId });

            builder
                .Entity<UserCoachSession>()
                .HasKey(u => new { u.UserId, u.CoachId });

            builder
                .Entity<UserCourse>()
                .HasKey(u => new { u.UserId, u.CourseId });
        }

        private static void SetIsDeletedQueryFilter<T>(ModelBuilder builder)
            where T : class, IDeletableEntity
        {
            builder.Entity<T>().HasQueryFilter(e => !e.IsDeleted);
        }

        // Applies configurations
        private void ConfigureUserIdentityRelations(ModelBuilder builder)
             => builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

        private void ApplyAuditInfoRules()
        {
            var changedEntries = this.ChangeTracker
                .Entries()
                .Where(e =>
                    e.Entity is IAuditInfo &&
                    (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in changedEntries)
            {
                var entity = (IAuditInfo)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default)
                {
                    entity.CreatedOn = DateTime.UtcNow;
                }
                else
                {
                    entity.ModifiedOn = DateTime.UtcNow;
                }
            }
        }
    }
}
