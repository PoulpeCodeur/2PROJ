using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private TMP_Dropdown resolutionDropdown;
    [SerializeField] private Toggle fullscreenToggle;
    [SerializeField] private AudioMixer audioMixer;

    private Resolution[] resolutions;
    private int currentResolution;

    private void Awake()
    {
        resolutionDropdown.ClearOptions();
        resolutions = Screen.resolutions;

        List<string> resolutionLabels = new List<string>();
        for (int i = 0; i < resolutions.Length; i++)
        {
            resolutionLabels.Add(resolutions[i].ToString());
            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolution = i;
            }
        }

        resolutionDropdown.AddOptions(resolutionLabels);

        resolutionDropdown.value = currentResolution;
        fullscreenToggle.isOn = Screen.fullScreen;
        audioMixer.GetFloat("Master", out float volume);
        volumeSlider.value = Mathf.InverseLerp(-80, 15, volume);

        volumeSlider.onValueChanged.AddListener(UpdateVolume);
        resolutionDropdown.onValueChanged.AddListener(UpdateResolution);
        fullscreenToggle.onValueChanged.AddListener(ToggleFullscreen);
    }

    private void UpdateVolume(float value)
    {
        print("Volume: " + value);
        audioMixer.SetFloat("Master", Mathf.Lerp(-80, 15, value));
    }

    private void UpdateResolution(int value)
    {
        print("Resolution: " + value);
        currentResolution = value;
        Screen.SetResolution(resolutions[currentResolution].width, resolutions[currentResolution].height, Screen.fullScreen);
    }

    private void ToggleFullscreen(bool value)
    {
        print("Fullscreen: " + value);
        Screen.fullScreen = value;
    }
}
