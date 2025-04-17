using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameState : IInitializable
{
    // Simple way of storing resources
    // Could be later expanded into a separate ResourceStoringClass.
    private readonly Dictionary<GameResources, int> _resources = new Dictionary<GameResources, int>();
    
    public async void Initialize()
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
    }
    
    public void SetResource(GameResources gameResource, int value)
    {
        _resources[gameResource] = value;
    }
    
    public int GetResource(GameResources gameResource)
    {
        return _resources[gameResource];
    }
}

 
public enum GameResources
{
    Gold,
    Wood,
    Rock,
    Iron,
    Oil

}
