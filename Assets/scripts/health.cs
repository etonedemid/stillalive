using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    // Maximum health points of the player
    public int maxHealth = 10;
    // Current health points of the player
    public int currentHealth = 10;
    public GameObject deathMenu;
    bool died;
    public GameObject vignette;
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
            if (died) return;
            StartCoroutine(Die());
            died = true;
        }
    }
    IEnumerator Die()
    {
    foreach (Renderer r in GetComponentsInChildren<Renderer>())
    {
        r.enabled = false;
    }
    Object oilObject = Resources.Load("explosionCircle");
    GameObject blood1 = Instantiate(oilObject, transform.position, Quaternion.identity) as GameObject;
    AudioSource.PlayClipAtPoint(Resources.Load<AudioClip>("death"), transform.position);
    yield return new WaitForSeconds(0.1f);
    Time.timeScale = 0;
    deathMenu.SetActive(true);
    Destroy(gameObject);
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