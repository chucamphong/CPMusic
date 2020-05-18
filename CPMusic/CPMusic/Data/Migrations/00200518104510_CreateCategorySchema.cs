using Microsoft.EntityFrameworkCore.Migrations;

namespace CPMusic.Data.Migrations
{
    public partial class CreateCategorySchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable("Categories", builder => new
            {
                Id = builder.Column<int>(),
                Name = builder.Column<string>(maxLength: 50)
            }, constraints: builder =>
            {
                builder.PrimaryKey("PK_Category_Id", col => col.Id);
                builder.UniqueConstraint("UQ_Category_Name", col => col.Name);
            });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
