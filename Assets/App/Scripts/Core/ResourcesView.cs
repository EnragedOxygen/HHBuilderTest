using System;
using System.Text;
using App.Scripts.Core;
using TMPro;
using UnityEngine;
using Zenject;

public class ResourcesView : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;
    
    private IResourceManager _resourceManager;
    
    [Inject]
    private void Construct(IResourceManager resourceManager)
    {
        _resourceManager = resourceManager;
        _resourceManager.OnChange += RefreshText;
    }

    private void Start()
    {
        RefreshText();
    }

    private void OnDestroy()
    {
        _resourceManager.OnChange -= RefreshText;
    }

    private void RefreshText()
    {
        // This solution is strictly for demo purposes. 
        // Otherwise i would've implemented ToString method into IResourceManager
        StringBuilder builder = new StringBuilder();
        foreach (GameResources resource in Enum.GetValues(typeof(GameResources)))
        {
            builder.Append($"{resource.ToString()}: {_resourceManager.GetResource(resource)}\n");
        }
        text.SetText(builder.ToString());
    }
}
