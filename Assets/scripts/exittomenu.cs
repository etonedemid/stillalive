using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class exittomenu : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.SetInt("completed", 1);
        PlayerPrefs.Save();
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("main menu");
        }
    }
    public void SavePrefs()
{
    PlayerPrefs.SetInt("Volume", 50);
    PlayerPrefs.Save();
}
}
