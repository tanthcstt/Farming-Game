using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleUIButton : MonoBehaviour
{
    public GameObject toggleUI;

    private void Start()
    {
        toggleUI.SetActive(false);
    }
    public void TurnOn()
    {
        toggleUI.SetActive(true);   
    }

    public void TurnOff()
    {
        toggleUI.SetActive(false); 
    }

   
}
