namespace Core
{
    public class AsteroidMediator : Mediator<Asteroid>
    {
        public AsteroidMediator(Asteroid asteroid) : base(asteroid) { }

        public int Tier => m_Entity.Tier;
    }
}