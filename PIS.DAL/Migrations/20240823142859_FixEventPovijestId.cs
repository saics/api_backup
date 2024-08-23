using Microsoft.EntityFrameworkCore.Migrations;

namespace PIS.DAL.Migrations
{
    public partial class FixEventPovijestId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                IF EXISTS (SELECT * FROM sys.columns 
                           WHERE Name = N'EventHistoryId' 
                           AND Object_ID = Object_ID(N'AktivnostPovijest'))
                BEGIN
                    EXEC sp_rename 'AktivnostPovijest.EventHistoryId', 'EventPovijestId', 'COLUMN';
                END
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                IF EXISTS (SELECT * FROM sys.columns 
                           WHERE Name = N'EventPovijestId' 
                           AND Object_ID = Object_ID(N'AktivnostPovijest'))
                BEGIN
                    EXEC sp_rename 'AktivnostPovijest.EventPovijestId', 'EventHistoryId', 'COLUMN';
                END
            ");
        }
    }
}
