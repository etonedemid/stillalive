using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class rainbowtrect : MonoBehaviour
{
    float tim;
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "dungeon") Destroy(gameObject);
        Destroy(gameObject, 0.6f);
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMeshPro>().color = new Color(Mathf.Sin(Time.time) * 0.5f + 0.5f, Mathf.Cos(Time.time) * 0.5f + 0.5f, Mathf.Sin(Time.time * 2) * 0.5f + 0.5f);
        transform.position += Vector3.up * Time.deltaTime;
    }
}
