using AutoMapper;
using AutoMarket.Repositories.Interfaces;
using AutoMarket.Web.DTOs.Car;
using AutoMarket.Web.Entities;
using AutoMarket.Web.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMarket.Web.Helpers;      // <-- Додай
using Microsoft.EntityFrameworkCore; // <-- Додай
using System.Linq;

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

        public async Task<IEnumerable<CarDto>> GetAllAsync(CarParameters carParameters)
{
    // Починаємо з IQueryable, щоб будувати запит динамічно
    IQueryable<Car> query = _unitOfWork.Context.Cars
        .Include(c => c.Category)
        .Include(c => c.User);

    // 1. ФІЛЬТРУВАННЯ
    if (!string.IsNullOrEmpty(carParameters.Brand))
    {
        query = query.Where(c => c.Brand.ToLower() == carParameters.Brand.ToLower());
    }
    if (carParameters.MaxPrice.HasValue)
    {
        query = query.Where(c => c.Price <= carParameters.MaxPrice.Value);
    }
    if (carParameters.Year.HasValue)
    {
        query = query.Where(c => c.Year == carParameters.Year.Value);
    }

    // 2. СОРТУВАННЯ
    if (!string.IsNullOrEmpty(carParameters.OrderBy))
    {
        switch (carParameters.OrderBy.ToLower())
        {
            case "price_desc":
                query = query.OrderByDescending(c => c.Price);
                break;
            case "price_asc":
                query = query.OrderBy(c => c.Price);
                break;
            case "year_desc":
                query = query.OrderByDescending(c => c.Year);
                break;
            default:
                query = query.OrderBy(c => c.Year);
                break;
        }
    } else 
    {
        query = query.OrderByDescending(c => c.Id);
    }

    // 3. ПАГІНАЦІЯ
    var cars = await query
        .Skip((carParameters.PageNumber - 1) * carParameters.PageSize)
        .Take(carParameters.PageSize)
        .ToListAsync();
        
    return _mapper.Map<IEnumerable<CarDto>>(cars);
}

    }
}