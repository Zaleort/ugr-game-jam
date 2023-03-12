using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetRecord : MonoBehaviour
{
    public Text record;
    // Start is called before the first frame update
    void Start()
    {
        record.text = PlayerPrefs.GetInt("record").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        record.text = PlayerPrefs.GetInt("record").ToString();
    }

}
