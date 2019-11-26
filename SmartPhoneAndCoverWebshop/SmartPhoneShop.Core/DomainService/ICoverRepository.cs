using System.Collections.Generic;
using SmartPhoneShop.Entity;

namespace SmartPhoneShop.Core.DomainService
{
    public interface ICoverRepository
    {
        Cover CreateCover(Cover CreatedCover);

        List<Cover> GetAllCovers();

        Cover GetCoverById(int id);

        Cover UpdateCover(Cover UpdateCover);

        Cover DeleteCover(int id);
    }
}