using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using EZCameraShake;
using UnityEngine;

public class fire : MonoBehaviour
{

    // Update is called once per frame
    private AudioSource audioSource;
    public GameObject camera1;
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
    void Start()
    {
    currentAmmo = maxAmmo;
    audioSource = GetComponent<AudioSource>();  
    reload = Resources.Load<AudioClip>("reload"); 
    }

    void Update() 
    {
    if (uiscript.isGamePaused) return;

    Transform firePointTransform = GameObject.Find("firepoint").transform;
    transform.position = new Vector3(firePointTransform.position.x, firePointTransform.position.y, 0f);
    if (isReloading)
            return;
 
        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }
 
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    public void Shoot()
    {
        CameraShaker.Instance.ShakeOnce(2f, 2f, 0.2f, 0.2f);
        GameObject objPrefab = Resources.Load("bullet") as GameObject;
        Instantiate(objPrefab, transform.position, transform.rotation);
        Animator anim = GameObject.Find("robot").GetComponent<Animator>();
        audioSource.Play();
        anim.StopPlayback();
        anim.Play("shoot", -1, 0f);
        currentAmmo -= 1;

    }


    void OnEnable()
    {
        isReloading = false;
    }
 

    IEnumerator Reload ()
    {
        isReloading = true;
        audioSource.PlayOneShot(reload);
        yield return new WaitForSeconds(reloadTime - .25f);
        yield return new WaitForSeconds(.25f);
 
        currentAmmo = maxAmmo;
        isReloading = false;
    }


}

