using System.Collections.Generic;
using SmartPhoneShop.Core.DomainService;
using SmartPhoneShop.Entity;

namespace SmartPhoneShop.Core.ApplicationService.impl
{
    public class CoverService : ICoverService
    {
        private ICoverRepository _CoverRepository;
        public Cover CreateCover(Cover CreatedCover)
        {
            return _CoverRepository.CreateCover(CreatedCover);
        }

        public Cover DeleteCover(int id)
        {
            return _CoverRepository.DeleteCover(id);
        }

        public List<Cover> GetAllCovers()
        {
            return _CoverRepository.GetAllCovers();
        }

        public Cover GetCoverById(int id)
        {
            return _CoverRepository.GetCoverById(id);
        }

        public Cover UpdateCover(Cover UpdateCover)
        {
            return _CoverRepository.UpdateCover(UpdateCover);
        }
    }
}