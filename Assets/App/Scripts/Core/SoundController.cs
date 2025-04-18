using System;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    [FormerlySerializedAs("_audioMixerGroup")] [SerializeField]
    private  AudioMixer audioMixerGroup;
    
    [SerializeField]
    private Slider slider;
    
    
    [SerializeField]
    private TextMeshProUGUI text;

    // This class should have a layer of abstraction.
    private void Start()
    {
        // It could easily be done with some kind of serializable config or a ScriptableObject. 
        // But to save a singe value PlayerPrefs will do.
        SetVolume(PlayerPrefs.GetFloat("Volume", 0f));
        slider.value = PlayerPrefs.GetFloat("Volume", 0f);
    }

    private void OnEnable()
    {
        slider.onValueChanged.AddListener(SetVolume); ;
    }

    private void OnDisable()
    {
        slider.onValueChanged.RemoveListener(SetVolume); ;
    }

    public void SetVolume(float volume)
    {
        volume = Mathf.Clamp(volume, -80f, 20f);
        text.SetText($"{volume} db");
        
        audioMixerGroup.SetFloat("MasterVolume", volume);
        PlayerPrefs.SetFloat("Volume", volume);
    }
}
