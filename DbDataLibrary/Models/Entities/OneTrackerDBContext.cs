using System;
using DbDataLibrary.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DbDataLibrary.Models.Entities
{
    public partial class OneTrackerDBContext : DbContext
    {
        public OneTrackerDBContext()
        {

        }

        public OneTrackerDBContext(DbContextOptions<OneTrackerDBContext> options)
            : base(options)
        {
            
        }

        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<AppLogs> AppLogs { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<DevTeam > DevTeam { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Macro> Macro { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<ProjectFinalized> ProjectFinalized { get; set; }
        public virtual DbSet<ProjectPriority> ProjectPriority { get; set; }
        public virtual DbSet<ProjectStatus> ProjectStatus { get; set; }
        public virtual DbSet<ProjectType> ProjectType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var dBconnection = DBconnectionString.GetInstance();
                optionsBuilder.UseSqlServer(dBconnection.ConString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.Property(e => e.AddOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<AppLogs>(entity =>
            {
                entity.ToTable("App_Logs");

                entity.Property(e => e.AddOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdUser).HasColumnName("ID_User");

                entity.Property(e => e.LogDesc)
                    .IsRequired()
                    .HasColumnName("Log_Desc")
                    .HasColumnType("text");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.AppLogs)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK__App_Logs__ID_Use__5441852A");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.AddOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DepName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DevTeam >(entity =>
            {
                entity.HasIndex(e => e.Mail)
                    .HasName("UQ__DevTeam__2724B2D1B54B99D6")
                    .IsUnique();

                entity.Property(e => e.AddOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Mail)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Manager).HasMaxLength(100);

                entity.Property(e => e.TeamName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.DepartamentNavigation)
                    .WithMany(p => p.DevTeam)
                    .HasForeignKey(d => d.Departament)
                    .HasConstraintName("FK__DevTeam__Departa__440B1D61");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasIndex(e => e.Mail)
                    .HasName("UQ__Employee__2724B2D17523EC7F")
                    .IsUnique();

                entity.HasIndex(e => e.Phone)
                    .HasName("UQ__Employee__5C7E359EA1407F7D")
                    .IsUnique();

                entity.Property(e => e.AddOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EmpName)
                    .IsRequired()
                    .HasColumnName("Emp_Name")
                    .HasMaxLength(60);

                entity.Property(e => e.EmpSurname)
                    .IsRequired()
                    .HasColumnName("Emp_Surname")
                    .HasMaxLength(100);

                entity.Property(e => e.IdAdmin).HasColumnName("ID_Admin");

                entity.Property(e => e.IdEmployee)
                    .HasColumnName("ID_Employee")
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Mail)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Position)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.DepartamentNavigation)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.Departament)
                    .HasConstraintName("FK__Employee__Depart__49C3F6B7");

                entity.HasOne(d => d.IdAdminNavigation)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.IdAdmin)
                    .HasConstraintName("FK__Employee__ID_Adm__4BAC3F29");

                entity.HasOne(d => d.TeamNavigation)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.Team)
                    .HasConstraintName("FK__Employee__Team__4AB81AF0");
            });

            modelBuilder.Entity<Macro>(entity =>
            {
                entity.HasIndex(e => e.MacroName)
                    .HasName("UQ__Macro__B98DC2D53B9A66F0")
                    .IsUnique();

                entity.Property(e => e.AddOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.BusinessTeam)
                    .HasColumnName("Business_Team")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.GmasMacroId)
                    .HasColumnName("GMAS_MacroID")
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.GmasMacroWebPage)
                    .HasColumnName("GMAS_MacroWebPage")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MacroName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.MacroDeveloperNavigation)
                    .WithMany(p => p.Macro)
                    .HasForeignKey(d => d.MacroDeveloper)
                    .HasConstraintName("FK__Macro__AddOn__5165187F");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasIndex(e => e.ProjectName)
                    .HasName("UQ__Project__0BBE213852AFAF3E")
                    .IsUnique();

                entity.Property(e => e.Benefits).HasMaxLength(200);

                entity.Property(e => e.ContactPerson)
                    .IsRequired()
                    .HasColumnName("Contact_Person")
                    .HasMaxLength(80);

                entity.Property(e => e.DevTeam).HasColumnName("Dev_Team");

                entity.Property(e => e.DueDate)
                    .HasColumnName("Due_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.FteSavings).HasColumnName("FTE_Savings");

                entity.Property(e => e.MacroName).HasMaxLength(256);

                entity.Property(e => e.Piority)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectName)
                    .IsRequired()
                    .HasColumnName("Project_Name")
                    .HasMaxLength(200);

                entity.Property(e => e.ProjectStatus)
                    .IsRequired()
                    .HasColumnName("Project_Status")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectType)
                    .IsRequired()
                    .HasColumnName("Project_Type")
                    .HasMaxLength(60);

                entity.Property(e => e.RequestingTeam)
                    .IsRequired()
                    .HasColumnName("Requesting_Team")
                    .HasMaxLength(80);

                entity.Property(e => e.SubmitionTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.HasOne(d => d.DevTeamNavigation)
                    .WithMany(p => p.Project)
                    .HasForeignKey(d => d.DevTeam)
                    .HasConstraintName("FK__Project__Dev_Tea__693CA210");

                entity.HasOne(d => d.DeveloperNavigation)
                    .WithMany(p => p.Project)
                    .HasForeignKey(d => d.Developer)
                    .HasConstraintName("FK__Project__Develop__68487DD7");

                entity.HasOne(d => d.PiorityNavigation)
                    .WithMany(p => p.Project)
                    .HasForeignKey(d => d.Piority)
                    .HasConstraintName("FK__Project__Piority__6383C8BA");

                entity.HasOne(d => d.ProjectStatusNavigation)
                    .WithMany(p => p.Project)
                    .HasForeignKey(d => d.ProjectStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Project__Project__6754599E");

                entity.HasOne(d => d.ProjectTypeNavigation)
                    .WithMany(p => p.Project)
                    .HasForeignKey(d => d.ProjectType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Project__Project__66603565");
            });

            modelBuilder.Entity<ProjectFinalized>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Benefits).HasMaxLength(200);

                entity.Property(e => e.Comment).HasColumnType("text");

                entity.Property(e => e.ContactPerson)
                    .IsRequired()
                    .HasColumnName("Contact_Person")
                    .HasMaxLength(80);

                entity.Property(e => e.DevTeam).HasColumnName("Dev_Team");

                entity.Property(e => e.DoneTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DueDate)
                    .HasColumnName("Due_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.FteSavings).HasColumnName("FTE_Savings");

                entity.Property(e => e.IdProject).HasColumnName("ID_Project");

                entity.Property(e => e.MacroName).HasMaxLength(256);

                entity.Property(e => e.Piority)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectName)
                    .IsRequired()
                    .HasColumnName("Project_Name")
                    .HasMaxLength(200);

                entity.Property(e => e.ProjectStatus)
                    .IsRequired()
                    .HasColumnName("Project_Status")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectType)
                    .IsRequired()
                    .HasColumnName("Project_Type")
                    .HasMaxLength(60);

                entity.Property(e => e.RequestingTeam)
                    .IsRequired()
                    .HasColumnName("Requesting_Team")
                    .HasMaxLength(80);

                entity.Property(e => e.SubmitionTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<ProjectPriority>(entity =>
            {
                entity.HasKey(e => e.PriorityName)
                    .HasName("PK__ProjectP__346EBED783B4158F");

                entity.Property(e => e.PriorityName)
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProjectStatus>(entity =>
            {
                entity.HasKey(e => e.ProjectStatusName)
                    .HasName("PK__ProjectS__F2AF5BA02CB620B4");

                entity.Property(e => e.ProjectStatusName)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.AddOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<ProjectType>(entity =>
            {
                entity.HasKey(e => e.ProjectTypeName)
                    .HasName("PK__ProjectT__659139EBA3D8F6CB");

                entity.Property(e => e.ProjectTypeName).HasMaxLength(60);

                entity.Property(e => e.AddOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
