using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class AddOrderDocumentModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attachments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Filename = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Extension = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FileContent = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DateRequisites",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DateRequisites", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocumentTypeRequisites",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentTypeRequisites", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IndexRequisites",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndexRequisites", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TitleRequisites",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TitleRequisites", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderDocuments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IndexId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateTimeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    TypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TitleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDocuments_DateRequisites_DateTimeId",
                        column: x => x.DateTimeId,
                        principalTable: "DateRequisites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderDocuments_DocumentTypeRequisites_TypeId",
                        column: x => x.TypeId,
                        principalTable: "DocumentTypeRequisites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDocuments_IndexRequisites_IndexId",
                        column: x => x.IndexId,
                        principalTable: "IndexRequisites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderDocuments_TitleRequisites_TitleId",
                        column: x => x.TitleId,
                        principalTable: "TitleRequisites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderApprovers",
                columns: table => new
                {
                    DocumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Rank = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderApprovers", x => new { x.EmployeeId, x.DocumentId });
                    table.ForeignKey(
                        name: "FK_OrderApprovers_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderApprovers_OrderDocuments_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "OrderDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderAttachments",
                columns: table => new
                {
                    AttachmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderDocumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderAttachments", x => new { x.AttachmentId, x.OrderDocumentId });
                    table.ForeignKey(
                        name: "FK_OrderAttachments_Attachments_AttachmentId",
                        column: x => x.AttachmentId,
                        principalTable: "Attachments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderAttachments_OrderDocuments_OrderDocumentId",
                        column: x => x.OrderDocumentId,
                        principalTable: "OrderDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderCreators",
                columns: table => new
                {
                    DocumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderCreators", x => new { x.EmployeeId, x.DocumentId });
                    table.ForeignKey(
                        name: "FK_OrderCreators_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderCreators_OrderDocuments_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "OrderDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_Id",
                table: "Attachments",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DateRequisites_Id",
                table: "DateRequisites",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DocumentTypeRequisites_Id",
                table: "DocumentTypeRequisites",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IndexRequisites_Id",
                table: "IndexRequisites",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderApprovers_DocumentId",
                table: "OrderApprovers",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderAttachments_OrderDocumentId",
                table: "OrderAttachments",
                column: "OrderDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderCreators_DocumentId",
                table: "OrderCreators",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDocuments_DateTimeId",
                table: "OrderDocuments",
                column: "DateTimeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDocuments_Id",
                table: "OrderDocuments",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDocuments_IndexId",
                table: "OrderDocuments",
                column: "IndexId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDocuments_TitleId",
                table: "OrderDocuments",
                column: "TitleId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDocuments_TypeId",
                table: "OrderDocuments",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TitleRequisites_Id",
                table: "TitleRequisites",
                column: "Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderApprovers");

            migrationBuilder.DropTable(
                name: "OrderAttachments");

            migrationBuilder.DropTable(
                name: "OrderCreators");

            migrationBuilder.DropTable(
                name: "Attachments");

            migrationBuilder.DropTable(
                name: "OrderDocuments");

            migrationBuilder.DropTable(
                name: "DateRequisites");

            migrationBuilder.DropTable(
                name: "DocumentTypeRequisites");

            migrationBuilder.DropTable(
                name: "IndexRequisites");

            migrationBuilder.DropTable(
                name: "TitleRequisites");
        }
    }
}
