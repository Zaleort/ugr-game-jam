using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitRecord : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        if (!PlayerPrefs.HasKey("record"))
        {
            PlayerPrefs.SetInt("record", 0);
        }
        else
        {
            PlayerPrefs.SetInt("record", PlayerPrefs.GetInt("record"));
        }
    }

    void Start()
    {
        if (!PlayerPrefs.HasKey("record"))
        {
            PlayerPrefs.SetInt("record", 0);
        }
        else
        {
            PlayerPrefs.SetInt("record", PlayerPrefs.GetInt("record"));
        }
    }


}
