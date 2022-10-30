using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AudioScript_basicManip : MonoBehaviour
{
    public AudioMixer masterMixer;

    public float masterVolNum;
    public float bkgdMusVolNum;
    public float fxVolNum;

    public float multiplier = 30f;

    private void Start()
    {

    }

    public void Update()
    {
        masterVolNum = MainManager.Instance.masterVol;
        bkgdMusVolNum = MainManager.Instance.bkgrdMusVol;
        fxVolNum = MainManager.Instance.fxVol;
    }
}
