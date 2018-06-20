using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Vega.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into Makes (Name) values ('Make1')");
            migrationBuilder.Sql("Insert into Makes (Name) values ('Make2')");
            migrationBuilder.Sql("Insert into Makes (Name) values ('Make3')");



            migrationBuilder.Sql("Insert into Model (Name,MakeId) values('Make1-ModelA',(select Id from makes where name='Make1'))");
            migrationBuilder.Sql("Insert into Model (Name,MakeId) values('Make1-ModelB',(select Id from makes where name='Make1'))");
            migrationBuilder.Sql("Insert into Model (Name,MakeId) values('Make1-ModelC',(select Id from makes where name='Make1'))");

            migrationBuilder.Sql("Insert into Model (Name,MakeId) values('Make2-ModelA',(select Id from makes where name='Make2'))");
            migrationBuilder.Sql("Insert into Model (Name,MakeId) values('Make2-ModelB',(select Id from makes where name='Make2'))");
            migrationBuilder.Sql("Insert into Model (Name,MakeId) values('Make2-ModelC',(select Id from makes where name='Make2'))");


            migrationBuilder.Sql("Insert into Model (Name,MakeId) values('Make3-ModelA',(select Id from makes where name='Make3'))");
            migrationBuilder.Sql("Insert into Model (Name,MakeId) values('Make3-ModelB',(select Id from makes where name='Make3'))");
            migrationBuilder.Sql("Insert into Model (Name,MakeId) values('Make3-ModelC',(select Id from makes where name='Make3'))");


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from Makes");

        }
    }
}
