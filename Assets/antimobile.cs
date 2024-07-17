using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class antimobile : MonoBehaviour
{
    void Start()
    {
        if (Application.isMobilePlatform)
        {
            gameObject.SetActive(false);
        }
    }
}
