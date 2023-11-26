using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Overwatch2MatchTracker.DAL.Entities.Base;

namespace Overwatch2MatchTracker.DAL.Entities
{
    public class Game : NamedEntity
    {
        public virtual Mode Mode { get; set; }  
        public virtual ICollection<Hero> Heroes { get; set; }
        public virtual Map Map { get; set; }
        public virtual ICollection<SpecificPlayer> SpecificPlayers { get; set; }
        public virtual GroupSize GroupSize { get; set; }
        public virtual MatchResult MatchResult { get; set; }
    }
}
