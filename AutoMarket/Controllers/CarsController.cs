using AutoMarket.Web.DTOs.Car;
using AutoMarket.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AutoMarket.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        // ЗАМІНЮЄМО IUnitOfWork на ICarService
        private readonly ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        /// <summary>
        /// Отримує список всіх автомобілів.
        /// </summary>
        /// <returns>Список автомобілів у форматі DTO</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Просто викликаємо сервіс
            var cars = await _carService.GetAllAsync();
            return Ok(cars);
        }

        /// <summary>
        /// Отримує автомобіль за його унікальним ідентифікатором (ID).
        /// </summary>
        /// <param name="id">Ідентифікатор автомобіля</param>
        /// <returns>Інформація про автомобіль у форматі DTO</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var car = await _carService.GetByIdAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            return Ok(car);
        }

        // Метод GetByBrand, якщо він потрібен, теж треба перенести в ICarService
        // і реалізувати там, а потім викликати звідси.
        // Для спрощення я його поки прибрав, оскільки він не є стандартним CRUD.

        /// <summary>
        /// Створює нове оголошення про продаж автомобіля.
        /// </summary>
        /// <param name="carDto">Дані для створення нового автомобіля</param>
        /// <returns>Щойно створений автомобіль</returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCarDto carDto)
        {
            // Вхідний параметр тепер CreateCarDto
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdCar = await _carService.CreateAsync(carDto);
            // Повертаємо повний CarDto
            return CreatedAtAction(nameof(GetById), new { id = createdCar.Id }, createdCar);
        }

        /// <summary>
        /// Оновлює існуюче оголошення про автомобіль.
        /// </summary>
        /// <param name="id">ID автомобіля, який оновлюється</param>
        /// <param name="carDto">Нові дані для автомобіля</param>
        /// <returns>Нічого, якщо успішно</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCarDto carDto)
        {
            // Вхідний параметр тепер UpdateCarDto
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _carService.UpdateAsync(id, carDto);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            return NoContent();
        }

        /// <summary>
        /// Видаляє оголошення про автомобіль.
        /// </summary>
        /// <param name="id">ID автомобіля для видалення</param>
        /// <returns>Нічого, якщо успішно</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _carService.DeleteAsync(id);
            return NoContent();
        }
    }
}