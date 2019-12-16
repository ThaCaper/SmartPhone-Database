using System.Collections.Generic;
using System.IO;
using SmartPhoneShop.Core.DomainService;
using SmartPhoneShop.Entity;

namespace SmartPhoneShop.Core.ApplicationService.impl
{
    public class CoverService : ICoverService
    {
        private readonly ICoverRepository _coverRepository;

        public CoverService(ICoverRepository coverRepo)
        {
            _coverRepository = coverRepo;
        }

        public Cover CreateCover(Cover createdCover)
        {
            if (string.IsNullOrEmpty(createdCover.Name)) 
                throw new InvalidDataException("Must have a product name");

            if (string.IsNullOrEmpty(createdCover.Color))
                throw new InvalidDataException("Everything has a color, so it must have a color");

            if (string.IsNullOrEmpty(createdCover.Material))
                throw new InvalidDataException("Must be made with a material");

            if (string.IsNullOrEmpty(createdCover.TypeOfBrand))
                throw new InvalidDataException("Must have a brand for this cover");

            if (string.IsNullOrEmpty(createdCover.TypeOfModel))
                throw new InvalidDataException("Must have a Phone Model to this Cover");

            if (createdCover.Price <= 0) throw new InvalidDataException("Must have a price");

            return _coverRepository.CreateCover(createdCover);
        }

        public Cover DeleteCover(int id)
        {
            if (_coverRepository.DeleteCover(id) == null)
                throw new InvalidDataException("No Cover with id: " + id + " exist");
            return _coverRepository.DeleteCover(id);
        }

        public List<Cover> GetAllCovers()
        {
            return _coverRepository.GetAllCovers();
        }

        public Cover GetCoverById(int id)
        {
            if (_coverRepository.GetCoverById(id) == null)
                throw new InvalidDataException("Can't find Cover with the id: " + id);
            return _coverRepository.GetCoverById(id);
        }

        public Cover UpdateCover(Cover updatedCover)
        {
            if (string.IsNullOrEmpty(updatedCover.Name)) 
                throw new InvalidDataException("Must have a name");

            if (string.IsNullOrEmpty(updatedCover.Color))
                throw new InvalidDataException("Everything has a color, so it must have a color");

            if (string.IsNullOrEmpty(updatedCover.Material))
                throw new InvalidDataException("Must be made with a material");

            if (string.IsNullOrEmpty(updatedCover.TypeOfBrand))
                throw new InvalidDataException("Must have a brand for this cover");

            if (string.IsNullOrEmpty(updatedCover.TypeOfModel))
                throw new InvalidDataException("Must have a Phone Model to this Cover");

            if (updatedCover.Price <= 0) throw new InvalidDataException("Must have a price");

            return _coverRepository.UpdateCover(updatedCover);
        }
    }
}