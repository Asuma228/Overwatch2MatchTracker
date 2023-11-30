using System.ComponentModel.DataAnnotations;

namespace Overwatch2MatchTracker.DAL.Entities.Base
{
    public abstract class NamedEntity : Entity
    {
        //[Required]
        public string Name { get; set; }
    }

}
