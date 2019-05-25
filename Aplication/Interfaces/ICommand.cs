using Aplication.DTO;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Interfaces
{

    public interface ICommand<TRequest>
    {
        void Execute(TRequest request, Func<BaseEntity, BaseDto, bool> model = null);
    }

    public interface ICommand<TRequest, TResult>
    {

        TResult Execute(TRequest request);
    }


    //public interface IRepository<T, TInsert>
    //{
    //    T[] Get();
    //    T Get(int id);

    //    Create(TInsert dto);
    //    Update(int id, TUpade dto);

    //    Delete(int id);

    //}

}
