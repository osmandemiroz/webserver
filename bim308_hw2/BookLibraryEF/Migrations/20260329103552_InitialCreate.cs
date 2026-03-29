using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookLibraryEF.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AuthorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthorInfo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuthorID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseYear = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthorID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookID);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorID",
                        column: x => x.AuthorID,
                        principalTable: "Authors",
                        principalColumn: "AuthorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookUser",
                columns: table => new
                {
                    BooksBookID = table.Column<int>(type: "int", nullable: false),
                    UsersUserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookUser", x => new { x.BooksBookID, x.UsersUserID });
                    table.ForeignKey(
                        name: "FK_BookUser_Books_BooksBookID",
                        column: x => x.BooksBookID,
                        principalTable: "Books",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookUser_Users_UsersUserID",
                        column: x => x.UsersUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorID", "AuthorInfo", "AuthorName" },
                values: new object[,]
                {
                    { 1, "American novelist, widely regarded as one of the greatest writers of the 20th century.", "F. Scott Fitzgerald" },
                    { 2, "American novelist best known for her Pulitzer Prize-winning novel.", "Harper Lee" },
                    { 3, "English novelist and essayist, known for his sharp criticism of political oppression.", "George Orwell" },
                    { 4, "English novelist known for her commentary on the British landed gentry.", "Jane Austen" },
                    { 5, "American writer known for his widely-read novel about teenage angst.", "J.D. Salinger" },
                    { 6, "Founder of the Republic of Turkey and its first President.", "Mustafa Kemal Ataturk" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "Email", "Name" },
                values: new object[,]
                {
                    { 1, "ali.yilmaz@example.com", "Ali Yilmaz" },
                    { 2, "ayse.demir@example.com", "Ayse Demir" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookID", "AuthorID", "ImageUrl", "Price", "ReleaseYear", "Title" },
                values: new object[,]
                {
                    { 1, 1, "https://m.media-amazon.com/images/I/71FTb9X6wsL._SY466_.jpg", 12.99, 1925, "The Great Gatsby" },
                    { 2, 2, "https://m.media-amazon.com/images/I/81gepf1eMqL._SY466_.jpg", 14.99, 1960, "To Kill a Mockingbird" },
                    { 3, 3, "https://m.media-amazon.com/images/I/71kxa1-0mfL._SY466_.jpg", 13.99, 1949, "1984" },
                    { 4, 4, "https://m.media-amazon.com/images/I/71Q1tPupKjL._SY466_.jpg", 11.99, 1813, "Pride and Prejudice" },
                    { 5, 5, "https://m.media-amazon.com/images/I/8125BDk3l9L._SY466_.jpg", 10.99, 1951, "The Catcher in the Rye" },
                    { 6, 6, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR8VkBKk4MXwH0UL8xRRt7mlVVo7XLv94ofiw&s", 19.390000000000001, 1927, "Nutuk" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorID",
                table: "Books",
                column: "AuthorID");

            migrationBuilder.CreateIndex(
                name: "IX_BookUser_UsersUserID",
                table: "BookUser",
                column: "UsersUserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookUser");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
