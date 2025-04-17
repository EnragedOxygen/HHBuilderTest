namespace App.Scripts.Core
{
    public class TimedBaseResourceProducer : BaseResourceProducer
    {
        public TimedBaseResourceProducer(GameResources resourceType, int amount) : base(resourceType, amount)
        {
        }

        public override void Gather()
        {
            
        }
    }
}