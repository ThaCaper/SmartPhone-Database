using System.Collections.Generic;
using SmartPhoneShop.Entity;

namespace SmartPhoneShop.Core.DomainService
{
    public interface ICoverRepository
    {
        Cover CreateCover(Cover createdCover);

        List<Cover> GetAllCovers();

        Cover GetCoverById(int id);

        Cover UpdateCover(Cover updatedCover);

        Cover DeleteCover(int id);
    }
}