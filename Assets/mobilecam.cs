using System.Drawing;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class mobilecam : MonoBehaviour
{
    float Size;
    void Start()
    {
        if (Application.isMobilePlatform) GetComponent<Cinemachine.CinemachineVirtualCamera>().m_Lens.OrthographicSize = 10;
        else GetComponent<Cinemachine.CinemachineVirtualCamera>().m_Lens.OrthographicSize = 12;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
