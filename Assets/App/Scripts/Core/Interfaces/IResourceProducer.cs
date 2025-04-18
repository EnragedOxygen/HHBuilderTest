namespace App.Scripts.Core
{
    public interface IResourceProducer
    {
        // Resources This Building Produces
        public GameResources ProducedResource { get; }

        // Amount It Produces
        public int ProducedAmount { get; }
        
        void Produce();
    }
}