using MapegServisGuzergah.Core.DataAccess.EntityFramework;
using MapegServisGuzergah.Dal.Abstract;
using MapegServisGuzergah.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapegServisGuzergah.Dal.Concrete.EntityFramework.Dal
{
    public class LocationDal : EntityRepositoryBase<EntityFrameworkDbContext, Location>, ILocationDal
    {
    }
}
