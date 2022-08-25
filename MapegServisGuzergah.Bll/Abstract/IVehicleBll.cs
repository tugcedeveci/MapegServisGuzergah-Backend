using MapegServisGuzergah.Core.Entity;
using MapegServisGuzergah.Entity.Entities;
using MapegServisGuzergah.Models.Data_Transfer_Object;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace MapegServisGuzergah.Bll.Abstract
{
    public interface IVehicleBll : IDependency
    {
        VehicleDto SaveVehicle(VehicleDto vehicle,long userId);
        Vehicle GetVehicle(int vehicleId);
        List<Vehicle> GetVehicleList(Expression<Func<Vehicle, bool>> expression);
    }
}
