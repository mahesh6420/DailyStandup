using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DailyStandup.Data.Migrations
{
    public partial class modelupdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Obstacles_Projects_ProjectId",
                schema: "DailyStandup",
                table: "Obstacles");

            migrationBuilder.DropTable(
                name: "Standups",
                schema: "DailyStandup");

            migrationBuilder.DropTable(
                name: "WorksOfToday",
                schema: "DailyStandup");

            migrationBuilder.DropTable(
                name: "WorksOfYesterday",
                schema: "DailyStandup");

            migrationBuilder.RenameColumn(
                name: "ProjectId",
                schema: "DailyStandup",
                table: "Obstacles",
                newName: "WorkYesterdayId");

            migrationBuilder.RenameIndex(
                name: "IX_Obstacles_ProjectId",
                schema: "DailyStandup",
                table: "Obstacles",
                newName: "IX_Obstacles_WorkYesterdayId");

            migrationBuilder.AddColumn<bool>(
                name: "IsSolved",
                schema: "DailyStandup",
                table: "Obstacles",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Worksssss",
                schema: "DailyStandup",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ProjectId = table.Column<Guid>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Worksssss", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Worksssss_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalSchema: "DailyStandup",
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Worksssss_ProjectId",
                schema: "DailyStandup",
                table: "Worksssss",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Obstacles_Worksssss_WorkYesterdayId",
                schema: "DailyStandup",
                table: "Obstacles",
                column: "WorkYesterdayId",
                principalSchema: "DailyStandup",
                principalTable: "Worksssss",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Obstacles_Worksssss_WorkYesterdayId",
                schema: "DailyStandup",
                table: "Obstacles");

            migrationBuilder.DropTable(
                name: "Worksssss",
                schema: "DailyStandup");

            migrationBuilder.DropColumn(
                name: "IsSolved",
                schema: "DailyStandup",
                table: "Obstacles");

            migrationBuilder.RenameColumn(
                name: "WorkYesterdayId",
                schema: "DailyStandup",
                table: "Obstacles",
                newName: "ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Obstacles_WorkYesterdayId",
                schema: "DailyStandup",
                table: "Obstacles",
                newName: "IX_Obstacles_ProjectId");

            migrationBuilder.CreateTable(
                name: "WorksOfToday",
                schema: "DailyStandup",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ProjectId = table.Column<Guid>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    WorkOfToday = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorksOfToday", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorksOfToday_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalSchema: "DailyStandup",
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorksOfYesterday",
                schema: "DailyStandup",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ProjectId = table.Column<Guid>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    WorkOfYesterday = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorksOfYesterday", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorksOfYesterday_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalSchema: "DailyStandup",
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Standups",
                schema: "DailyStandup",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ObstacleId = table.Column<Guid>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    WorkDate = table.Column<DateTime>(nullable: false),
                    WorkTodayId = table.Column<Guid>(nullable: false),
                    WorkYesterdayId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Standups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Standups_Obstacles_ObstacleId",
                        column: x => x.ObstacleId,
                        principalSchema: "DailyStandup",
                        principalTable: "Obstacles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Standups_WorksOfToday_WorkTodayId",
                        column: x => x.WorkTodayId,
                        principalSchema: "DailyStandup",
                        principalTable: "WorksOfToday",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Standups_WorksOfYesterday_WorkYesterdayId",
                        column: x => x.WorkYesterdayId,
                        principalSchema: "DailyStandup",
                        principalTable: "WorksOfYesterday",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Standups_ObstacleId",
                schema: "DailyStandup",
                table: "Standups",
                column: "ObstacleId");

            migrationBuilder.CreateIndex(
                name: "IX_Standups_WorkTodayId",
                schema: "DailyStandup",
                table: "Standups",
                column: "WorkTodayId");

            migrationBuilder.CreateIndex(
                name: "IX_Standups_WorkYesterdayId",
                schema: "DailyStandup",
                table: "Standups",
                column: "WorkYesterdayId");

            migrationBuilder.CreateIndex(
                name: "IX_WorksOfToday_ProjectId",
                schema: "DailyStandup",
                table: "WorksOfToday",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_WorksOfYesterday_ProjectId",
                schema: "DailyStandup",
                table: "WorksOfYesterday",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Obstacles_Projects_ProjectId",
                schema: "DailyStandup",
                table: "Obstacles",
                column: "ProjectId",
                principalSchema: "DailyStandup",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
