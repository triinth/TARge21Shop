﻿using TARge21Shop.Core.Domain.Car;
using TARge21Shop.Core.Dto;

namespace TARge21Shop.Core.ServiceInterface
{
    public interface ICarsServices
    {
        Task<Car> Create(CarDto dto);

        Task<Car> Update(CarDto dto);

        Task<Car> Delete(Guid id);

        Task<Car> GetAsync(Guid id);
    }
}
