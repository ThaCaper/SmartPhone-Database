using System.Collections.Generic;
using SmartPhoneShop.Entity;

namespace SmartPhoneShop.Core.ApplicationService
{
    public interface ICoverService
    {
        Cover CreateCover(Cover createdCover);

        Cover GetCoverById(int id);
        
        Cover DeleteCover(int id);
        
        List<Cover> GetAllCovers();
        
        Cover UpdateCover(Cover updatedCover);

    }
}