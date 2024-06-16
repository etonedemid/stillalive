using UnityEngine;
using UnityEngine.InputSystem;

public class cursor : MonoBehaviour
{
    void Update()
    {
        if (uiscript.isGamePaused) return;
        if (Time.timeScale == 0) return;
        
        transform.position = Mouse.current.position.ReadValue();
    }
}
