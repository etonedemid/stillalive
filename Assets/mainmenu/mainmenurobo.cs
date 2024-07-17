using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainmenurobo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);

        float angle = Mathf.Atan2(mousePos.y - objectPos.y, mousePos.x - objectPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle - 90);
    }
}
