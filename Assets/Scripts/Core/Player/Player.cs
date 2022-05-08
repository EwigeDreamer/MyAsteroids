namespace Core
{
    public class Player : BaseEntity
    {
        private RegularMovement m_Movement = new RegularMovement();
        public override BaseMovement Movement => m_Movement;
        public RegularMovement RegularMovement => m_Movement;
    }
}
