using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OralHealthManagement.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Demography",
                columns: table => new
                {
                    ChartNo = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Sex = table.Column<string>(nullable: false),
                    AdmissionDate = table.Column<DateTime>(nullable: false),
                    Dx = table.Column<string>(nullable: false),
                    Conscious = table.Column<string>(nullable: false),
                    DOB = table.Column<DateTime>(nullable: false),
                    Edu = table.Column<string>(nullable: false),
                    RoomType = table.Column<string>(nullable: false),
                    FromWhere = table.Column<string>(nullable: false),
                    BeenICU = table.Column<bool>(nullable: false),
                    Comorbidity_Dementia = table.Column<bool>(nullable: false),
                    Comorbidity_HTN = table.Column<bool>(nullable: false),
                    Comorbidity_DM = table.Column<bool>(nullable: false),
                    Comorbidity_COPD = table.Column<bool>(nullable: false),
                    Comorbidity_HF = table.Column<bool>(nullable: false),
                    Comorbidity_CVD = table.Column<bool>(nullable: false),
                    Comorbidity_Cancer = table.Column<bool>(nullable: false),
                    Comorbidity_Liver = table.Column<bool>(nullable: false),
                    Comorbidity_CRF = table.Column<bool>(nullable: false),
                    Comorbidity_Imune = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Demography", x => x.ChartNo);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Demography");
        }
    }
}
