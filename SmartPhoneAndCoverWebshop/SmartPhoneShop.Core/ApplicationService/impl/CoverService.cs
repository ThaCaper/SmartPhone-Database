using System.Collections.Generic;
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
            return _coverRepository.GetCoverById(id);
        }

        public Cover UpdateCover(Cover UpdateCover)
        {
            return _coverRepository.UpdateCover(UpdateCover);
        }
    }
}