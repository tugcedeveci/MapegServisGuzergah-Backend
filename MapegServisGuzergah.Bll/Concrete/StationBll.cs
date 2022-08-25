using MapegServisGuzergah.Bll.Abstract;
using MapegServisGuzergah.Bll.Helper;
using MapegServisGuzergah.Dal.Abstract;
using MapegServisGuzergah.Dal.Concrete.EntityFramework.Dal;
using MapegServisGuzergah.Entity.Entities;
using MapegServisGuzergah.Models.Data_Transfer_Object;
using System.Linq.Expressions;


namespace MapegServisGuzergah.Bll.Concrete
{
    public class StationBll : IStationBll
    {
        private readonly IStationDal _stationDal;
        public StationBll(IStationDal stationDal)
        {
            _stationDal = stationDal;
        }

        public StationDto SaveStation(StationDto stationDto, long userId)
        {
            //Insert
            var station = new Station();

            if (stationDto.StationId == 0)
            {
                CustomMapper.Map(stationDto, station);
                station.UserCreatedId = userId;
                station.IsActive = true;
                _stationDal.Add(station);
            }
            //Update
            else
            {
                station = _stationDal.Get(x => x.StationId == stationDto.StationId);
                CustomMapper.Map(stationDto, station);
                station.ModifiedDate = DateTime.Now;
                station.UserModifiedId = userId;
                _stationDal.Update(station);
            }

            stationDto.StationId = station.StationId;
            return stationDto;
        }
        public Station GetStation(int stationId)
        {
            return _stationDal.Get(x => x.StationId == stationId);
        }
        public List<Station> GetStations(Expression<Func<Station, bool>> expression)
        {
            return _stationDal.GetAll(expression).ToList();
        }
    }
}
