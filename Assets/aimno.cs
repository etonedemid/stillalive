using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aimno : MonoBehaviour
{

    void Update()
    {
        if (incar.active) GetComponent<Renderer>().enabled = false;
        else GetComponent<Renderer>().enabled = true;
    }
}
