using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingUI : MonoBehaviour
{
    [SerializeField] protected Slider FOVSlider;
    [SerializeField] protected Slider volumeSlider;
    [SerializeField] protected Transform audioSourceContent;
    [SerializeField] protected CameraControl cameraControl;

    private float currentFOVValue = 0.5f;

    private void Start()
    {
        AddSliderListener();
        LoadSettingValue();
    }

    protected void AddSliderListener()
    {
        volumeSlider.onValueChanged.AddListener(delegate { ChangeVolume(volumeSlider.value); });
        FOVSlider.onValueChanged.AddListener(delegate { 
            ChangeFOV(FOVSlider.value - currentFOVValue);
            currentFOVValue = FOVSlider.value;
        });
    }
    
    protected void ChangeVolume(float volume)
    {
        AudioSource[] audioSources = audioSourceContent.GetComponentsInChildren<AudioSource>();

        foreach(AudioSource audioSource in audioSources)
        {
            audioSource.volume = volume;
        }
    }
    protected void ChangeFOV(float fov)
    {
        cameraControl.CameraZoom(fov);
    }
    protected void LoadSettingValue()
    {
        volumeSlider.value = audioSourceContent.GetComponentInChildren<AudioSource>().volume;
        FOVSlider.value = 0.5f;
    }
}
