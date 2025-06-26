using AutoMarket.Web.Entities;
using AutoMarket.Web.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AutoMarket.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CarsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET /api/cars — отримати всі машини (Read All)
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var cars = await _unitOfWork.Cars.GetAllAsync();
            return Ok(cars);
        }

        // GET /api/cars/{id} — отримати одну машину по ID (Read One)
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var car = await _unitOfWork.Cars.GetByIdAsync(id);
            if (car == null) return NotFound();
            return Ok(car);
        }

        // GET /api/cars/by-brand/{brand} — отримати машини по бренду (фільтр)
        [HttpGet("by-brand/{brand}")]
        public async Task<IActionResult> GetByBrand(string brand)
        {
            var cars = await _unitOfWork.CarRepository.GetByBrandAsync(brand);
            if (!cars.Any()) return NotFound();
            return Ok(cars);
        }

        // POST /api/cars — створити нову машину (Create)
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Car car)
        {
            if (car == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _unitOfWork.Cars.AddAsync(car);
            await _unitOfWork.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = car.Id }, car);
        }

        // PUT /api/cars/{id} — оновити машину (Update)
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Car car)
        {
            if (car == null || id != car.Id || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingCar = await _unitOfWork.Cars.GetByIdAsync(id);
            if (existingCar == null) return NotFound();

            // оновлення властивостей машини
            existingCar.Brand = car.Brand;
            existingCar.Model = car.Model;
            existingCar.Year = car.Year;
            existingCar.Price = car.Price;
            existingCar.Mileage = car.Mileage;
            existingCar.Description = car.Description;
            existingCar.CategoryId = car.CategoryId;
            existingCar.Region = car.Region;
            existingCar.ImageUrl = car.ImageUrl;
            existingCar.UserId = car.UserId;

            _unitOfWork.Cars.Update(existingCar);
            await _unitOfWork.SaveChangesAsync();
            return NoContent();
        }

        // DELETE /api/cars/{id} — видалити машину (Delete)
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var car = await _unitOfWork.Cars.GetByIdAsync(id);
            if (car == null) return NotFound();
            _unitOfWork.Cars.Delete(car);
            await _unitOfWork.SaveChangesAsync();
            return NoContent();
        }
    }
}
