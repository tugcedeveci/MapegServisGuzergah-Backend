using MapegServisGuzergah.Bll.Abstract;
using MapegServisGuzergah.Bll.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapegServisGuzergah.Bll
{
    public static class IocBusiness
    {
        public static void IoCBusinessLayerRegister(this IServiceCollection service)
        {
            service.AddTransient<IRouteBll, RouteBll>();
            service.AddTransient<IVoyageBll, VoyageBll>();
            service.AddTransient<ILocationBll, LocationBll>();
            service.AddTransient<IVehicleBll, VehicleBll>();
            service.AddTransient<IStationBll, StationBll>();
        }
    }
}
