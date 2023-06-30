using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FpsCounter : MonoBehaviour
{
    private float delayTime = 1f;
    private int frame;
    private float time;
    private TextMeshProUGUI fpsUI;
    private void Awake()
    {
        fpsUI = GetComponent<TextMeshProUGUI>();
        Application.targetFrameRate = 1000;


    }
    

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        frame++;
        if (time >= delayTime)
        {
            fpsUI.text = Mathf.RoundToInt(frame / time).ToString();
            frame = 0;
            time = 0;
        }
    }
}
