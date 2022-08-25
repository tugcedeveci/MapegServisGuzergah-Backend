using MapegServisGuzergah.Bll.Abstract;
using MapegServisGuzergah.Dal.Abstract;
using MapegServisGuzergah.Entity.Entities;
using System.Linq.Expressions;

namespace MapegServisGuzergah.Bll.Concrete
{
    internal class LocationBll : ILocationBll
    {
        private readonly ILocationDal _locationDal;

        public LocationBll(ILocationDal locationDal) //constructor
        {
            _locationDal = locationDal;
        }

        public Location SaveLocation(Location location)
        {
            //Add
            if (location.LocationId == 0)
            {
                location.CreatedDate = DateTime.Now;
                _locationDal.Add(location);
            }
            //Update
            else
            {
                location.ModifiedDate = DateTime.Now;
                _locationDal.Update(location);
            }

            return location;
        }
        public Location GetLocation(int locationId)
        {
            return _locationDal.Get(x => x.LocationId == locationId);
        }

        public List<Location> GetLocations(Expression<Func<Location, bool>> expression)
        {
            return _locationDal.GetAll(expression).ToList();
        }     
    }
}
