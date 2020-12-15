using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Qdea.API.Migrations
{
    public partial class EfMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Efforts",
                columns: table => new
                {
                    EffortID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Efforts", x => x.EffortID);
                });

            migrationBuilder.CreateTable(
                name: "IdeaInteractionTypes",
                columns: table => new
                {
                    IdeaInteractionTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdeaInteractionTypes", x => x.IdeaInteractionTypeID);
                });

            migrationBuilder.CreateTable(
                name: "IdeaStatuses",
                columns: table => new
                {
                    IdeaStatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdeaStatuses", x => x.IdeaStatusID);
                });

            migrationBuilder.CreateTable(
                name: "Impacts",
                columns: table => new
                {
                    ImpactID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Impacts", x => x.ImpactID);
                });

            migrationBuilder.CreateTable(
                name: "Priorities",
                columns: table => new
                {
                    PriorityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Priorities", x => x.PriorityID);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    TagID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.TagID);
                });

            migrationBuilder.CreateTable(
                name: "UserStatuses",
                columns: table => new
                {
                    UserStatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserStatuses", x => x.UserStatusID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserStatusID = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_Users_UserStatuses_UserStatusID",
                        column: x => x.UserStatusID,
                        principalTable: "UserStatuses",
                        principalColumn: "UserStatusID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ideas",
                columns: table => new
                {
                    IdeaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    PriorityID = table.Column<int>(type: "int", nullable: true),
                    IdeaStatusID = table.Column<int>(type: "int", nullable: true),
                    ImpactID = table.Column<int>(type: "int", nullable: true),
                    EffortID = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateLastEdited = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ideas", x => x.IdeaID);
                    table.ForeignKey(
                        name: "FK_Ideas_Efforts_EffortID",
                        column: x => x.EffortID,
                        principalTable: "Efforts",
                        principalColumn: "EffortID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ideas_IdeaStatuses_IdeaStatusID",
                        column: x => x.IdeaStatusID,
                        principalTable: "IdeaStatuses",
                        principalColumn: "IdeaStatusID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ideas_Impacts_ImpactID",
                        column: x => x.ImpactID,
                        principalTable: "Impacts",
                        principalColumn: "ImpactID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ideas_Priorities_PriorityID",
                        column: x => x.PriorityID,
                        principalTable: "Priorities",
                        principalColumn: "PriorityID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ideas_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AddedUsers",
                columns: table => new
                {
                    AddedUserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    IdeaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddedUsers", x => x.AddedUserID);
                    table.ForeignKey(
                        name: "FK_AddedUsers_Ideas_IdeaID",
                        column: x => x.IdeaID,
                        principalTable: "Ideas",
                        principalColumn: "IdeaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AddedUsers_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IdeaInteractions",
                columns: table => new
                {
                    IdeaInteractionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdeaID = table.Column<int>(type: "int", nullable: true),
                    IdeaInteractionTypeID = table.Column<int>(type: "int", nullable: true),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TextContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastDateTimeEdited = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdeaInteractions", x => x.IdeaInteractionID);
                    table.ForeignKey(
                        name: "FK_IdeaInteractions_IdeaInteractionTypes_IdeaInteractionTypeID",
                        column: x => x.IdeaInteractionTypeID,
                        principalTable: "IdeaInteractionTypes",
                        principalColumn: "IdeaInteractionTypeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IdeaInteractions_Ideas_IdeaID",
                        column: x => x.IdeaID,
                        principalTable: "Ideas",
                        principalColumn: "IdeaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IdeaInteractions_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TagIdeas",
                columns: table => new
                {
                    TagListID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdeaID = table.Column<int>(type: "int", nullable: true),
                    TagID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagIdeas", x => x.TagListID);
                    table.ForeignKey(
                        name: "FK_TagIdeas_Ideas_IdeaID",
                        column: x => x.IdeaID,
                        principalTable: "Ideas",
                        principalColumn: "IdeaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TagIdeas_Tags_TagID",
                        column: x => x.TagID,
                        principalTable: "Tags",
                        principalColumn: "TagID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AddedUsers_IdeaID",
                table: "AddedUsers",
                column: "IdeaID");

            migrationBuilder.CreateIndex(
                name: "IX_AddedUsers_UserID",
                table: "AddedUsers",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_IdeaInteractions_IdeaID",
                table: "IdeaInteractions",
                column: "IdeaID");

            migrationBuilder.CreateIndex(
                name: "IX_IdeaInteractions_IdeaInteractionTypeID",
                table: "IdeaInteractions",
                column: "IdeaInteractionTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_IdeaInteractions_UserID",
                table: "IdeaInteractions",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Ideas_EffortID",
                table: "Ideas",
                column: "EffortID");

            migrationBuilder.CreateIndex(
                name: "IX_Ideas_IdeaStatusID",
                table: "Ideas",
                column: "IdeaStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Ideas_ImpactID",
                table: "Ideas",
                column: "ImpactID");

            migrationBuilder.CreateIndex(
                name: "IX_Ideas_PriorityID",
                table: "Ideas",
                column: "PriorityID");

            migrationBuilder.CreateIndex(
                name: "IX_Ideas_UserID",
                table: "Ideas",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_TagIdeas_IdeaID",
                table: "TagIdeas",
                column: "IdeaID");

            migrationBuilder.CreateIndex(
                name: "IX_TagIdeas_TagID",
                table: "TagIdeas",
                column: "TagID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserStatusID",
                table: "Users",
                column: "UserStatusID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddedUsers");

            migrationBuilder.DropTable(
                name: "IdeaInteractions");

            migrationBuilder.DropTable(
                name: "TagIdeas");

            migrationBuilder.DropTable(
                name: "IdeaInteractionTypes");

            migrationBuilder.DropTable(
                name: "Ideas");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Efforts");

            migrationBuilder.DropTable(
                name: "IdeaStatuses");

            migrationBuilder.DropTable(
                name: "Impacts");

            migrationBuilder.DropTable(
                name: "Priorities");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UserStatuses");
        }
    }
}
