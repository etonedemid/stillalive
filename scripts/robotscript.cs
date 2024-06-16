using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Pathfinding;
using UnityEngine;
using UnityEngine.UIElements;

public class robotscriptsandbox : MonoBehaviour
{
    private int bombCount = 0;
    private int killCounter;
    private bool isInstantiatingBombs = false;


    void Update(){
        if (uiscript.isGamePaused) return;

        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector3 direction = mousePos - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        if (Input.GetKeyDown(KeyCode.E)) 
        {
            GameObject enemyObject = (GameObject)Instantiate(Resources.Load("enemy"), mousePos, Quaternion.identity);
            enemyObject.GetComponent<AIDestinationSetter>().target = gameObject.transform;
            enemyObject.transform.position = new Vector3(mousePos.x, mousePos.y, 0f);
            enemyObject.transform.localScale = new Vector3(6, 6, 0);
            enemyObject.SetActive(true);
        }

        
        if (Input.GetKeyDown(KeyCode.Q)) 
        {
            string bombName = "bomb1"; // Use different bomb prefabs

            GameObject bombObject = (GameObject)Instantiate(Resources.Load(bombName), transform.position, Quaternion.identity);

            bombObject.transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
            bombObject.transform.localScale = new Vector3(4, 4, 0);
            bombObject.GetComponent<Bomb>().bombPoint = GameObject.Find("bombpoint" + Random.Range(1, 7).ToString());
            bombObject.GetComponent<Bomb>().speed = Random.Range(9f, 15f);
            bombObject.SetActive(true);
        }
        
    }


}