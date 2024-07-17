using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class highscore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("highscore"))
        {
            PlayerPrefs.SetInt("highscore", 0);
        }
        GetComponent<TextMeshProUGUI>().text = "Highscore: " + PlayerPrefs.GetInt("highscore").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
