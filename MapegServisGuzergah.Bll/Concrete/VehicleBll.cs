using MapegServisGuzergah.Bll.Abstract;
using MapegServisGuzergah.Bll.Helper;
using MapegServisGuzergah.Dal.Abstract;
using MapegServisGuzergah.Dal.Concrete.EntityFramework.Dal;
using MapegServisGuzergah.Entity.Entities;
using MapegServisGuzergah.Models.Data_Transfer_Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace MapegServisGuzergah.Bll.Concrete
{
    public class VehicleBll : IVehicleBll
    {
        private readonly IVehicleDal _vehicleDal;

        public VehicleBll(IVehicleDal vehicleDal)
        {
            _vehicleDal = vehicleDal;
        }

        //Save
        public VehicleDto SaveVehicle(VehicleDto vehicleDto, long userId)
        {
            //Insert
            var vehicle = new Vehicle();

            if (vehicleDto.VehicleId == 0)
            {
                CustomMapper.Map(vehicleDto, vehicle);
                vehicle.UserCreatedId = userId;
                vehicle.IsActive = true;
                _vehicleDal.Add(vehicle);
            }
            //Update
            else
            {
                vehicle = _vehicleDal.Get(x => x.VehicleId == vehicleDto.VehicleId);
                CustomMapper.Map(vehicleDto, vehicle);
                vehicle.ModifiedDate = DateTime.Now;
                vehicle.UserModifiedId = userId;
                _vehicleDal.Update(vehicle);
            }

            vehicleDto.VehicleId = vehicle.VehicleId;
            return vehicleDto;
        }
        //Get
        public Vehicle GetVehicle(int vehicleId)
        {
            return _vehicleDal.Get(x => x.VehicleId == vehicleId);
        }

        //List
        public List<Vehicle> GetVehicleList(Expression<Func<Vehicle, bool>> expression)
        {
            return _vehicleDal.GetAll(expression).ToList();
        }

  
    }
}
