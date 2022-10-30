using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AudioScript : MonoBehaviour
{
    public AudioMixer masterMixer;

    public string masterVolParameter = "masterVol";
    public string bkgdMusicParameter = "bkgdmusicVol";
    public string fxVolParameter = "fxVol";

    public Slider masterVolSlider;
    public Slider bkgdMusSlider;
    public Slider fxVolSlider;

    public float multiplier = 30f;

    private void Awake()
    {
        masterVolSlider.onValueChanged.AddListener(MasterVolumeChanged);
        bkgdMusSlider.onValueChanged.AddListener(BkgdMusicChanged);
        fxVolSlider.onValueChanged.AddListener(FXVolChanged);
    }

    private void Start()
    {
        LoadVolumeStuff();
    }

    private void MasterVolumeChanged(float masterVolValue)
    {
        masterMixer.SetFloat(masterVolParameter, Mathf.Log10(masterVolValue) * multiplier);        
    }

    private void BkgdMusicChanged(float bkgdVolValue)
    {
        masterMixer.SetFloat(bkgdMusicParameter, Mathf.Log10(bkgdVolValue) * multiplier);
    }

    private void FXVolChanged(float fxVolValue)
    {
        masterMixer.SetFloat(fxVolParameter, Mathf.Log10(fxVolValue) * multiplier);
    }

    public void LoadVolumeStuff()
    {
        masterVolSlider.value = MainManager.Instance.masterVol;
        bkgdMusSlider.value = MainManager.Instance.bkgrdMusVol;
        fxVolSlider.value = MainManager.Instance.fxVol;
    }

    public void SaveVolumeStuff()
    {
        MainManager.Instance.masterVol = masterVolSlider.value;
        MainManager.Instance.bkgrdMusVol = bkgdMusSlider.value;
        MainManager.Instance.fxVol = fxVolSlider.value;

        SaveEverything();
    }

    public void SaveEverything()
    {
        MainManager.Instance.SaveInfo();
    }
}
