using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class NameOfMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "organizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Adress_City = table.Column<string>(type: "TEXT", nullable: true),
                    Adress_Street = table.Column<string>(type: "TEXT", nullable: true),
                    Adress_PostalCode = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_organizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Content = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Author = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    publication_date = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Tags = table.Column<string>(type: "TEXT", nullable: false),
                    Comments = table.Column<string>(type: "TEXT", nullable: false),
                    GroupId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_posts_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "TEXT", maxLength: 12, nullable: true),
                    birth_date = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Priority = table.Column<int>(type: "INTEGER", nullable: false),
                    OrganizationId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_contacts_organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "organizations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Borrows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BorrowDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    BookId = table.Column<int>(type: "INTEGER", nullable: false),
                    LibraryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Borrows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Borrows_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Borrows_Groups_LibraryId",
                        column: x => x.LibraryId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Borrows_posts_BookId",
                        column: x => x.BookId,
                        principalTable: "posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5104e6e9-890d-49cf-9b69-425c60148667", "eca45199-36da-41e7-ab3f-424c7eec1d45", "user", "USER" },
                    { "deed65f5-77e1-497d-9d0d-0ef73d812468", "deed65f5-77e1-497d-9d0d-0ef73d812468", "admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "4b18047d-7a6c-4c50-9e02-a48c76d117d3", 0, "3fd7e91e-54b6-40a7-a755-31e80a5a04a9", "kasia@przyklad.pl", true, false, null, "KASIA@PRZYKLAD.PL", "KASIA@PRZYKLAD.PL", "AQAAAAEAACcQAAAAEBHCaAfQeoFERBz+hAU2rMyRq67ihR1BDUkXULdj1y5KYuzh8f5Ch1x+0VNyruJFDg==", null, false, "56e6eb5d-8472-42b2-9fd0-01b5adf1beb1", false, "kasia@przyklad.pl" },
                    { "924ee0f6-6e57-484e-9279-0ea5deeb8cf0", 0, "19a4f53f-7851-49e4-9a7f-48d7fc95092b", "jan@przyklad.pl", true, false, null, "JAN@PRZYKLAD.PL", "JAN@PRZYKLAD.PL", "AQAAAAEAACcQAAAAEB1xkPwIke7X+XjVzEoBn6RSyKi+HKKS8iP9c10J5Pd116M+IdYzZoFYyA/idY7uCA==", null, false, "8a8fddf6-64d4-4b4d-ab66-1e010777f7ae", false, "jan@przyklad.pl" },
                    { "952353cf-dc8c-465f-a1e0-e8d750fe072f", 0, "1f76b911-a6b6-4142-9cf7-91123ba036e3", "anna@przyklad.pl", true, false, null, "ANNA@PRZYKLAD.PL", "ANNA@PRZYKLAD.PL", "AQAAAAEAACcQAAAAEGLI23VERkTcMtmIopR1rR+Cu8ixgBD8MgLNsMQQNmDauS6TY4FQ2+BaCKPJdeD5wA==", null, false, "8b1861b5-3715-4c62-a0b2-6ad5e349fb7c", false, "anna@przyklad.pl" },
                    { "fc870b1c-7ffb-408a-bb2a-e4a858614f7e", 0, "b0e80211-8b0e-46a1-ac7e-7d8dbfc1893c", "olaf@test.pl", true, false, null, "OLAF@TEST.PL", "OLAF@TEST.PL", "AQAAAAEAACcQAAAAEHLjuGpAsYywPP5OnHztYt29X6Ttr/yrGCAMo23DWLvw7pjw94mrAyGiNgrgfvIm5Q==", null, false, "38ce420b-ea3b-4731-aaf0-79436bdd3347", false, "olaf@test.pl" }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Grupa dla programistów specjalizujących się w technologii .NET", "Developers.NET" },
                    { 2, "Społeczność dla zaawansowanych programistów Java, wymieniających się doświadczeniami i najlepszymi praktykami", "Java Masterclass" },
                    { 3, "Grupa dla twórców stron internetowych i aplikacji webowych, skupiająca się na HTML, CSS i JavaScript", "Frontend Wizards" },
                    { 4, "Grupa dla entuzjastów sztucznej inteligencji i uczenia maszynowego, dzielących się wiedzą i projektami", "AI Innovators" }
                });

            migrationBuilder.InsertData(
                table: "organizations",
                columns: new[] { "Id", "Description", "Name", "Adress_City", "Adress_PostalCode", "Adress_Street" },
                values: new object[,]
                {
                    { 1, "Uczelnia", "WSEI", "Kraków", "31-150", "Św. Filipa 17" },
                    { 2, "Uczelnia", "PJTAK", "Warszawa", "00-001", "Aleje Jerozolimskie 120" },
                    { 3, "Korporacja", "ABB", "Gdańsk", "80-001", "ul. Długa 10" },
                    { 4, "Szkoła średnia", "Technikum Informatyczne w Poznaniu", "Poznań", "61-001", "Stary Rynek 1" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "5104e6e9-890d-49cf-9b69-425c60148667", "4b18047d-7a6c-4c50-9e02-a48c76d117d3" },
                    { "5104e6e9-890d-49cf-9b69-425c60148667", "924ee0f6-6e57-484e-9279-0ea5deeb8cf0" },
                    { "5104e6e9-890d-49cf-9b69-425c60148667", "952353cf-dc8c-465f-a1e0-e8d750fe072f" },
                    { "deed65f5-77e1-497d-9d0d-0ef73d812468", "fc870b1c-7ffb-408a-bb2a-e4a858614f7e" }
                });

            migrationBuilder.InsertData(
                table: "contacts",
                columns: new[] { "Id", "birth_date", "Created", "Email", "Name", "OrganizationId", "Phone", "Priority" },
                values: new object[,]
                {
                    { 1, new DateTime(2000, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 24, 16, 23, 7, 349, DateTimeKind.Local).AddTicks(5721), "adam@wsei.edu.pl", "Adam", 1, "127813268163", 1 },
                    { 2, new DateTime(1999, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 24, 16, 23, 7, 349, DateTimeKind.Local).AddTicks(5726), "ewa@wsei.edu.pl", "Ewa", 3, "293443823478", 2 }
                });

            migrationBuilder.InsertData(
                table: "posts",
                columns: new[] { "Id", "Author", "Comments", "Content", "Created", "GroupId", "publication_date", "Tags" },
                values: new object[,]
                {
                    { 1, "Jan Kowalski", "Gratulacje! Bardzo imponujące, szczególnie zarządzanie stanem.", "Właśnie zakończyłem pracę nad moją pierwszą aplikacją w React! Projekt ten nauczył mnie wielu zaawansowanych koncepcji, w tym zarządzania stanem i komunikacji między komponentami.", new DateTime(2024, 2, 24, 16, 23, 7, 349, DateTimeKind.Local).AddTicks(5645), 2, new DateTime(2024, 2, 24, 16, 23, 7, 349, DateTimeKind.Local).AddTicks(5589), "React, JavaScript, Frontend" },
                    { 2, "Ewa Nowak", "Bardzo interesujące! Czy masz jakieś przykłady narzędzi AI, które można by tutaj zastosować?", "Dzielić się chcę przemyśleniami na temat wykorzystania sztucznej inteligencji do automatyzacji testów oprogramowania. AI może znacząco przyspieszyć proces tworzenia testów, oferując jednocześnie wyższą precyzję.", new DateTime(2024, 2, 24, 16, 23, 7, 349, DateTimeKind.Local).AddTicks(5659), 4, new DateTime(2024, 2, 24, 16, 23, 7, 349, DateTimeKind.Local).AddTicks(5656), "AI, Testing, Automatyzacja" },
                    { 3, "Michał Anioł", "Python to naprawdę potężne narzędzie! Używałem Pandas w moim ostatnim projekcie i oszczędziło mi to mnóstwo czasu.", "Odkryłem ostatnio fascynujące zastosowania Pythona w analizie danych. Użycie bibliotek takich jak Pandas i NumPy może znacząco usprawnić przetwarzanie i analizę dużych zbiorów danych.", new DateTime(2024, 2, 24, 16, 23, 7, 349, DateTimeKind.Local).AddTicks(5670), 4, new DateTime(2024, 2, 24, 16, 23, 7, 349, DateTimeKind.Local).AddTicks(5667), "Python, Data Science, Pandas, NumPy" },
                    { 4, "Agata Siek", "Zdecydowanie polecam zapoznać się z Content Security Policy (CSP). Pomogło to mojej aplikacji uniknąć wielu ataków XSS.", "Zastanawiam się nad najlepszymi praktykami w zakresie zabezpieczania aplikacji webowych. Czy ktoś mógłby podzielić się swoimi doświadczeniami w implementacji HTTPS i używaniu nagłówków bezpieczeństwa?", new DateTime(2024, 2, 24, 16, 23, 7, 349, DateTimeKind.Local).AddTicks(5680), 3, new DateTime(2024, 2, 24, 16, 23, 7, 349, DateTimeKind.Local).AddTicks(5678), "Bezpieczeństwo, HTTPS, WebDev" },
                    { 5, "Tomasz Beta", "Pamiętaj o odpowiednim planowaniu i dokumentacji twojej architektury mikroserwisów. Debugowanie może być wyzwaniem bez tego!", "Jakie są wasze doświadczenia z mikroserwisami w .NET Core? Szukam wskazówek dotyczących najlepszych praktyk i potencjalnych pułapek.", new DateTime(2024, 2, 24, 16, 23, 7, 349, DateTimeKind.Local).AddTicks(5690), 1, new DateTime(2024, 2, 24, 16, 23, 7, 349, DateTimeKind.Local).AddTicks(5688), ".NET Core, Mikroserwisy, Architektura" },
                    { 6, "Kasia Lato", "Może zacznij od prostego projektu kalkulatora lub aplikacji do zarządzania zadaniami. To dobre projekty, by poćwiczyć podstawowe konstrukty języka.", "Rozpoczynam naukę programowania w Java i szukam rekomendacji na pierwsze projekty. Co polecacie dla początkującego?", new DateTime(2024, 2, 24, 16, 23, 7, 349, DateTimeKind.Local).AddTicks(5707), 2, new DateTime(2024, 2, 24, 16, 23, 7, 349, DateTimeKind.Local).AddTicks(5704), "Java, Nauka, Projekty dla początkujących" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Borrows_BookId",
                table: "Borrows",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Borrows_LibraryId",
                table: "Borrows",
                column: "LibraryId");

            migrationBuilder.CreateIndex(
                name: "IX_Borrows_UserId",
                table: "Borrows",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_contacts_OrganizationId",
                table: "contacts",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_posts_GroupId",
                table: "posts",
                column: "GroupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Borrows");

            migrationBuilder.DropTable(
                name: "contacts");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "posts");

            migrationBuilder.DropTable(
                name: "organizations");

            migrationBuilder.DropTable(
                name: "Groups");
        }
    }
}
