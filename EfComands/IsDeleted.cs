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
        // obezbediti da se sve brise nakon nor mesec dana???

        public static bool Deleted(BaseEntity entity, BaseDto dto)
        {

            //kako obezbediti da amin moze da vrati obrisan nalog? a da ne moze da se menja obrisan
            //vec da moze samo da se vrati obrisan i kada se vrati on postaje 
            //standardni nalog koji moze da se menja
            if (entity.IsDeleted == true && dto.IsDeleted == false)
            {

                  entity.IsDeleted = false;
                    //  moze li da se odradi user friendi exception ili nekako da prekinem kod ?
                    //necu da dozvolim da uz vracanje moze da se radi update
                    //jer ni jedan normalan administrator nece uradi
                    //da li je ovo ikakva vrsta zastite?

                  return true;


            }
            return false;
        }
    }
}
