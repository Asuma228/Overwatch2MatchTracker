using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overwatch2MatchTracker.DAL.Entities.Base
{
    public abstract class Entity
    {
        public int Id { get; set; }
    }

    public abstract class NamedEntity : Entity
    {
        //[Required]
        public string Name { get; set; }
    }

    public abstract class Hero : NamedEntity
    {
    }

    public abstract class Map : NamedEntity
    {
    }

    public abstract class  Mode : NamedEntity
    {  
    }

    public abstract class SpecificPlayer : NamedEntity 
    {
    }

    public abstract class GroupSize : NamedEntity 
    { 
    }

    public abstract class MatchResult : NamedEntity
    {
    }

}
