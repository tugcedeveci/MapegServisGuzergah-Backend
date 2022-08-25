using MapegServisGuzergah.Core.DataAccess;
using MapegServisGuzergah.Core.Entity;
using MapegServisGuzergah.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapegServisGuzergah.Dal.Abstract
{
    public interface IUserDal : IEntityRepository<User>, IDependency
    {
    }
}
