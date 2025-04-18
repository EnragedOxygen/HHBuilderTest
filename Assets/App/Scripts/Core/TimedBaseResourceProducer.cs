namespace App.Scripts.Core
{
    public class TimedBaseResourceProducer : BaseResourceProducer
    {
        public TimedBaseResourceProducer(GameResources resourceType, int producedAmount)
            : base(resourceType, producedAmount)
        {
        }

        public override void Produce()
        {
            _resourceManager.UpdateResource(ProducedResource,ProducedAmount);
        }
    }
}