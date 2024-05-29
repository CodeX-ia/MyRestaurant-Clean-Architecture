using Mapster;
using MyRestaurant.Application.Commands.CreateMenu;
using MyRestaurant.Application.Commands.CreateMenuItem;
using MyRestaurant.Application.Commands.UpdateMenu;
using MyRestaurant.Application.Commands.UpdateMenuItem;
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
        config.NewConfig<Menu, MenuResponse>();
        config.NewConfig<MenuItem, MenuItemResponse>();

        config.NewConfig<CreateMenuCommand, Menu>();
        config.NewConfig<CreateMenuItemCommand, MenuItem>();

        config.NewConfig<UpdateMenuCommand, Menu>();
        config.NewConfig<UpdateMenuItemCommand, MenuItem>();
    }
}
