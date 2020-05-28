using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public void OnValueChanged(string option)
    {
        if(option == "VolumeControll")
        {
            //GetComponent<AudioSource>().volume = GameObject.Find("VolumeControll").GetComponent<Slider>().value;
        }
    }
}
