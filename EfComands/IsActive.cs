using Aplication.DTO;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfComands
{
    public static class IsActive
    {
        public static bool Actived(BaseEntity entity, BaseDto dto)
        {

            if (entity.IsActive!=dto.IsActive )
            {
                return true;
            }
            return false;
        }
    }
}
