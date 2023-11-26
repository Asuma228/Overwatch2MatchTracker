using System.ComponentModel.DataAnnotations.Schema;

namespace Overwatch2MatchTracker.DAL.Entities.Base
{
    public abstract class Hero : NamedEntity
    {
        [Column(TypeName = "time(7)")]
        public TimeSpan ElapsedTime { get; set; }
    }

}
