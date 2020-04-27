using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretShoot : MonoBehaviour
{
    public Transform target, aim, head;
    public Transform[] muzzelPos;
    public bool canSee = false;
    public GameObject muzzleFlash;
    public int randomMuzzel;
    private Animator animT;
    private float nextFireTime, nextMoveTime;
    public float reloadTime = 1f, turnSpeed = 5f, firePauseTime = 0.25f;
    private AudioSource audioS;
    public AudioClip fireSound;


    public float frequency = 0.01f, range = 6;
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


    void Empezar()
    {
        StartCoroutine(Fire());
        StartCoroutine(Die());

        muzzleFlash.SetActive(false);
        animT = GetComponent<Animator>();
        audioS = GetComponent<AudioSource>();
        
    }



    void Update()
    {
        AimFire();
        Tracking();
    }


    private int i = 0;
    IEnumerator Fire()
    {
        
            Instantiate(bulletPrefab, BulletPositions[i].position, BulletPositions[i].rotation);
            GetComponent<AudioSource>().PlayOneShot(hitsound);
            i++;
            if (i >= BulletPositions.Length) i = 0;
            yield return new WaitForSeconds(1 / frequency);
            randomMuzzel = Random.Range(0, muzzelPos.Length);
            muzzleFlash.SetActive(true);

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
        //particle.Play();
    }

    void Die2ndTime() 
    {
        Destroy(gameObject);
    }

    


    void AimFire()
    {
        if (target)
        {
            if (Time.time >= nextMoveTime)
            {
                aim.LookAt(target);
                Debug.Log(target.gameObject.name);
                aim.eulerAngles = new Vector3(0, aim.eulerAngles.y, 0);
                head.rotation = Quaternion.Lerp(head.rotation, aim.rotation, Time.deltaTime * turnSpeed);
            }

            if (Time.time >= nextFireTime && canSee == true) Fire();
            else
            {
                muzzleFlash.SetActive(false);
            }
        }
        if (target == null) muzzleFlash.SetActive(false);
    }

    void Tracking()
    {
        Vector3 fwd = muzzelPos[randomMuzzel].TransformDirection(Vector3.forward);
        RaycastHit hit;
        Debug.DrawRay(muzzelPos[randomMuzzel].position, fwd * range, Color.green);

        if (Physics.Raycast(muzzelPos[randomMuzzel].position, fwd, out hit, range))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                canSee = true;
            }
        }
        else canSee = false;

    }

    void OnTriggerStay(Collider col)
    {
        if (!target)
        {
            if (col.CompareTag("Enemy"))
            {
                nextFireTime = Time.time + (reloadTime * 0.5f);
                target = col.gameObject.transform;
            }
        }
    }


    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.transform == target) target = null;
    }
    

}
