using UnityEngine;

public class ammocrate : MonoBehaviour
{
    GameObject robot;
    GameObject legs;
    fire fire;
    Health hp;
    legscript move;
    GameObject powervignette;

    powerup powerup;
    
    void Start()
    {
        powervignette = GameObject.Find("powerup");
        powerup = powervignette.GetComponent<powerup>();
        robot = GameObject.Find("firepoint");
        legs = GameObject.Find("legs");
        fire = robot.GetComponent<fire>();
        hp = legs.GetComponent<Health>();
        move = legs.GetComponent<legscript>();
    }

    // Update is called once per frame
    void OnTriggerEnter2D()
    {
        switch(gameObject.name)
        {
            case "crate2(Clone)":
                fire.maxAmmo += 5;
                if(fire.reloadTime - 0.5f >= 0) fire.reloadTime -= 0.2f; fire.fireRate += 1f;
                break;
            case "crate1(Clone)":
                hp.currentHealth += 2;
                move.speed += 0.5f;
                break;
            case "crate3(Clone)":
            spawnbomb();
            spawnbomb();
            spawnbomb();
            break;
        }

        powerup.powervignette();
        Destroy(gameObject);
    }
    void spawnbomb()
    {
        GameObject bombObject = (GameObject)Instantiate(Resources.Load("bomb1"), legs.transform.position, Quaternion.identity);
            bombObject.transform.localScale = new Vector3(4, 4, 0);
            bombObject.GetComponent<Bomb1>().bombPoint = GameObject.Find("bombpoint" + Random.Range(1, 7).ToString());
            bombObject.GetComponent<Bomb1>().speed = Random.Range(15f, 18f);
            bombObject.SetActive(true);
    }
}
