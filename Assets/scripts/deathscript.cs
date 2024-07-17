using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;
public class DeathScript : MonoBehaviour
{
    public GameObject bullet;
    public GameObject explosion;

    private robotscriptsurvival robotscript;
    public int hp = 1;
    // Start is called before the first frame update
    void Start()
    {
        robotscript = GameObject.Find("robot").GetComponent<robotscriptsurvival>();
    }

    public void Die()
    {
        hp -= 1;
        if (hp <= 0){
        robotscript.Killed();
        Object bloodObject = Resources.Load("blood");
        GameObject blood = Instantiate(bloodObject, transform.position, Quaternion.identity) as GameObject;
        Scoretext.score += 100;
        if (Scoretext.score > PlayerPrefs.GetInt("highscore"))
        if (SceneManager.GetActiveScene().name != "dungeon"){
        PlayerPrefs.SetInt("highscore", Scoretext.score);
        PlayerPrefs.Save();}
        Destroy(gameObject);
        }
    }
}
