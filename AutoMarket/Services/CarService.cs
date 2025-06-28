using AutoMapper;
using AutoMarket.Web.DTOs.Car;
using AutoMarket.Web.Entities;
using AutoMarket.Web.Repositories;
using AutoMarket.Web.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoMarket.Web.Services
{
    // Цей клас реалізує контракт ICarService
    public class CarService : ICarService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        // Через конструктор ми отримуємо доступ до бази даних (UnitOfWork)
        // і до нашого маппера (IMapper)
        public CarService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CarDto>> GetAllAsync()
        {
            // 1. Отримати дані з бази
            var cars = await _unitOfWork.Cars.GetAllAsync(c => c.Category, c => c.User);
            // 2. Перетворити (змапити) їх в DTO і повернути
            return _mapper.Map<IEnumerable<CarDto>>(cars);
        }

        public async Task<CarDto> GetByIdAsync(int id)
        {
            var car = await _unitOfWork.CarRepository.GetByIdWithDetailsAsync(id);
            return _mapper.Map<CarDto>(car);
        }

        public async Task<CarDto> CreateAsync(CreateCarDto carDto)
        {
            // 1. Перетворити DTO від клієнта в сутність для бази даних
            var carEntity = _mapper.Map<Car>(carDto);

            // 2. Додати в базу і зберегти зміни
            await _unitOfWork.Cars.AddAsync(carEntity);
            await _unitOfWork.SaveChangesAsync();

            // 3. Перетворити створену сутність назад в DTO для відповіді клієнту
            return _mapper.Map<CarDto>(carEntity);
        }

        public async Task UpdateAsync(int id, UpdateCarDto carDto)
        {
            var existingCar = await _unitOfWork.Cars.GetByIdAsync(id);
            if (existingCar == null)
            {
                // Якщо машини не знайдено, можна кинути виключення.
                // Контролер його зловить і поверне 404 Not Found.
                throw new KeyNotFoundException($"Car with id {id} not found");
            }

            // AutoMapper оновить поля існуючого об'єкта 'existingCar'
            // даними з 'carDto'.
            _mapper.Map(carDto, existingCar);

            _unitOfWork.Cars.Update(existingCar);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var car = await _unitOfWork.Cars.GetByIdAsync(id);
            if (car != null)
            {
                _unitOfWork.Cars.Delete(car);
                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}