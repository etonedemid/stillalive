using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mobilesize : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (Application.isMobilePlatform)
        {
            transform.localScale *= 1.4f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
