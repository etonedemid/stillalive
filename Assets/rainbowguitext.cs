using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class rainbowguitext : MonoBehaviour
{
    void Update()
    {
        GetComponent<TextMeshProUGUI>().color = new Color(Mathf.Sin(Time.time) * 0.5f + 0.5f, Mathf.Cos(Time.time) * 0.5f + 0.5f, Mathf.Sin(Time.time * 2) * 0.5f + 0.5f);
    }
}
