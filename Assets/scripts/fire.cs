using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;

public class fire : MonoBehaviour
{
    public bool autofire;
    public string weapon;
    private AudioSource audioSource;
    public GameObject camera1;

    GameObject robot;
    public float range = 100f;
    public float impactForce = 30f;
    public float fireRate = 15f;

    public GameObject firepoint;

    public int maxAmmo = 10;
    public int currentAmmo;
    public float reloadTime = 1f;
    private bool isReloading = false;
    private bool shooting = false;
    AudioClip reload;
    private float nextTimeToFire = 0f;

    public void Init1()
    {
        robot = GameObject.Find("robot");
        switch (weapon)
        {
            case "pistol":
                maxAmmo = 10;
                fireRate = 15f;
                reload = Resources.Load<AudioClip>("reload");
                break;
            case "shotgun":
                maxAmmo = 5;
                fireRate = 1f;
                reloadTime = 2f;
                reload = Resources.Load<AudioClip>("shotgunreload");
                break;
        }
        currentAmmo = maxAmmo;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!incar.active){
        
            if (Gamepad.current.rightStick.ReadValue() != Vector2.zero)
            {
                Fire();
            }
        
        
        if (uiscript.isGamePaused) return;
        if (isReloading) return;

        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        if (Gamepad.current.rightTrigger.isPressed)
        {
            Fire();
        }
        
        }
    }

    void Fire()
    {
        if (Time.time <= nextTimeToFire || isReloading || Time.timeScale == 0) return;
        nextTimeToFire = Time.time + 1f / fireRate;
        switch (weapon)
        {
            case "pistol":
                Shootpistol();
                break;
            case "shotgun":
                Shootshotgun();
                break;
        }
    }

    void Shootpistol()
    {
        if (Time.timeScale == 0) return;
        GameObject objPrefab = Resources.Load("bullet") as GameObject;
        Quaternion randomRotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(Random.Range(-5f, 15f), 0, Random.Range(-5f, 5f)));
        Instantiate(objPrefab, firepoint.transform.position, randomRotation);
        Animator anim = GameObject.Find("robot").GetComponent<Animator>();
        audioSource.Play();
        anim.StopPlayback();
        anim.Play("shoot", -1, 0f);
        currentAmmo--;
    }

    void Shootshotgun()
    {
        if (Time.timeScale == 0) return;
        GameObject objPrefab = Resources.Load("shotgunbullet") as GameObject;
        for (int i = 0; i < 5; i++)
        {
            Quaternion randomRotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(Random.Range(-15f, 15f), 0, Random.Range(-15f, 15f)));
            Instantiate(objPrefab, firepoint.transform.position, randomRotation);
        }
        Animator anim = GameObject.Find("robot").GetComponent<Animator>();
        audioSource.clip = Resources.Load("shotgun") as AudioClip;
        audioSource.Play();
        anim.StopPlayback();
        anim.Play("shotgun", -1, 0f);
        currentAmmo--;
    }

    IEnumerator Reload()
    {
        isReloading = true;
        audioSource.PlayOneShot(reload);
        yield return new WaitForSeconds(reloadTime - .25f);
        yield return new WaitForSeconds(.25f);

        currentAmmo = maxAmmo;
        isReloading = false;
    }
}
