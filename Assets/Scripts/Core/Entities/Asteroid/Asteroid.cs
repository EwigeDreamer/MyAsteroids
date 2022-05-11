
namespace Core
{
    public class Asteroid : BaseEntity
    {
        private RegularMovement m_Movement = new RegularMovement();
        public override BaseMovement Movement => m_Movement;
        public RegularMovement RegularMovement => m_Movement;
        public override EntityKind Kind => EntityKind.Asteroid;

        public int Tier { get; set; } = 1;

        public override void Dispose()
        {
            base.Dispose();
            m_Movement = null;
        }
    }
}
