using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    // Maximum health points of the player
    public int maxHealth = 3;
    // Current health points of the player
    public int currentHealth;
    public GameObject deathMenu;
    void Start()
    {
        currentHealth = maxHealth;
        deathMenu.SetActive(false);
        Time.timeScale = 1;
    }
    void Update()
    {
        // If the player has no health left, then die
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
    Object oilObject = Resources.Load("oil");
    Time.timeScale = 0;
    deathMenu.SetActive(true);
    gameObject.SetActive(false);
    GameObject blood1 = Instantiate(oilObject, transform.position, Quaternion.identity) as GameObject;
    GameObject blood2 = Instantiate(oilObject, transform.position + new Vector3(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f), 0), Quaternion.Euler(0, 0, Random.Range(-30f, 30f))) as GameObject;
    AudioSource.PlayClipAtPoint(Resources.Load<AudioClip>("death"), transform.position);
    }

    public void restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void fuckoff()
    {
        SceneManager.LoadScene("main menu");
    }
 
}