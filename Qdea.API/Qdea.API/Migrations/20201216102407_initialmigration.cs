using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Qdea.API.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Efforts",
                table => new
                {
                    EffortID = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>("nvarchar(max)", nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Efforts", x => x.EffortID); });

            migrationBuilder.CreateTable(
                "IdeaInteractionTypes",
                table => new
                {
                    IdeaInteractionTypeID = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>("nvarchar(max)", nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_IdeaInteractionTypes", x => x.IdeaInteractionTypeID); });

            migrationBuilder.CreateTable(
                "IdeaStatuses",
                table => new
                {
                    IdeaStatusID = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>("nvarchar(max)", nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_IdeaStatuses", x => x.IdeaStatusID); });

            migrationBuilder.CreateTable(
                "Impacts",
                table => new
                {
                    ImpactID = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>("nvarchar(max)", nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Impacts", x => x.ImpactID); });

            migrationBuilder.CreateTable(
                "Priorities",
                table => new
                {
                    PriorityID = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>("nvarchar(max)", nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Priorities", x => x.PriorityID); });

            migrationBuilder.CreateTable(
                "Tags",
                table => new
                {
                    TagID = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>("nvarchar(max)", nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Tags", x => x.TagID); });

            migrationBuilder.CreateTable(
                "UserStatuses",
                table => new
                {
                    UserStatusID = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>("nvarchar(max)", nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_UserStatuses", x => x.UserStatusID); });

            migrationBuilder.CreateTable(
                "Users",
                table => new
                {
                    UserID = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserStatusID = table.Column<int>("int", nullable: true),
                    Name = table.Column<string>("nvarchar(max)", nullable: true),
                    Address = table.Column<string>("nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<int>("int", nullable: true),
                    Email = table.Column<string>("nvarchar(max)", nullable: true),
                    Password = table.Column<string>("nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                    table.ForeignKey(
                        "FK_Users_UserStatuses_UserStatusID",
                        x => x.UserStatusID,
                        "UserStatuses",
                        "UserStatusID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "Ideas",
                table => new
                {
                    IdeaID = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>("int", nullable: true),
                    PriorityID = table.Column<int>("int", nullable: true),
                    IdeaStatusID = table.Column<int>("int", nullable: true),
                    ImpactID = table.Column<int>("int", nullable: true),
                    EffortID = table.Column<int>("int", nullable: true),
                    Title = table.Column<string>("nvarchar(max)", nullable: true),
                    Description = table.Column<string>("nvarchar(max)", nullable: true),
                    Text = table.Column<string>("nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>("datetime2", nullable: false),
                    DateLastEdited = table.Column<DateTime>("datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ideas", x => x.IdeaID);
                    table.ForeignKey(
                        "FK_Ideas_Efforts_EffortID",
                        x => x.EffortID,
                        "Efforts",
                        "EffortID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_Ideas_IdeaStatuses_IdeaStatusID",
                        x => x.IdeaStatusID,
                        "IdeaStatuses",
                        "IdeaStatusID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_Ideas_Impacts_ImpactID",
                        x => x.ImpactID,
                        "Impacts",
                        "ImpactID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_Ideas_Priorities_PriorityID",
                        x => x.PriorityID,
                        "Priorities",
                        "PriorityID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_Ideas_Users_UserID",
                        x => x.UserID,
                        "Users",
                        "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "AddedUsers",
                table => new
                {
                    AddedUserID = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>("int", nullable: true),
                    IdeaID = table.Column<int>("int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddedUsers", x => x.AddedUserID);
                    table.ForeignKey(
                        "FK_AddedUsers_Ideas_IdeaID",
                        x => x.IdeaID,
                        "Ideas",
                        "IdeaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_AddedUsers_Users_UserID",
                        x => x.UserID,
                        "Users",
                        "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "IdeaInteractions",
                table => new
                {
                    IdeaInteractionID = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdeaID = table.Column<int>("int", nullable: true),
                    IdeaInteractionTypeID = table.Column<int>("int", nullable: true),
                    UserID = table.Column<int>("int", nullable: true),
                    Title = table.Column<string>("nvarchar(max)", nullable: true),
                    Description = table.Column<string>("nvarchar(max)", nullable: true),
                    TextContent = table.Column<string>("nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>("datetime2", nullable: false),
                    LastDateTimeEdited = table.Column<DateTime>("datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdeaInteractions", x => x.IdeaInteractionID);
                    table.ForeignKey(
                        "FK_IdeaInteractions_IdeaInteractionTypes_IdeaInteractionTypeID",
                        x => x.IdeaInteractionTypeID,
                        "IdeaInteractionTypes",
                        "IdeaInteractionTypeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_IdeaInteractions_Ideas_IdeaID",
                        x => x.IdeaID,
                        "Ideas",
                        "IdeaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_IdeaInteractions_Users_UserID",
                        x => x.UserID,
                        "Users",
                        "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "TagIdeas",
                table => new
                {
                    TagListID = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdeaID = table.Column<int>("int", nullable: true),
                    TagID = table.Column<int>("int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagIdeas", x => x.TagListID);
                    table.ForeignKey(
                        "FK_TagIdeas_Ideas_IdeaID",
                        x => x.IdeaID,
                        "Ideas",
                        "IdeaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_TagIdeas_Tags_TagID",
                        x => x.TagID,
                        "Tags",
                        "TagID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                "IX_AddedUsers_IdeaID",
                "AddedUsers",
                "IdeaID");

            migrationBuilder.CreateIndex(
                "IX_AddedUsers_UserID",
                "AddedUsers",
                "UserID");

            migrationBuilder.CreateIndex(
                "IX_IdeaInteractions_IdeaID",
                "IdeaInteractions",
                "IdeaID");

            migrationBuilder.CreateIndex(
                "IX_IdeaInteractions_IdeaInteractionTypeID",
                "IdeaInteractions",
                "IdeaInteractionTypeID");

            migrationBuilder.CreateIndex(
                "IX_IdeaInteractions_UserID",
                "IdeaInteractions",
                "UserID");

            migrationBuilder.CreateIndex(
                "IX_Ideas_EffortID",
                "Ideas",
                "EffortID");

            migrationBuilder.CreateIndex(
                "IX_Ideas_IdeaStatusID",
                "Ideas",
                "IdeaStatusID");

            migrationBuilder.CreateIndex(
                "IX_Ideas_ImpactID",
                "Ideas",
                "ImpactID");

            migrationBuilder.CreateIndex(
                "IX_Ideas_PriorityID",
                "Ideas",
                "PriorityID");

            migrationBuilder.CreateIndex(
                "IX_Ideas_UserID",
                "Ideas",
                "UserID");

            migrationBuilder.CreateIndex(
                "IX_TagIdeas_IdeaID",
                "TagIdeas",
                "IdeaID");

            migrationBuilder.CreateIndex(
                "IX_TagIdeas_TagID",
                "TagIdeas",
                "TagID");

            migrationBuilder.CreateIndex(
                "IX_Users_UserStatusID",
                "Users",
                "UserStatusID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "AddedUsers");

            migrationBuilder.DropTable(
                "IdeaInteractions");

            migrationBuilder.DropTable(
                "TagIdeas");

            migrationBuilder.DropTable(
                "IdeaInteractionTypes");

            migrationBuilder.DropTable(
                "Ideas");

            migrationBuilder.DropTable(
                "Tags");

            migrationBuilder.DropTable(
                "Efforts");

            migrationBuilder.DropTable(
                "IdeaStatuses");

            migrationBuilder.DropTable(
                "Impacts");

            migrationBuilder.DropTable(
                "Priorities");

            migrationBuilder.DropTable(
                "Users");

            migrationBuilder.DropTable(
                "UserStatuses");
        }
    }
}