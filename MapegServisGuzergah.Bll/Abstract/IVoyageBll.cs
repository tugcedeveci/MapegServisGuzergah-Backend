using MapegServisGuzergah.Core.Entity;
using MapegServisGuzergah.Entity.Entities;
using System.Linq.Expressions;
using MapegServisGuzergah.Models.Data_Transfer_Object;

namespace MapegServisGuzergah.Bll.Abstract
{
    public interface IVoyageBll : IDependency
    {
        User GetUser(int userId);
        User SaveUserVoyage(User user);
        VoyageDto SaveVoyage(VoyageDto voyage,long userId);
        List<Voyage> GetVoyageList(Expression<Func<Voyage, bool>> expression);
        Voyage GetVoyage(int voyageId);


        // VoyageStation GetVoyageStation(int voyageStationId);

        VoyageStations SaveVoyageStations(VoyageStations voyageStations);
        List<VoyageStations> GetVoyageStationByVoyageIdList(int VoyageId);

        List<VoyageStations> GetVoyageStationByStationIdList(int StationId);
    }
}
