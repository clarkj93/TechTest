using System;

namespace Repository.DataModels.Interfaces
{
    public interface IStoreable
    {
        IComparable Id { get; set; }
    }
    
}