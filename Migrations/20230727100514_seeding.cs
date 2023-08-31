using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace praticeAPI.Migrations
{
    public partial class seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("40c7c352-af79-42b6-85aa-cfdf1e4034ac"), "Medium" },
                    { new Guid("8527976b-94ed-4bc8-96f1-e9ade2386882"), "Easy" },
                    { new Guid("d73209ae-079a-4191-9227-973fd1d398ab"), "Hard" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "ImageURL", "Name" },
                values: new object[,]
                {
                    { new Guid("0ca97531-1fb7-431b-9b11-c13d6b04b8c8"), "PAK", "https://c.tribune.com.pk/2015/12/final-6.jpg", "Pakistan" },
                    { new Guid("1a5b973d-5222-4d5a-8936-9aa8999d1336"), "CN", "https://www.planetware.com/photos-large/CHN/china-great-wall-and-mountain.jpg", "China" },
                    { new Guid("3902bdb6-732a-4272-8d1c-562ebf6ae914"), "JP", "https://www.exoticca.com/us/blog/wp-content/uploads/2021/08/Japan-sightseeing-BLOG-header-930x360.png", "Japan" },
                    { new Guid("47f10a09-ca9d-49b9-bb75-26e730e5eb5b"), "USA", "https://d.newsweek.com/en/full/1865970/statue-liberty.jpg", "United States of America" },
                    { new Guid("72d75104-5c01-4284-83ef-f7e8e78e258c"), "UK", "https://fullsuitcase.com/wp-content/uploads/2021/01/Tower-Bridge-in-London-UK.jpg.webp", "United KingDom" },
                    { new Guid("ca8ded17-e6a9-475c-9feb-f7792ea7ce83"), "IND", "https://facts.net/wp-content/uploads/2023/06/49-facts-about-india-1688115169.jpeg", "India" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("40c7c352-af79-42b6-85aa-cfdf1e4034ac"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("8527976b-94ed-4bc8-96f1-e9ade2386882"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("d73209ae-079a-4191-9227-973fd1d398ab"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("0ca97531-1fb7-431b-9b11-c13d6b04b8c8"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("1a5b973d-5222-4d5a-8936-9aa8999d1336"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("3902bdb6-732a-4272-8d1c-562ebf6ae914"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("47f10a09-ca9d-49b9-bb75-26e730e5eb5b"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("72d75104-5c01-4284-83ef-f7e8e78e258c"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("ca8ded17-e6a9-475c-9feb-f7792ea7ce83"));
        }
    }
}