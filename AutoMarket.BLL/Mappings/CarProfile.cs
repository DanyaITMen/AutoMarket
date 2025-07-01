using AutoMapper;
using AutoMarket.BLL.DTOs.Car;
using AutoMarket.DAL.Entities;

namespace AutoMarket.BLL.Mappings
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