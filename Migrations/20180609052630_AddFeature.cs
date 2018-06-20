using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Vega.Migrations
{
    public partial class AddFeature : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into features (Name) values('Feature1') ");
            migrationBuilder.Sql("insert into features (Name) values('Feature2') ");
            migrationBuilder.Sql("insert into features (Name) values('Feature3') ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from features where name in ('Feature1','Feature2','Feature3'");
        }
    }
}
