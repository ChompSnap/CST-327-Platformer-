using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text secondsRemain;
    private float acumulatedTime = 0f;
    int timeTotal = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int timeRemaining = 360;
        
        acumulatedTime += Time.deltaTime;

        if (acumulatedTime > 1f)
        {
            acumulatedTime = 0f;
            timeTotal += 1;
            timeRemaining -= timeTotal;

            secondsRemain.text = timeRemaining.ToString();
            

            Debug.Log($"Time is {timeTotal}");
        }
    }
}
