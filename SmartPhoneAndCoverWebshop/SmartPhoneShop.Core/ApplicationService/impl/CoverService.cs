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
            if (CreatedCover.Name == null)
            {
                throw new InvalidDataException("Must have a product name");
            }

            if (CreatedCover.Color == null)
            {
                throw new InvalidDataException("Everything has a color, so it must have a color");
            }

            if (CreatedCover.Material == null)
            {
                throw new InvalidDataException("Must be made with a material");
            }

            if (CreatedCover.TypeOfBrand == null)
            {
                throw new InvalidDataException("Must have a brand for this cover");
            }


            if (CreatedCover.TypeOfModel == null)
            {
                throw new InvalidDataException("Must have a Phone Model to this Cover");
            }

            if (CreatedCover.Price.Equals(null))
            {
                throw new InvalidDataException("Must have a price");
            }
            return _coverRepository.CreateCover(CreatedCover);
        }

        public Cover DeleteCover(int id)
        {
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
            return _coverRepository.UpdateCover(UpdateCover);
        }
    }
}