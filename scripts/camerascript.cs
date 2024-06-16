using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerascript : MonoBehaviour
{
    public Transform legs;
    public float see;
    void Update()
    {
    Vector3 mousePosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
    Vector3 targetPosition = legs.position + mousePosition * 4;
    transform.position = targetPosition + new Vector3(-2f, -2f, -10);
    }
}
