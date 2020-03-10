﻿using UnityEngine;

public class GunScript : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    public float impactForce = 30f;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;

    private float nextTimeToFire = 0f;

    public AudioSource shotSound;
    public AudioSource hitSound;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire && !PauseMenu.GameIsPaused){
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    void Shoot(){
        muzzleFlash.Play();
        shotSound.Play();

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position,fpsCam.transform.forward, out hit, range)){
            Debug.Log(hit.transform);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null){
                target.TakeDamage(damage);
                hitSound.Play();
                ScoringSystem.theScore += 100;
            }

            if (hit.rigidbody != null){
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }
    }
}


/*
References: 
https://www.youtube.com/watch?v=D0lx90n0s-4
*/
