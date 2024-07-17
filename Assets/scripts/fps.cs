using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class fps : MonoBehaviour
{
    TMP_Text tMP_Text;
    // Start is called before the first frame update
    void Start()
    {
        tMP_Text = GetComponent<TMP_Text>();
    }
    void Update()
    {
        int fps = (int)(1.0f / Time.deltaTime);
        tMP_Text.text = "FPS: " + fps;
    }
}
