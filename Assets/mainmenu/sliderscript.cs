using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class sliderscript : MonoBehaviour
{   
    public static float musicVolume = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Slider>().value = musicVolume;

    }

    // Update is called once per frame
    void Update()
    {
        musicVolume = gameObject.GetComponent<Slider>().value;
            
    }
}
