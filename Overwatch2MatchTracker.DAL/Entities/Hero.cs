namespace Overwatch2MatchTracker.DAL.Entities.Base
{
    public abstract class Hero : NamedEntity
    {
        public TimeSpan ElapsedTime { get; set; }
    }

}
