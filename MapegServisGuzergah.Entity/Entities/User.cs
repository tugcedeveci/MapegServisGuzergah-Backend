using MapegServisGuzergah.Core.Entity;
using System.ComponentModel.DataAnnotations.Schema;


namespace MapegServisGuzergah.Entity.Entities
{
    public class User : BaseEntity, IEntity
    {
        public object voyageStationId;

        public long UserId { get; set; }

        public int VoyageId { get; set; }

        public virtual Voyage? Voyage { get; set; }
    }
}
