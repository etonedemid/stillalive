
using UnityEngine;
using UnityEngine.SceneManagement;
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
                hp.currentHealth += 4;
                move.speed += 0.25f;
                break;
        }
        Scoretext.score += 1000;
        if (SceneManager.GetActiveScene().name != "dungeon") Instantiate(Resources.Load("plus1000"), transform.position, Quaternion.identity);
        powerup.powervignette();
        Destroy(gameObject);
    }
}
