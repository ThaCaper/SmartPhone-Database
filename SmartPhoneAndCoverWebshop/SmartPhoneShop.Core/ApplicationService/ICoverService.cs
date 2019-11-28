using System.Collections.Generic;
using SmartPhoneShop.Entity;

namespace SmartPhoneShop.Core.ApplicationService
{
    public interface ICoverService
    {
        Cover CreateCover(Cover CreatedCover);
        Cover GetCoverById(int id);
        Cover DeleteCover(int id);
        List<Cover> GetAllCovers();
        Cover UpdateCover(Cover UpdateCover);

    }
}