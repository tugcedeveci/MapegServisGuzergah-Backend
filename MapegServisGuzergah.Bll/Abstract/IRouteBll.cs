using MapegServisGuzergah.Core.Entity;
using MapegServisGuzergah.Entity.Entities;
using MapegServisGuzergah.Models.Data_Transfer_Object;
using System.Linq.Expressions;


namespace MapegServisGuzergah.Bll.Abstract
{
    public interface IRouteBll : IDependency
    {
        RouteDto SaveRoute(RouteDto route, long userId);
        Route GetRoute(int routeId);
        List<Route> GetRoutes(Expression<Func<Route, bool>> expression);
        
    }
}
