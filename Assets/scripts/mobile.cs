using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mobile : MonoBehaviour
{
    public GameObject carin;
    public GameObject outcar;

    void Start()
    {
        carin = GameObject.Find("incar");
        outcar = GameObject.Find("outcar");
    }
    void Update()
{
    if (Time.timeScale == 0)
    {
        Debug.Log("Game is paused");
        return;
    }

    Debug.Log("Game is running");

        // Check incar.active and handle accordingly
        if (incar.active)
        {
            Debug.Log("In car");
            carin.SetActive(true);
            outcar.SetActive(false);
        }
        else
        {
            Debug.Log("Not in car");
            carin.SetActive(false);
            outcar.SetActive(true);
        }
    
}


}
