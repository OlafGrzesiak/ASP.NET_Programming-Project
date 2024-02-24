using Data.Entities;
using Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.Extensions.DependencyInjection;

namespace Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<ContactEntity> Contacts { get; set; }
        public DbSet<OrganizationEntity> Organizations { get; set; }
        public DbSet<PostEntity> Posts { get; set; }
        public DbSet<GroupEntity> Groups { get; set; }


        private string DbPath { get; set; }

        public AppDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "olaf.db");
        }
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<AppDbContext>();
                var userManager = scope.ServiceProvider.GetService<UserManager<IdentityUser>>();
            }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
            options.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PostEntity>()
                .HasOne(b => b.Group)
                .WithMany(l => l.posts)
                .HasForeignKey(b => b.GroupId);

            modelBuilder.Entity<BorrowEntity>()
                 .HasOne(b => b.User)
                 .WithMany()
                 .HasForeignKey(b => b.UserId);

            modelBuilder.Entity<BorrowEntity>()
                .HasOne(b => b.Book)
                .WithMany()
                .HasForeignKey(b => b.BookId);


            base.OnModelCreating(modelBuilder);
            PasswordHasher<IdentityUser> ph = new PasswordHasher<IdentityUser>();
            var user = new IdentityUser()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "olaf@test.pl",
                NormalizedUserName = "OLAF@TEST.PL",
                Email = "olaf@test.pl",
                NormalizedEmail = "OLAF@TEST.PL",
                EmailConfirmed = true,
            };
            user.PasswordHash = ph.HashPassword(user, "olaf1234");
            modelBuilder.Entity<IdentityUser>()
                .HasData(
                    user
                );


            var adminRole = new IdentityRole()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "admin",
                NormalizedName = "ADMIN",
            };
            var userRole = new IdentityRole
            {
                Id = Guid.NewGuid().ToString(),
                Name = "user",
                NormalizedName = "USER"
            };

            modelBuilder.Entity<IdentityRole>()
                .HasData(
                adminRole,
                userRole
                );
            PasswordHasher<IdentityUser> hasher = new PasswordHasher<IdentityUser>();

            // Utworzenie użytkowników
            var user1 = new IdentityUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "jan@przyklad.pl",
                Email = "jan@przyklad.pl",
                NormalizedUserName = "JAN@PRZYKLAD.PL",
                NormalizedEmail = "JAN@PRZYKLAD.PL",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "hasloJan123!")
            };

            var user2 = new IdentityUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "anna@przyklad.pl",
                Email = "anna@przyklad.pl",
                NormalizedUserName = "ANNA@PRZYKLAD.PL",
                NormalizedEmail = "ANNA@PRZYKLAD.PL",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "hasloAnna123!")
            };

            var user3 = new IdentityUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "kasia@przyklad.pl",
                Email = "kasia@przyklad.pl",
                NormalizedUserName = "KASIA@PRZYKLAD.PL",
                NormalizedEmail = "KASIA@PRZYKLAD.PL",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "hasloKasia123!")
            };

            modelBuilder.Entity<IdentityUser>().HasData(
                user1, user2, user3
            );

            // Pobierz ID roli "user"
            var userRoleId = modelBuilder.Model.FindEntityType(typeof(IdentityRole))
                                    .GetSeedData().First(r => r["Name"].Equals("user"))["Id"].ToString();

            // Przypisanie roli "user" dla użytkowników
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { UserId = user1.Id, RoleId = userRoleId },
                new IdentityUserRole<string> { UserId = user2.Id, RoleId = userRoleId },
                new IdentityUserRole<string> { UserId = user3.Id, RoleId = userRoleId }
            );
            adminRole.ConcurrencyStamp = adminRole.Id;

            modelBuilder.Entity<IdentityUserRole<string>>()
                .HasData(
                    new IdentityUserRole<string>()
                    {
                        RoleId = adminRole.Id,
                        UserId = user.Id
                    }
                );

            modelBuilder.Entity<ContactEntity>()
                .HasOne(c => c.Ogranization)
                .WithMany(o => o.Contacts)
                .HasForeignKey(c => c.OrganizationId);


            modelBuilder.Entity<OrganizationEntity>()
                .HasData(
                    new OrganizationEntity()
                    {
                        Id = 1,
                        Name = "WSEI",
                        Description = "Uczelnia",
                    },
                    new OrganizationEntity()
                    {
                        Id = 2,
                        Name = "PJTAK",
                        Description = "Uczelnia"
                    },
                    new OrganizationEntity()
                    {
                        Id = 3,
                        Name = "ABB",
                        Description = "Korporacja"
                    },
                    new OrganizationEntity()
                    {
                        Id = 4,
                        Name = "Technikum Informatyczne w Poznaniu",
                        Description = "Szkoła średnia"
                    }


                );

            modelBuilder.Entity<GroupEntity>()
    .HasData(
        new GroupEntity()
        {
            Id = 1,
            Name = "Developers.NET",
            Description = "Grupa dla programistów specjalizujących się w technologii .NET",
        },
        new GroupEntity()
        {
            Id = 2,
            Name = "Java Masterclass",
            Description = "Społeczność dla zaawansowanych programistów Java, wymieniających się doświadczeniami i najlepszymi praktykami",
        },
        new GroupEntity()
        {
            Id = 3,
            Name = "Frontend Wizards",
            Description = "Grupa dla twórców stron internetowych i aplikacji webowych, skupiająca się na HTML, CSS i JavaScript",
        },
        new GroupEntity()
        {
            Id = 4,
            Name = "AI Innovators",
            Description = "Grupa dla entuzjastów sztucznej inteligencji i uczenia maszynowego, dzielących się wiedzą i projektami",
        }
    );

            modelBuilder.Entity<PostEntity>().HasData(
     new PostEntity()
     {
         Id = 1,
         Content = "Właśnie zakończyłem pracę nad moją pierwszą aplikacją w React! Projekt ten nauczył mnie wielu zaawansowanych koncepcji, w tym zarządzania stanem i komunikacji między komponentami.",
         Author = "Jan Kowalski",
         PublicationDate = DateTime.Now,
         Tags = "React, JavaScript, Frontend",
         Comments = "Gratulacje! Bardzo imponujące, szczególnie zarządzanie stanem.",
         Created = DateTime.Now,
         GroupId = 2 
     }
 );
            modelBuilder.Entity<PostEntity>().HasData(
                new PostEntity()
                {
                    Id = 2,
                    Content = "Dzielić się chcę przemyśleniami na temat wykorzystania sztucznej inteligencji do automatyzacji testów oprogramowania. AI może znacząco przyspieszyć proces tworzenia testów, oferując jednocześnie wyższą precyzję.",
                    Author = "Ewa Nowak",
                    PublicationDate = DateTime.Now,
                    Tags = "AI, Testing, Automatyzacja",
                    Comments = "Bardzo interesujące! Czy masz jakieś przykłady narzędzi AI, które można by tutaj zastosować?",
                    Created = DateTime.Now,
                    GroupId = 4 
                }
            );

            modelBuilder.Entity<PostEntity>().HasData(
    new PostEntity()
    {
        Id = 3,
        Content = "Odkryłem ostatnio fascynujące zastosowania Pythona w analizie danych. Użycie bibliotek takich jak Pandas i NumPy może znacząco usprawnić przetwarzanie i analizę dużych zbiorów danych.",
        Author = "Michał Anioł",
        PublicationDate = DateTime.Now,
        Tags = "Python, Data Science, Pandas, NumPy",
        Comments = "Python to naprawdę potężne narzędzie! Używałem Pandas w moim ostatnim projekcie i oszczędziło mi to mnóstwo czasu.",
        Created = DateTime.Now,
        GroupId = 4 
    }
);
            modelBuilder.Entity<PostEntity>().HasData(
                new PostEntity()
                {
                    Id = 4,
                    Content = "Zastanawiam się nad najlepszymi praktykami w zakresie zabezpieczania aplikacji webowych. Czy ktoś mógłby podzielić się swoimi doświadczeniami w implementacji HTTPS i używaniu nagłówków bezpieczeństwa?",
                    Author = "Agata Siek",
                    PublicationDate = DateTime.Now,
                    Tags = "Bezpieczeństwo, HTTPS, WebDev",
                    Comments = "Zdecydowanie polecam zapoznać się z Content Security Policy (CSP). Pomogło to mojej aplikacji uniknąć wielu ataków XSS.",
                    Created = DateTime.Now,
                    GroupId = 3
                }
            );
            modelBuilder.Entity<PostEntity>().HasData(
                new PostEntity()
                {
                    Id = 5,
                    Content = "Jakie są wasze doświadczenia z mikroserwisami w .NET Core? Szukam wskazówek dotyczących najlepszych praktyk i potencjalnych pułapek.",
                    Author = "Tomasz Beta",
                    PublicationDate = DateTime.Now,
                    Tags = ".NET Core, Mikroserwisy, Architektura",
                    Comments = "Pamiętaj o odpowiednim planowaniu i dokumentacji twojej architektury mikroserwisów. Debugowanie może być wyzwaniem bez tego!",
                    Created = DateTime.Now,
                    GroupId = 1 
                }
            );
            modelBuilder.Entity<PostEntity>().HasData(
                new PostEntity()
                {
                    Id = 6,
                    Content = "Rozpoczynam naukę programowania w Java i szukam rekomendacji na pierwsze projekty. Co polecacie dla początkującego?",
                    Author = "Kasia Lato",
                    PublicationDate = DateTime.Now,
                    Tags = "Java, Nauka, Projekty dla początkujących",
                    Comments = "Może zacznij od prostego projektu kalkulatora lub aplikacji do zarządzania zadaniami. To dobre projekty, by poćwiczyć podstawowe konstrukty języka.",
                    Created = DateTime.Now,
                    GroupId = 2 
                }
            );


            //dodanie kontaktów
            modelBuilder.Entity<ContactEntity>().HasData(
                new ContactEntity() { Id = 1, Name = "Adam", Email = "adam@wsei.edu.pl", Phone = "127813268163", Birth = new DateTime(2000, 10, 10), Priority = 1, Created = DateTime.Now, OrganizationId = 1 },
                new ContactEntity() { Id = 2, Name = "Ewa", Email = "ewa@wsei.edu.pl", Phone = "293443823478", Birth = new DateTime(1999, 8, 10), Priority = 2, Created = DateTime.Now, OrganizationId = 3 }
            );
            //zwiazek między klasą a encją, złączenie encji i pola klasy 
            modelBuilder.Entity<OrganizationEntity>()
                .OwnsOne(o => o.Adress)
                .HasData(
                new { OrganizationEntityId = 1, City = "Kraków", Street = "Św. Filipa 17", PostalCode = "31-150" },
                new { OrganizationEntityId = 2, City = "Warszawa", Street = "Aleje Jerozolimskie 120", PostalCode = "00-001" },
                new { OrganizationEntityId = 3, City = "Gdańsk", Street = "ul. Długa 10", PostalCode = "80-001" },
                new { OrganizationEntityId = 4, City = "Poznań", Street = "Stary Rynek 1", PostalCode = "61-001" }

               );
        }



        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
                {
                    if (entry.Entity is ContactEntity contact && contact.Created == default)
                    {
                        contact.Created = DateTime.Now;
                    }
                    else if (entry.Entity is PostEntity book && book.Created == default)
                    {
                        book.Created = DateTime.Now;
                    }
                }
            }

            return base.SaveChanges();
        }
    }
}