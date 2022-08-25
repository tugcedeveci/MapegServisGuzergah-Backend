using MapegServisGuzergah.Core.Entity;
using MapegServisGuzergah.Entity.Entities;
using MapegServisGuzergah.Models.Data_Transfer_Object;
using System.Linq.Expressions;


namespace MapegServisGuzergah.Bll.Abstract
{
    public interface IStationBll : IDependency
    {
        StationDto SaveStation(StationDto station,long user);
        Station GetStation(int stationId);
        List<Station> GetStations(Expression<Func<Station, bool>> expression);
    }
    
}
