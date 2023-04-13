namespace WebApi.Helpers;

using AutoMapper;
using WebApi.Entities;
using WebApi.Models.Dish;
using WebApi.Models.Order;
using WebApi.Models.Users;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        // User -> TokenResponse
        CreateMap<Users, TokenResponse>();

        // UserRegisterModel -> User
        CreateMap<UserRegisterModel, Users>();

        CreateMap<Order, OrderCreateDto>();
        CreateMap<Order, OrderDto>();


        CreateMap<Dish, DishPagedListDto>();
        // UserEditModel -> User
        CreateMap<UserEditModel, Users>()
            .ForAllMembers(x => x.Condition(
                (src, dest, prop) =>
                {
                    // ignore null & empty string properties
                    if (prop == null) return false;
                    if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                    return true;
                }
            ));
    }
}