using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretShoot : MonoBehaviour
{
    public float frequency = 1f;
    public Transform[] BulletPositions;
    public Animator[] GunsAnimators;
    public GameObject bulletPrefab;
    public AudioClip hitsound;
    public AudioClip explosion;
    public AudioClip transformer;
    public ParticleSystem particle;
    public int damage = 20;
    void Awake() 
    {
        GetComponent<AudioSource>().PlayOneShot(transformer);
    }

    void Empezar() {
        StartCoroutine(Fire());
        StartCoroutine(Die());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //Shoot();
        }
    }

    private int i = 0;
    IEnumerator Fire()
    {
        
        GunsAnimators[i].SetTrigger("Fire");
        Instantiate(bulletPrefab, BulletPositions[i].position, BulletPositions[i].rotation);
        GetComponent<AudioSource>().PlayOneShot(hitsound);
        i++;
        if (i >= BulletPositions.Length) i = 0;
        yield return new WaitForSeconds(1/frequency);

        StartCoroutine(Fire());
    }

    //si desactivas el script las corutinas igualmente se ejecutan
    private void OnDisable() {
        StopAllCoroutines();    
    }

    IEnumerator Die() 
    {
        yield return new WaitForSeconds(5);
        GetComponent<Animator>().SetTrigger("Dead");
        GetComponent<AudioSource>().PlayOneShot(explosion);
        particle.Play();
    }

     void Die2ndTime() 
    {
        Destroy(gameObject);
    }
    
    void Shoot()
    {
        // shooting logic
        Instantiate(bulletPrefab, BulletPositions[0].position, BulletPositions[0].rotation);
        Instantiate(bulletPrefab, BulletPositions[1].position, BulletPositions[1].rotation);
        Instantiate(bulletPrefab, BulletPositions[2].position, BulletPositions[2].rotation);
        Instantiate(bulletPrefab, BulletPositions[3].position, BulletPositions[3].rotation);

    }
}
