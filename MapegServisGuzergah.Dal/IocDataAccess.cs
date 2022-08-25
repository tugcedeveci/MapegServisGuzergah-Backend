using MapegServisGuzergah.Dal.Abstract;
using MapegServisGuzergah.Dal.Concrete.EntityFramework.Dal;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapegServisGuzergah.Dal
{
    public static class IocDataAccess
    {
        /// <summary>
        /// Ioes the c data access layer register.
        /// </summary>
        /// <param name="service">The service.</param>
        public static void IoCDataAccessLayerRegister(this IServiceCollection service)
        {
            service.AddTransient<ILocationDal, LocationDal>();
            service.AddTransient<IRouteDal, RouteDal>();
            service.AddTransient<IStationDal, StationDal>();
            service.AddTransient<IUserDal, UserDal>();
            service.AddTransient<IVehicleDal, VehicleDal>();
            service.AddTransient<IVoyageDal, VoyageDal>();
            service.AddTransient<IVoyageStationDal, VoyageStationDal>();
        }
    }
}
