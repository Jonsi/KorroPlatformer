using Common.MVP;

namespace KorroPlatformer.Hazards.Traps
{
    public class TrapModel : IModel
    {
        public int Damage { get; }

        public TrapModel(int damage)
        {
            Damage = damage;
        }
    }
}

