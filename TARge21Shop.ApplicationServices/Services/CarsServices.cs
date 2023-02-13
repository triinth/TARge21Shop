using Microsoft.EntityFrameworkCore;
using TARge21Shop.Core.Domain.Car;
using TARge21Shop.Core.Dto;
using TARge21Shop.Core.ServiceInterface;
using TARge21Shop.Data;

namespace TARge21Shop.ApplicationServices.Services
{
    public class CarsServices : ICarsServices
    {
        private readonly TARge21ShopContext _context;
        private readonly IFilesServices _files;
        public CarsServices
            (
            TARge21ShopContext context,
            IFilesServices files
            )
        {
            _context = context;
            _files = files;
        }

        public async Task<Car> Create(CarDto dto)
        {
            var car = new Car()
            {
                Id = Guid.NewGuid(),
                Brand = dto.Brand,
                Model = dto.Model,
                Color = dto.Color,
                FuelType = dto.FuelType,
                Price = dto.Price,
                EnginePower = dto.EnginePower,
                Mileage = dto.Mileage,
                PreviousOwners = dto.PreviousOwners,
                BuiltDate = DateTime.Now,
                MaintanceDate = DateTime.Now

            };

			if (dto.Files != null)
			{
				_files.UploadFilesToDatabase(dto, car);
			}


			await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();
            return car;
        }

        public async Task<Car> Update(CarDto dto)
        {
            var car = new Car()
            {
                Id = dto.Id,
                Brand = dto.Brand,
                Model = dto.Model,
                Color = dto.Color,
                FuelType = dto.FuelType,
                Price = dto.Price,
                EnginePower = dto.EnginePower,
                Mileage = dto.Mileage,
                PreviousOwners = dto.PreviousOwners,
                BuiltDate = dto.BuiltDate,
                MaintanceDate = dto.MaintanceDate
            };

			if (dto.Files != null)
			{
				_files.UploadFilesToDatabase(dto, car);
			}

			_context.Cars.Update(car);
            await _context.SaveChangesAsync();
            return car;


        }


		public async Task<Car> Delete(Guid id)
		{
			var carId = await _context.Cars
				.FirstOrDefaultAsync(x => x.Id == id);

			var images = await _context.FileToDatabases
				.Where(x => x.CarId == id)
				.Select(y => new FileToDatabaseDto
				{
					Id = y.Id,
					ImageTitle = y.ImageTitle,
					CarId = y.CarId,
				})
				.ToArrayAsync();

			await _files.RemoveImagesFromDatabase(images);
			_context.Cars.Remove(carId);
			await _context.SaveChangesAsync();

			return carId;
		}

		public async Task<Car> GetAsync(Guid id)
        {
            var result = await _context.Cars
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }
    }
}
