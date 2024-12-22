using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSharpClicker.Web.Migrations
{
    /// <inheritdoc />
    public partial class SeedAchievementsWithRequirements : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
        table: "Achievements",
        columns: new[] { "Id", "Title", "Description", "RequiredScore", "RequiredBoostCount" },
        values: new object[,]
        {
            { 1, "Новичок", "Получите своё первое достижение", 10, null },
            { 2, "Сотня очков", "Наберите 100 очков в игре", 100, null },
            { 3, "Тысяча очков", "Наберите 1000 очков в игре", 1000, null },
            { 4, "Первая покупка", "Купите первый буст", null, 1 },
            { 5, "Инвестор", "Купите 10 бустов", null, 10 },
            { 6, "Мастер кликов", "Наберите 5000 очков", 5000, null },
            { 7, "Перфекционист", "Соберите все достижения", null, null }
        });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
            table: "Achievements",
            keyColumn: "Id",
            keyValues: new object[] { 1, 2, 3, 4, 5, 6, 7 });
        }
    }
}
