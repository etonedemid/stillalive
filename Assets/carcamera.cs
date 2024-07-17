using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carcamera : MonoBehaviour
{
    public GameObject vcamera;
    void Start()
    {
        vcamera = GameObject.Find("camera");
    }
    void Update()
    {
        if (incar.active) vcamera.SetActive(false);
        else vcamera.SetActive(true);
    }
}
