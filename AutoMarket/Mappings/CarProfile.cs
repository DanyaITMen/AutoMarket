using AutoMapper;
using AutoMarket.Web.DTOs.Car;
using AutoMarket.Web.Entities;

namespace AutoMarket.Web.Mappings
{
    public class CarProfile : Profile
    {
        public CarProfile()
        {
            // Всі правила, що стосуються Car
            CreateMap<Car, CarDto>();
            CreateMap<CreateCarDto, Car>();
            CreateMap<UpdateCarDto, Car>();
        }
    }
}