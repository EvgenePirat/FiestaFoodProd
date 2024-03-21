using AutoMapper;
using Business.Models.Quantity.Request;
using Business.Models.Quantity.Response;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mappers
{
    public class QuantityProfile : Profile
    {
        public QuantityProfile()
        {
            CreateMap<CreateQuantityModel, Quantity>();
            CreateMap<UpdateQuantityModel, Quantity>();
            CreateMap<Quantity, QuantityModel>();
        }
    }
}
