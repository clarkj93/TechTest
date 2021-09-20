using Repository.DataModels.Interfaces;
using System;

namespace Repository.DataModels
{
    public class Vehicle: Entity
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }

        public Vehicle(int id) : base(id)
        { }
    }
}
