using System;

namespace App.Scripts.Core
{
    // Basic CRUD interface for resource management
    public interface IResourceManager
    {
        event Action OnChange;
        void UpdateResource(GameResources gameResource, int value);

        void SetResource(GameResources gameResource, int value);

        int GetResource(GameResources gameResource);
    }

    public enum GameResources
    {
        Gold,
        Wood,
        Rock,
        Iron,
        Oil
    }
}