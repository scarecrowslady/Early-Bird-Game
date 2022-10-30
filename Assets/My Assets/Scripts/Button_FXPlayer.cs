using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Button_FXPlayer : MonoBehaviour
{
    //audiosources
    public AudioSource buttonClickFX;

    public void ButtonClick()
    {
        buttonClickFX.Play();
    }
}
