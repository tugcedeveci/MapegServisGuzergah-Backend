using MapegServisGuzergah.Bll.Abstract;
using MapegServisGuzergah.Bll.Helper;
using MapegServisGuzergah.Dal.Abstract;
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
    public class RouteBll : IRouteBll
    {
        private readonly IRouteDal _routeDal;

        public RouteBll(IRouteDal routeDal) //constructor
        {
            _routeDal = routeDal;
        }

        public RouteDto SaveRoute(RouteDto routeDto, long userId)
        {
            //Insert
            var route = new Route();

            if(routeDto.RouteId == 0)
            {
                CustomMapper.Map(routeDto, route);
                route.UserCreatedId = userId;
                route.IsActive = true;
                _routeDal.Add(route);
            }
            //Update
            else
            {
                route = _routeDal.Get(x => x.RouteId == routeDto.RouteId);
                CustomMapper.Map(routeDto, route);
                route.ModifiedDate = DateTime.Now;
                route.UserModifiedId = userId;
                _routeDal.Update(route);
            }

            routeDto.RouteId = route.RouteId;
            return routeDto;
        }

        public Route GetRoute(int routeId)
        {
            return _routeDal.Get(x => x.RouteId == routeId);
        }

        public List<Route> GetRoutes(Expression<Func<Route, bool>> expression)
        {
            return _routeDal.GetAll(expression).ToList();
        }
    }
}
