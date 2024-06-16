using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class camerascript : MonoBehaviour
{
    public Transform legs;
    Vector3 Pos;
    void Update()
    {
    if (Time.timeScale == 0) return;
    Pos = legs.position;
    Pos.z = -1f;
    transform.position = Pos;
    }
}
