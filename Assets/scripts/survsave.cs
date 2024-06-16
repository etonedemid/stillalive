using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class survsave : MonoBehaviour
{
    public GameObject button;
    public GameObject button1;
    // Start is called before the first frame update
    void Start()
    {
       if (PlayerPrefs.GetInt("completed") != 1) {
       button.SetActive(false);
       button1.SetActive(false);
       }
    }
}
