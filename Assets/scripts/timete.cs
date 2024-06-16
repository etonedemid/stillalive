using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class timete : MonoBehaviour
{
    TextMeshProUGUI text;
    fire fire;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    private float timeSinceLevelLoad;

    private void LateUpdate()
    {
        timeSinceLevelLoad = Time.unscaledDeltaTime + timeSinceLevelLoad;
        text.text = timeSinceLevelLoad.ToString();
    }
}
