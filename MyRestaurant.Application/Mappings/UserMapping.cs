using Mapster;
using MyRestaurant.Application.Commands.RegisterUser;
using MyRestaurant.Domain.Entities;
using MyRestaurant.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRestaurant.Application.Mappings;

public class UserMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterUserCommand, User>()
            .Map(dest => dest.Username, src => src.Username)
            .Map(dest => dest.Email, src => Email.Create(src.Email))
            .Map(dest => dest.PasswordHash, src => src.Password); // Password should be hashed
    }
}