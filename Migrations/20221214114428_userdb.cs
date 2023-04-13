using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class userdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Dish",
                columns: new[] { "Id", "Category", "Description", "Image", "Name", "Price", "Rating", "Vegetarian" },
                values: new object[,]
                {
                    { "31101a8b-b9fa-4dbe-85c5-c6ca032655555", 2, "Бульон рамен со сливками (куриный бульон, чесночно-имбирная заправка, соевый соус) с пшеничной лапшой, отварной курицей, омлетом Томаго и шампиньонами. БЖУ на 100 г. Белки, г — 8,13 Жиры, г — 6,18 Углеводы, г — 8,08", "https://mistertako.ru/uploads/products/ccd8e2de-5f36-11e8-8f7d-00155dd9fd01.jpg", "Сливочный рамен с курицей и шампиньонами", 260.0, 2.3333300000000001, false },
                    { "31101a8b-b9fa-4dbe-85c5-c6ca7226660055", 3, "Сырная лепешка, банан, арахис, сливочный сыр, шоколадная крошка, топинг карамельный", "https://mistertako.ru/uploads/products/a4772f7a-7a6f-11eb-850a-0050569dbef0.jpeg", "Сладкий ролл с арахисом и бананом", 210.0, 7.625, true },
                    { "31101a8b-b9fa-4dbe-85c5-c6ca732655555", 2, "Знаменитый тайский острый суп со сливками, куриным филе, шампиньонами, красным луком, помидором, перчиком Чили и кинзой. Подается с рисом. БЖУ на 100 г. Белки, г — 5,75 Жиры, г — 3,72 Углеводы, г — 14,76", "https://mistertako.ru/uploads/products/ccd8e2de-5f36-11e8-8f7d-00155dd9fd01.jpg", "Том ям кай", 300.0, 2.3333300000000001, false },
                    { "31101a8b-b9fa-4dbe-85c5-c6ca7326606055", 3, "Апельсин, банан, шоколадная крошка, сыр творожный, сырная лепешка. БЖУ на 100 г. Белки, г - 5,86 Жиры, г - 13,12 Углеводы, г - 44,05", "https://mistertako.ru/uploads/products/05391255-54ee-11ed-8575-0050569dbef0.jpg", "Сладкий ролл с апельсином и бананом", 250.0, 5.0, true },
                    { "31101a8b-b9fa-4dbe-85c5-c6ca7326660055", 3, "Апельсин, банан, шоколадная крошка, сыр творожный, сырная лепешка. БЖУ на 100 г. Белки, г - 5,86 Жиры, г - 13,12 Углеводы, г - 44,05", "https://mistertako.ru/uploads/products/05391255-54ee-11ed-8575-0050569dbef0.jpg", "Сладкий ролл с апельсином и бананом", 250.0, 5.0, true },
                    { "31101a8b-b9fa-4dbe-85c5-c6ca7326668055", 2, "Сырный бульон с пшеничной лапшой, отварным куриным филе,помидором и сырными шариками. БЖУ на 100 г. Белки, г — 11,8 Жиры, г — 9,82 Углеводы, г — 22,69", "https://mistertako.ru/uploads/products/ccd8e2de-5f36-11e8-8f7d-00155dd9fd01.jpg", "Рамен сырный", 300.0, 3.0, false },
                    { "31101a8b-b9fa-4dbe-85c5-c6ca73267055", 3, "Сырная лепешка, банан, киви, сливочный сыр, топинг клубничный", "https://mistertako.ru/uploads/products/9e7c8581-7a6f-11eb-850a-0050569dbef0.jpeg", "Сладкий ролл с бананом и киви", 220.0, 5.5, true },
                    { "31101a8b-b9fa-4dbe-85c5-c6ca732675555", 3, "Чизкейк Нью-Йорк - настоящая классика. Его основа - сочетание вкусов нежнейшего сливочного сыра и тонкой песочной корочки.", "https://mistertako.ru/uploads/products/120b46b1-5f32-11e8-8f7d-00155dd9fd01.jpg", "Чизкейк Нью-Йорк", 210.0, 9.25, true },
                    { "31101a8b-b9fa-4dbe-85c5-c6ca742664655", 4, "Классический молочный коктейль с клубничным топпингом", "https://mistertako.ru/uploads/products/120b46bd-5f32-11e8-8f7d-00155dd9fd01.jpg", "Коктейль клубничный", 170.0, 7.7649999999999997, true },
                    { "31101a8b-b9fa-4dbe-85c5-c6ca7426664055", 4, "Смородиновый морс", "https://mistertako.ru/uploads/products/120b46c1-5f32-11e8-8f7d-00155dd9fd01.jpg", "Морс cмородиновый", 90.0, 8.0, true },
                    { "31101a8b-b9fa-4dbe-85c5-c6ca7426664655", 4, "Классический молочный коктейль с добавлением шоколадного топпинга", "https://mistertako.ru/uploads/products/120b46be-5f32-11e8-8f7d-00155dd9fd01.jpg", "Коктейль шоколадный", 170.0, 1.75, true },
                    { "31101a8b-b9fa-4dbe-85c5-c6ca745046665", 0, "Лапша пшеничная, креветки, кальмар, шампиньоны, лук красный, заправка Том Ям (паста Том Ям, паста Том Кха, сахар, соевый соус), сливки, соевый соус, помидор, перец чили. БЖУ на 100 г. Белки, г - 8,57 Жиры, г - 12,8 Углеводы, г - 18,8", "https://mistertako.ru/uploads/products/bacd88ca-54ed-11ed-8575-0050569dbef0.jpg", "Wok том ям с морепродуктам", 340.0, 5.0, false },
                    { "31101a8b-b9fa-4dbe-85c5-c6ca745064655", 0, "Лапша пшеничная, шампиньоны, лук красный, заправка Том Ям (паста Том Ям, паста Том Кха, сахар, соевый соус), сливки, соевый соус, помидор, перец чили. БЖУ на 100 г. Белки, г - 5,32 Жиры, г - 14,89 Углеводы, г - 22,46", "https://mistertako.ru/uploads/products/cd661716-54ed-11ed-8575-0050569dbef0.jpg", "Wok том ям с овощами", 250.0, 9.0, true },
                    { "31101a8b-b9fa-4dbe-85c5-c6ca745604255", 0, "Копченая куриная грудка, свежие шампиньоны, маринованные опята, сыр «Моцарелла», сыр «Гауда», сливочно-чесночный соус, свежая зелень.", "https://mistertako.ru/uploads/products/cd661716-54ed-11ed-8575-0050569dbef0.jpg", "Белиссимо", 250.0, 9.0, true },
                    { "31101a8b-b9fa-4dbe-85c5-c6ca746204655", 4, "Классический молочный коктейль", "https://mistertako.ru/uploads/products/120b46bc-5f32-11e8-8f7d-00155dd9fd01.jpg", "Коктейль классический", 140.0, 5.6666666599999997, true },
                    { "31101a8b-b9fa-4dbe-85c5-c6ca7462668055", 4, "Облепиха, имбирь, сахар", "https://mistertako.ru/uploads/products/5a7d58a5-879d-11eb-850a-0050569dbef0.jpg", "Морс облепиховый", 90.0, 6.0625, true }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "BirthDate", "Email", "FullName", "Gender", "PasswordHash", "PhoneNumber", "Token" },
                values: new object[,]
                {
                    { "31101a8b-b9fa-4dbe-85c5-c6ca745046666", "grow stret 2", new DateTime(2022, 12, 14, 11, 44, 28, 362, DateTimeKind.Utc).AddTicks(3445), "12uswe@sgrg.com", "TEST Name", 1, null, "34545654656", null },
                    { "31101a8b-b9fa-4dbe-85c5-c6ca7465046r5", "grow stret 1", new DateTime(2022, 12, 14, 11, 44, 28, 362, DateTimeKind.Utc).AddTicks(3439), "uswe@sgrg.com", "TEST Name", 0, null, "34545654656", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Dish",
                keyColumn: "Id",
                keyValue: "31101a8b-b9fa-4dbe-85c5-c6ca032655555");

            migrationBuilder.DeleteData(
                table: "Dish",
                keyColumn: "Id",
                keyValue: "31101a8b-b9fa-4dbe-85c5-c6ca7226660055");

            migrationBuilder.DeleteData(
                table: "Dish",
                keyColumn: "Id",
                keyValue: "31101a8b-b9fa-4dbe-85c5-c6ca732655555");

            migrationBuilder.DeleteData(
                table: "Dish",
                keyColumn: "Id",
                keyValue: "31101a8b-b9fa-4dbe-85c5-c6ca7326606055");

            migrationBuilder.DeleteData(
                table: "Dish",
                keyColumn: "Id",
                keyValue: "31101a8b-b9fa-4dbe-85c5-c6ca7326660055");

            migrationBuilder.DeleteData(
                table: "Dish",
                keyColumn: "Id",
                keyValue: "31101a8b-b9fa-4dbe-85c5-c6ca7326668055");

            migrationBuilder.DeleteData(
                table: "Dish",
                keyColumn: "Id",
                keyValue: "31101a8b-b9fa-4dbe-85c5-c6ca73267055");

            migrationBuilder.DeleteData(
                table: "Dish",
                keyColumn: "Id",
                keyValue: "31101a8b-b9fa-4dbe-85c5-c6ca732675555");

            migrationBuilder.DeleteData(
                table: "Dish",
                keyColumn: "Id",
                keyValue: "31101a8b-b9fa-4dbe-85c5-c6ca742664655");

            migrationBuilder.DeleteData(
                table: "Dish",
                keyColumn: "Id",
                keyValue: "31101a8b-b9fa-4dbe-85c5-c6ca7426664055");

            migrationBuilder.DeleteData(
                table: "Dish",
                keyColumn: "Id",
                keyValue: "31101a8b-b9fa-4dbe-85c5-c6ca7426664655");

            migrationBuilder.DeleteData(
                table: "Dish",
                keyColumn: "Id",
                keyValue: "31101a8b-b9fa-4dbe-85c5-c6ca745046665");

            migrationBuilder.DeleteData(
                table: "Dish",
                keyColumn: "Id",
                keyValue: "31101a8b-b9fa-4dbe-85c5-c6ca745064655");

            migrationBuilder.DeleteData(
                table: "Dish",
                keyColumn: "Id",
                keyValue: "31101a8b-b9fa-4dbe-85c5-c6ca745604255");

            migrationBuilder.DeleteData(
                table: "Dish",
                keyColumn: "Id",
                keyValue: "31101a8b-b9fa-4dbe-85c5-c6ca746204655");

            migrationBuilder.DeleteData(
                table: "Dish",
                keyColumn: "Id",
                keyValue: "31101a8b-b9fa-4dbe-85c5-c6ca7462668055");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "31101a8b-b9fa-4dbe-85c5-c6ca745046666");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "31101a8b-b9fa-4dbe-85c5-c6ca7465046r5");
        }
    }
}
