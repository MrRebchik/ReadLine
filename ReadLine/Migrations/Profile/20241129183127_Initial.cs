using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReadLine.Migrations.Profile
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    AuthorId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Patronymic = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "IdentityUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    TagId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.TagId);
                });

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    IdentityUserName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdentityUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ProfileQuote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserProfileIdentityUserName = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.IdentityUserName);
                    table.ForeignKey(
                        name: "FK_UserProfiles_IdentityUser_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "IdentityUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserProfiles_UserProfiles_UserProfileIdentityUserName",
                        column: x => x.UserProfileIdentityUserName,
                        principalTable: "UserProfiles",
                        principalColumn: "IdentityUserName");
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    BookId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthorId = table.Column<long>(type: "bigint", nullable: false),
                    PublicationYear = table.Column<int>(type: "int", nullable: false),
                    Publisher = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PagesCount = table.Column<int>(type: "int", nullable: false),
                    PublishFormat = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<long>(type: "bigint", nullable: false),
                    AgeLimit = table.Column<int>(type: "int", nullable: false),
                    UserProfileIdentityUserName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserProfileIdentityUserName1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserProfileIdentityUserName2 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_Book_Author_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Author",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Book_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Book_UserProfiles_UserProfileIdentityUserName",
                        column: x => x.UserProfileIdentityUserName,
                        principalTable: "UserProfiles",
                        principalColumn: "IdentityUserName");
                    table.ForeignKey(
                        name: "FK_Book_UserProfiles_UserProfileIdentityUserName1",
                        column: x => x.UserProfileIdentityUserName1,
                        principalTable: "UserProfiles",
                        principalColumn: "IdentityUserName");
                    table.ForeignKey(
                        name: "FK_Book_UserProfiles_UserProfileIdentityUserName2",
                        column: x => x.UserProfileIdentityUserName2,
                        principalTable: "UserProfiles",
                        principalColumn: "IdentityUserName");
                });

            migrationBuilder.CreateTable(
                name: "BookTag",
                columns: table => new
                {
                    BooksBookId = table.Column<long>(type: "bigint", nullable: false),
                    TagsTagId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookTag", x => new { x.BooksBookId, x.TagsTagId });
                    table.ForeignKey(
                        name: "FK_BookTag_Book_BooksBookId",
                        column: x => x.BooksBookId,
                        principalTable: "Book",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookTag_Tag_TagsTagId",
                        column: x => x.TagsTagId,
                        principalTable: "Tag",
                        principalColumn: "TagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_AuthorId",
                table: "Book",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Book_CategoryId",
                table: "Book",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Book_UserProfileIdentityUserName",
                table: "Book",
                column: "UserProfileIdentityUserName");

            migrationBuilder.CreateIndex(
                name: "IX_Book_UserProfileIdentityUserName1",
                table: "Book",
                column: "UserProfileIdentityUserName1");

            migrationBuilder.CreateIndex(
                name: "IX_Book_UserProfileIdentityUserName2",
                table: "Book",
                column: "UserProfileIdentityUserName2");

            migrationBuilder.CreateIndex(
                name: "IX_BookTag_TagsTagId",
                table: "BookTag",
                column: "TagsTagId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_IdentityUserId",
                table: "UserProfiles",
                column: "IdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_UserProfileIdentityUserName",
                table: "UserProfiles",
                column: "UserProfileIdentityUserName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookTag");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "UserProfiles");

            migrationBuilder.DropTable(
                name: "IdentityUser");
        }
    }
}
