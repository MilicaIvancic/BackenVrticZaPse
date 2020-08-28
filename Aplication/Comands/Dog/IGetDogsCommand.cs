using System;
using System.Collections.Generic;
using System.Text;
using Aplication.DTO.DogDto;
using Aplication.Interfaces;
using Aplication.Paginate;
using Aplication.Searches;

namespace Aplication.Comands.Dog
{
    public interface IGetDogsCommand:ICommand<DogSearch, PaginateResponse<GetDogsDto>>
    {
    }
}
