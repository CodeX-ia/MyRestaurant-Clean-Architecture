using Mapster;
using MyRestaurant.Application.Commands.CreateMenu;
using MyRestaurant.Application.Commands.UpdateMenu;
using MyRestaurant.Application.Response;
using MyRestaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRestaurant.Application.Mappings;

public class MenuMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateMenuCommand, Menu>();
        config.NewConfig<UpdateMenuCommand, Menu>();
        config.NewConfig<Menu, MenuResponse>();
    }
}
