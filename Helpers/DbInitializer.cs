using Microsoft.EntityFrameworkCore;
using WebApi.Entities;
using WebApi.Models.Users;

namespace WebApi.Helpers
{
    public class DbInitializer
    {
        private readonly ModelBuilder modelBuilder;

        public DbInitializer(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        public void Seed()
        {
            modelBuilder.Entity<Users>().HasData(
                   new Users() {
                       Id = "31101a8b-b9fa-4dbe-85c5-c6ca7465046r5",
                       FullName = "TEST Name",
                       Email = "uswe@sgrg.com",
                       Address = "grow stret 1",
                       BirthDate = DateTime.UtcNow,
                       Gender = Gender.Male,
                       PasswordHash = "$2a$11$ytBpAgietJ9LXAxUjZoBq.xLGGes1eri5n7KD3CDFXkXZKgZMGEK.",
                       PhoneNumber = "34545654656"

                   },
                   new Users() {
                       Id = "31101a8b-b9fa-4dbe-85c5-c6ca745046666",
                       FullName = "TEST Name",
                       Email = "12uswe@sgrg.com",
                       Address = "grow stret 2",
                       BirthDate = DateTime.UtcNow,
                       Gender = Gender.Female,
                       PasswordHash = "$2a$11$ytBpAgietJ9LXAxUjZoBq.xLGGes1eri5n7KD3CDFXkXZKgZMGEK.",
                       PhoneNumber = "34545654656"
                   }
    

            );
            modelBuilder.Entity<Dish>().HasData(
                   new Dish()
                   {
                       Id = "31101a8b-b9fa-4dbe-85c5-c6ca745046665",
                       Name = "Wok том ям с морепродуктам",
                       Description = "Лапша пшеничная, креветки, кальмар, шампиньоны, лук красный, заправка Том Ям (паста Том Ям, паста Том Кха, сахар, соевый соус), сливки, соевый соус, помидор, перец чили. БЖУ на 100 г. Белки, г - 8,57 Жиры, г - 12,8 Углеводы, г - 18,8",
                       Price = 340,
                       Image = "https://mistertako.ru/uploads/products/bacd88ca-54ed-11ed-8575-0050569dbef0.jpg",
                       Vegetarian = false,
                       Rating = 5,
                       Category = Models.Dish.DishCategory.Wok

                   },
                   new Dish()
                   {
                       Id = "31101a8b-b9fa-4dbe-85c5-c6ca745064655",
                       Name = "Wok том ям с овощами",
                       Description = "Лапша пшеничная, шампиньоны, лук красный, заправка Том Ям (паста Том Ям, паста Том Кха, сахар, соевый соус), сливки, соевый соус, помидор, перец чили. БЖУ на 100 г. Белки, г - 5,32 Жиры, г - 14,89 Углеводы, г - 22,46",
                       Price = 250,
                       Image = "https://mistertako.ru/uploads/products/cd661716-54ed-11ed-8575-0050569dbef0.jpg",
                       Vegetarian = true,
                       Rating = 9,
                       Category = Models.Dish.DishCategory.Wok

                   },
                   new Dish()
                   {
                       Id = "31101a8b-b9fa-4dbe-85c5-c6ca745604255",
                       Name = "Белиссимо",
                       Description = "Копченая куриная грудка, свежие шампиньоны, маринованные опята, сыр «Моцарелла», сыр «Гауда», сливочно-чесночный соус, свежая зелень.",
                       Price = 250,
                       Image = "https://mistertako.ru/uploads/products/cd661716-54ed-11ed-8575-0050569dbef0.jpg",
                       Vegetarian = true,
                       Rating = 9,
                       Category = Models.Dish.DishCategory.Wok

                   },
                    new Dish()
                    {
                        Id = "31101a8b-b9fa-4dbe-85c5-c6ca746204655",
                        Name = "Коктейль классический",
                        Description = "Классический молочный коктейль",
                        Price = 140,
                        Image = "https://mistertako.ru/uploads/products/120b46bc-5f32-11e8-8f7d-00155dd9fd01.jpg",
                        Vegetarian = true,
                        Rating = 5.66666666,
                        Category = Models.Dish.DishCategory.Drink

                    },
                    new Dish()
                    {
                        Id = "31101a8b-b9fa-4dbe-85c5-c6ca742664655",
                        Name = "Коктейль клубничный",
                        Description = "Классический молочный коктейль с клубничным топпингом",
                        Price = 170,
                        Image = "https://mistertako.ru/uploads/products/120b46bd-5f32-11e8-8f7d-00155dd9fd01.jpg",
                        Vegetarian = true,
                        Rating = 7.765,
                        Category = Models.Dish.DishCategory.Drink

                    },
                    new Dish()
                    {
                        Id = "31101a8b-b9fa-4dbe-85c5-c6ca7426664655",
                        Name = "Коктейль шоколадный",
                        Description = "Классический молочный коктейль с добавлением шоколадного топпинга",
                        Price = 170,
                        Image = "https://mistertako.ru/uploads/products/120b46be-5f32-11e8-8f7d-00155dd9fd01.jpg",
                        Vegetarian = true,
                        Rating = 1.75,
                        Category = Models.Dish.DishCategory.Drink

                    },
                    new Dish()
                    {
                        Id = "31101a8b-b9fa-4dbe-85c5-c6ca7426664055",
                        Name = "Морс cмородиновый",
                        Description = "Смородиновый морс",
                        Price = 90,
                        Image = "https://mistertako.ru/uploads/products/120b46c1-5f32-11e8-8f7d-00155dd9fd01.jpg",
                        Vegetarian = true,
                        Rating = 8,
                        Category = Models.Dish.DishCategory.Drink

                    },
                     new Dish()
                     {
                         Id = "31101a8b-b9fa-4dbe-85c5-c6ca7462668055",
                         Name = "Морс облепиховый",
                         Description = "Облепиха, имбирь, сахар",
                         Price = 90,
                         Image = "https://mistertako.ru/uploads/products/5a7d58a5-879d-11eb-850a-0050569dbef0.jpg",
                         Vegetarian = true,
                         Rating = 6.0625,
                         Category = Models.Dish.DishCategory.Drink

                     },
                      new Dish()
                      {
                          Id = "31101a8b-b9fa-4dbe-85c5-c6ca7326668055",
                          Name = "Рамен сырный",
                          Description = "Сырный бульон с пшеничной лапшой, отварным куриным филе,помидором и сырными шариками. БЖУ на 100 г. Белки, г — 11,8 Жиры, г — 9,82 Углеводы, г — 22,69",
                          Price = 300,
                          Image = "https://mistertako.ru/uploads/products/ccd8e2de-5f36-11e8-8f7d-00155dd9fd01.jpg",
                          Vegetarian = false,
                          Rating = 3,
                          Category = Models.Dish.DishCategory.Soup

                      },
                      new Dish()
                      {
                          Id = "31101a8b-b9fa-4dbe-85c5-c6ca7326660055",
                          Name = "Сладкий ролл с апельсином и бананом",
                          Description = "Апельсин, банан, шоколадная крошка, сыр творожный, сырная лепешка. БЖУ на 100 г. Белки, г - 5,86 Жиры, г - 13,12 Углеводы, г - 44,05",
                          Price = 250,
                          Image = "https://mistertako.ru/uploads/products/05391255-54ee-11ed-8575-0050569dbef0.jpg",
                          Vegetarian = true,
                          Rating = 5,
                          Category = Models.Dish.DishCategory.Dessert

                      },
                       new Dish()
                       {
                           Id = "31101a8b-b9fa-4dbe-85c5-c6ca7326606055",
                           Name = "Сладкий ролл с апельсином и бананом",
                           Description = "Апельсин, банан, шоколадная крошка, сыр творожный, сырная лепешка. БЖУ на 100 г. Белки, г - 5,86 Жиры, г - 13,12 Углеводы, г - 44,05",
                           Price = 250,
                           Image = "https://mistertako.ru/uploads/products/05391255-54ee-11ed-8575-0050569dbef0.jpg",
                           Vegetarian = true,
                           Rating = 5,
                           Category = Models.Dish.DishCategory.Dessert

                       },
                       new Dish()
                       {
                           Id = "31101a8b-b9fa-4dbe-85c5-c6ca7226660055",
                           Name = "Сладкий ролл с арахисом и бананом",
                           Description = "Сырная лепешка, банан, арахис, сливочный сыр, шоколадная крошка, топинг карамельный",
                           Price = 210,
                           Image = "https://mistertako.ru/uploads/products/a4772f7a-7a6f-11eb-850a-0050569dbef0.jpeg",
                           Vegetarian = true,
                           Rating = 7.625,
                           Category = Models.Dish.DishCategory.Dessert

                       },
                       new Dish()
                       {
                           Id = "31101a8b-b9fa-4dbe-85c5-c6ca73267055",
                           Name = "Сладкий ролл с бананом и киви",
                           Description = "Сырная лепешка, банан, киви, сливочный сыр, топинг клубничный",
                           Price = 220,
                           Image = "https://mistertako.ru/uploads/products/9e7c8581-7a6f-11eb-850a-0050569dbef0.jpeg",
                           Vegetarian = true,
                           Rating = 5.5,
                           Category = Models.Dish.DishCategory.Dessert

                       },
                       new Dish()
                       {
                           Id = "31101a8b-b9fa-4dbe-85c5-c6ca732675555",
                           Name = "Чизкейк Нью-Йорк",
                           Description = "Чизкейк Нью-Йорк - настоящая классика. Его основа - сочетание вкусов нежнейшего сливочного сыра и тонкой песочной корочки.",
                           Price = 210,
                           Image = "https://mistertako.ru/uploads/products/120b46b1-5f32-11e8-8f7d-00155dd9fd01.jpg",
                           Vegetarian = true,
                           Rating = 9.25,
                           Category = Models.Dish.DishCategory.Dessert

                       },
                       new Dish()
                       {
                           Id = "31101a8b-b9fa-4dbe-85c5-c6ca732655555",
                           Name = "Том ям кай",
                           Description = "Знаменитый тайский острый суп со сливками, куриным филе, шампиньонами, красным луком, помидором, перчиком Чили и кинзой. Подается с рисом. БЖУ на 100 г. Белки, г — 5,75 Жиры, г — 3,72 Углеводы, г — 14,76",
                           Price = 300,
                           Image = "https://mistertako.ru/uploads/products/ccd8e2de-5f36-11e8-8f7d-00155dd9fd01.jpg",
                           Vegetarian = false,
                           Rating = 2.33333,
                           Category = Models.Dish.DishCategory.Soup

                       },
                        new Dish()
                        {
                            Id = "31101a8b-b9fa-4dbe-85c5-c6ca032655555",
                            Name = "Сливочный рамен с курицей и шампиньонами",
                            Description = "Бульон рамен со сливками (куриный бульон, чесночно-имбирная заправка, соевый соус) с пшеничной лапшой, отварной курицей, омлетом Томаго и шампиньонами. БЖУ на 100 г. Белки, г — 8,13 Жиры, г — 6,18 Углеводы, г — 8,08",
                            Price = 260,
                            Image = "https://mistertako.ru/uploads/products/ccd8e2de-5f36-11e8-8f7d-00155dd9fd01.jpg",
                            Vegetarian = false,
                            Rating = 2.33333,
                            Category = Models.Dish.DishCategory.Soup

                        }
            );
        }
    }
}
