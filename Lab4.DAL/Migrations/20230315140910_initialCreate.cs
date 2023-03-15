using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Lab4.DAL.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Severity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "Description", "Severity", "Title" },
                values: new object[,]
                {
                    { 1, "Rerum totam est quo possimus sunt sunt ad.", 0, "id" },
                    { 2, "Id cumque explicabo beatae.", 1, "dicta" },
                    { 3, "Consectetur beatae dolorem voluptates occaecati.", 0, "eius" },
                    { 4, "Nulla est doloribus ut non aspernatur vero dolores.", 2, "assumenda" },
                    { 5, "Et praesentium est ipsum eligendi rerum itaque voluptate quia.", 1, "ex" },
                    { 6, "Optio non debitis ut molestiae dolorem ad.", 2, "velit" },
                    { 7, "Dolor quae iure quas error est.", 2, "voluptas" },
                    { 8, "Iste molestiae aut inventore necessitatibus necessitatibus perspiciatis sit.", 2, "recusandae" },
                    { 9, "Voluptas expedita placeat ad sint consequuntur.", 0, "qui" },
                    { 10, "Voluptates qui sed aliquid laudantium in.", 0, "autem" },
                    { 11, "Placeat non repellat qui libero.", 1, "totam" },
                    { 12, "Debitis vero laborum asperiores deserunt nihil tempora quia.", 2, "enim" },
                    { 13, "Voluptatibus a et natus ipsa at quis rem dolores.", 0, "natus" },
                    { 14, "Dolorem qui animi sint ad facere ut ullam voluptatem repellendus.", 1, "et" },
                    { 15, "Sint suscipit delectus accusamus distinctio earum aliquam.", 2, "aut" },
                    { 16, "Et vel tempora.", 0, "et" },
                    { 17, "Aut atque officiis numquam mollitia voluptas dolore.", 1, "iusto" },
                    { 18, "Ipsum mollitia sit officiis sapiente natus.", 2, "facere" },
                    { 19, "Inventore aut reprehenderit vitae ratione dolorum harum.", 2, "recusandae" },
                    { 20, "Harum hic impedit dolore voluptate placeat.", 1, "in" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");
        }
    }
}
