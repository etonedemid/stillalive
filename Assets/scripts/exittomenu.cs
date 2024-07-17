using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            if (SceneManager.GetActiveScene().name == "dungeon"){
            PlayerPrefs.SetInt("completed", 1);
            PlayerPrefs.Save();}
            SceneManager.LoadScene("main menu");
        }
    }
}
