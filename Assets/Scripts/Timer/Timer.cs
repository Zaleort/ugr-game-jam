using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    float timer = 0.0f;
    public Text record;
    
    void Update()
    {
        timer += Time.deltaTime;

        int seconds = (int)timer;
        record.text = seconds.ToString();
        if (PlayerPrefs.HasKey("record"))
        {
            if (timer > PlayerPrefs.GetInt("record"))
            {
                PlayerPrefs.SetInt("record", seconds);
            }
        }
        else
        {
            PlayerPrefs.SetInt("record", 0);
        }
    }
}
