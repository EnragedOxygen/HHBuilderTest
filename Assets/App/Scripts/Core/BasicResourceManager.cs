using System;
using System.Collections.Generic;
using App.Scripts.Core;
using Zenject;

public class BasicResourceManager : IInitializable, IResourceManager
{
    // Simple way of storing resources
    // Could be replaced with a state or DB request later
    private readonly Dictionary<GameResources, int> _resources = new Dictionary<GameResources, int>();
    public event Action OnChange;
    
    public void Initialize()
    {
        // We could initialize resources with previously stored amounts here later. 
        foreach (GameResources resource in Enum.GetValues(typeof(GameResources)))
        {
            // Init it with 0 for demo 
            _resources.Add(resource,0);
        }
    }


    public void UpdateResource(GameResources gameResource, int value)
    {
        _resources[gameResource] += value;
        OnChange?.Invoke();
    }
    
    public void SetResource(GameResources gameResource, int value)
    {
        _resources[gameResource] = value;
        OnChange?.Invoke();
    }
    
    public int GetResource(GameResources gameResource)
    {
        return _resources[gameResource];
    }
}

