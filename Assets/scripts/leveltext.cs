using UnityEngine;
using TMPro;
public class leveltext : MonoBehaviour
{
    TextMeshProUGUI text;
    Levels levels;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        levels = GameObject.Find("room").GetComponent<Levels>();
        text = GetComponent<TextMeshProUGUI>();
        text.text = "Level " + PlayerPrefs.GetInt("level");
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Level " + (levels.nextLevel - 1);
    }
}
