using Zenject;

namespace App.Scripts.Core
{
    public abstract class BaseResourceProducer : IResourceProducer
    {
        // Simple ResourceProducing Class
        [Inject]
        protected IResourceManager _resourceManager;
        
        // Resources This Building Produces
        public GameResources ProducedResource { get;}

        // Amount It Produces
        public int ProducedAmount { get;}

        protected BaseResourceProducer(GameResources resourceType, int producedAmount)
        {
            ProducedResource = resourceType;
            ProducedAmount = producedAmount;
        }
        public abstract void Produce();
    }
}