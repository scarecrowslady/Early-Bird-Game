using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonColour : MonoBehaviour
{
    public Button clickingButton;

    public MenuController usingButtons;

    void Start()
    {
        clickingButton.GetComponent<Button>();
    }

    public void OnButtonClick()
    {
        //get the player body
        Image playerBody = clickingButton.image;
        Debug.Log("body is:" + clickingButton.image);
        usingButtons.SetChara(playerBody);
    }
}
