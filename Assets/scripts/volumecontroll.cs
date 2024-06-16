using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class volumecontroll : MonoBehaviour
{

    public AudioMixer mixer;


    public void SetLevel(float sliderValue)
    {
        if (gameObject.name == "musicslider")
        mixer.SetFloat("musicvolume", Mathf.Log10(sliderValue) * 20);
        else if (gameObject.name == "sfxslider")
        mixer.SetFloat("sfxvolume", Mathf.Log10(sliderValue) * 20);
        else
        mixer.SetFloat("allvolume", Mathf.Log10(sliderValue) * 20);
    }

}
