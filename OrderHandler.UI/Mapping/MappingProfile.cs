using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderHandler.UI.Models;
using AutoMapper;
using OrderHandler.Core.Models;

namespace OrderHandler.UI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Resource
            CreateMap<Article, ArticleViewModel>();
            CreateMap<Order, OrderViewModel1>();

            // Resource to Domain
            CreateMap<OrderRow, OrderRowViewModel>(); //Todo config map profile. 
        }
    }
}
