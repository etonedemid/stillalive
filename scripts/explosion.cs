using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;
public class explosion : MonoBehaviour
{
    void Start()
    {
        CameraShaker.Instance.ShakeOnce(10f, 4f, 0f, 1.3f);
        Destroy(gameObject, 1.3f);
    }
}