using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mobile : MonoBehaviour
{
    GameObject mobileinput;
    void Start()
    {
        mobileinput = GameObject.Find("phoneinput");
        if (!Application.isMobilePlatform)
        {
            mobileinput.SetActive(false);
        }
    }
    void Update()
    {
        if (Time.timeScale == 0 || uiscript.isGamePaused) mobileinput.SetActive(false);
        else if (Application.isMobilePlatform) mobileinput.SetActive(true);
    }
}
