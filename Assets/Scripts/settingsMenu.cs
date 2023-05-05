using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class settingsMenu : MonoBehaviour
{
    //odwołanie do kompenentu unity mixer
    public AudioMixer mixer;
    public MySettings set;
    public TMP_Dropdown resolutionDropdown;

    Resolution[] resolutions;
    int currRess = 0;
    void Start()
    {
        // Debug.Log(MySettings.settingsIndex);
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        for (var i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);
            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currRess = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currRess;
        resolutionDropdown.RefreshShownValue();
    }
    public void setVolume(float volume)
    {
        //ustawienie dźwięku na podany przez użytkownika
        mixer.SetFloat("Volume", volume);
    }
    public void setGraphics(int QualityIndex)
    {
        QualitySettings.SetQualityLevel(QualityIndex);
        MySettings.settingsIndex = QualityIndex;
        // Debug.Log(MySettings.settingsIndex);
    }
    public void setFullscreen(bool full)
    {
        Screen.fullScreen = full;
    }
    public void setRes(int resIndex)
    {
        Resolution resolution = resolutions[resIndex];
        Screen.SetResolution(resolution.width ,resolution.height, Screen.fullScreen);
    }
}
