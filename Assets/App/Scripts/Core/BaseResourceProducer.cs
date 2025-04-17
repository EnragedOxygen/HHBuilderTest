namespace App.Scripts.Core
{
    public abstract class BaseResourceProducer
    {
        // Simple ResourceProducing Class
        
        // Resources This Building Produces
        public GameResources GameResources { get; private set; }

        // Amount It Produces
        public int Amount { get; private set; }

        protected BaseResourceProducer(GameResources resourceType, int amount)
        {
            GameResources = resourceType;
            Amount = amount;
        }
        public abstract void Gather();

    }
}