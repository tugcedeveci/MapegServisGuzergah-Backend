using MapegServisGuzergah.Core.Entity;
using MapegServisGuzergah.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MapegServisGuzergah.Bll.Abstract
{
    public interface ILocationBll : IDependency
    {
        Location SaveLocation(Location location);
        Location GetLocation(int locationId);
        List<Location> GetLocations(Expression<Func<Location, bool>> expression);
    }
}
