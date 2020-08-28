using Aplication.DTO;
using Aplication.Exceptions;
using Domain;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfComands
{
    public static class IsDeleted
    {
        

        public static bool Deleted(BaseEntity entity, BaseDto dto)
        {

          
            if (entity.IsDeleted == true && dto.IsDeleted == false)
            {

                  entity.IsDeleted = false;
                  

                  return true;


            }
            return false;
        }
    }
}
