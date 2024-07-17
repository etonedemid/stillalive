using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Scoretext : MonoBehaviour
{
    static public int score = 0;

    void Update()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = "Score: " + score.ToString();
    }
}
