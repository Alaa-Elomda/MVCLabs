using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Lab4.DAL.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Developers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Developers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Severity = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeveloperTicket",
                columns: table => new
                {
                    DevelopersId = table.Column<int>(type: "int", nullable: false),
                    TicketsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeveloperTicket", x => new { x.DevelopersId, x.TicketsId });
                    table.ForeignKey(
                        name: "FK_DeveloperTicket_Developers_DevelopersId",
                        column: x => x.DevelopersId,
                        principalTable: "Developers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeveloperTicket_Tickets_TicketsId",
                        column: x => x.TicketsId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Automotive & Baby" },
                    { 2, "Beauty & Health" },
                    { 3, "Electronics" }
                });

            migrationBuilder.InsertData(
                table: "Developers",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Freddie", "Johnson" },
                    { 2, "Sophia", "O'Keefe" },
                    { 3, "Angela", "McClure" },
                    { 4, "Jamie", "Berge" },
                    { 5, "Geoffrey", "Abbott" }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "DepartmentId", "Description", "Severity", "Title" },
                values: new object[,]
                {
                    { 1, 2, "Rerum totam est quo possimus sunt sunt ad.", 0, "id" },
                    { 2, 3, "Id cumque explicabo beatae.", 1, "dicta" },
                    { 3, 3, "Consectetur beatae dolorem voluptates occaecati.", 0, "eius" },
                    { 4, 3, "Nulla est doloribus ut non aspernatur vero dolores.", 2, "assumenda" },
                    { 5, 2, "Et praesentium est ipsum eligendi rerum itaque voluptate quia.", 1, "ex" },
                    { 6, 3, "Optio non debitis ut molestiae dolorem ad.", 2, "velit" },
                    { 7, 1, "Dolor quae iure quas error est.", 2, "voluptas" },
                    { 8, 2, "Iste molestiae aut inventore necessitatibus necessitatibus perspiciatis sit.", 2, "recusandae" },
                    { 9, 2, "Voluptas expedita placeat ad sint consequuntur.", 0, "qui" },
                    { 10, 1, "Voluptates qui sed aliquid laudantium in.", 0, "autem" },
                    { 11, 3, "Placeat non repellat qui libero.", 1, "totam" },
                    { 12, 3, "Debitis vero laborum asperiores deserunt nihil tempora quia.", 2, "enim" },
                    { 13, 1, "Voluptatibus a et natus ipsa at quis rem dolores.", 0, "natus" },
                    { 14, 1, "Dolorem qui animi sint ad facere ut ullam voluptatem repellendus.", 1, "et" },
                    { 15, 2, "Sint suscipit delectus accusamus distinctio earum aliquam.", 2, "aut" },
                    { 16, 2, "Et vel tempora.", 0, "et" },
                    { 17, 2, "Aut atque officiis numquam mollitia voluptas dolore.", 1, "iusto" },
                    { 18, 3, "Ipsum mollitia sit officiis sapiente natus.", 2, "facere" },
                    { 19, 1, "Inventore aut reprehenderit vitae ratione dolorum harum.", 2, "recusandae" },
                    { 20, 1, "Harum hic impedit dolore voluptate placeat.", 1, "in" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeveloperTicket_TicketsId",
                table: "DeveloperTicket",
                column: "TicketsId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_DepartmentId",
                table: "Tickets",
                column: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeveloperTicket");

            migrationBuilder.DropTable(
                name: "Developers");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
