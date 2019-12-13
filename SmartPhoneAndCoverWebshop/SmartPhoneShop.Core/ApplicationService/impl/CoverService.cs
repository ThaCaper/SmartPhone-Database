using System;
using System.Collections.Generic;
using System.IO;
using SmartPhoneShop.Core.DomainService;
using SmartPhoneShop.Entity;

namespace SmartPhoneShop.Core.ApplicationService.impl
{
    public class CoverService : ICoverService
    {
        private ICoverRepository _coverRepository;

        public CoverService(ICoverRepository coverRepo)
        {
            _coverRepository = coverRepo;
        }

        public Cover CreateCover(Cover CreatedCover)
        {
            if (string.IsNullOrEmpty(CreatedCover.Name))
            {
                throw new InvalidDataException("Must have a product name");
            }

            if (string.IsNullOrEmpty(CreatedCover.Color))
            {
                throw new InvalidDataException("Everything has a color, so it must have a color");
            }

            if (string.IsNullOrEmpty(CreatedCover.Material))
            {
                throw new InvalidDataException("Must be made with a material");
            }

            if (string.IsNullOrEmpty(CreatedCover.TypeOfBrand))
            {
                throw new InvalidDataException("Must have a brand for this cover");
            }

            if (string.IsNullOrEmpty(CreatedCover.TypeOfModel))
            {
                throw new InvalidDataException("Must have a Phone Model to this Cover");
            }

            if (CreatedCover.Price <= 0)
            {
                throw new InvalidDataException("Must have a price");
            }

            return _coverRepository.CreateCover(CreatedCover);
        }

        public Cover DeleteCover(int id)
        {
            if (_coverRepository.DeleteCover(id) == null)
            {
                throw new InvalidDataException("No Cover with id: " + id + " exist");
            }
            return _coverRepository.DeleteCover(id);
        }

        public List<Cover> GetAllCovers()
        {
            return _coverRepository.GetAllCovers();
        }

        public Cover GetCoverById(int id)
        {
            if (_coverRepository.GetCoverById(id) == null)
            {
                throw new InvalidDataException("Can't find Cover with the id: " + id);
            }
            return _coverRepository.GetCoverById(id);
        }

        public Cover UpdateCover(Cover UpdateCover)
        {
            if (string.IsNullOrEmpty(UpdateCover.Name))
            {
                throw new InvalidDataException("Must have a name");
            }
            if (string.IsNullOrEmpty(UpdateCover.Color))
            {
                throw new InvalidDataException("Everything has a color, so it must have a color");
            }

            if (string.IsNullOrEmpty(UpdateCover.Material))
            {
                throw new InvalidDataException("Must be made with a material");
            }

            if (string.IsNullOrEmpty(UpdateCover.TypeOfBrand))
            {
                throw new InvalidDataException("Must have a brand for this cover");
            }

            if (string.IsNullOrEmpty(UpdateCover.TypeOfModel))
            {
                throw new InvalidDataException("Must have a Phone Model to this Cover");
            }

            if (UpdateCover.Price <= 0)
            {
                throw new InvalidDataException("Must have a price");
            }
            return _coverRepository.UpdateCover(UpdateCover);
        }
    }
}