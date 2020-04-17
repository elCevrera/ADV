using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{

    public Transform target, aim, head;
    public float reloadTime = 1f, turnSpeed = 5f, firePauseTime = 0.25f, range = 3;
    public Transform[] muzzelPos;
    public bool canSee = false;
    public GameObject muzzleFlash;
    public AudioClip fireSound;

    private float nextFireTime, nextMoveTime;
    public int randomMuzzel;
    private Animator animT;
    private AudioSource audioS; 
    // Start is called before the first frame update
    void Start()
    {
        muzzleFlash.SetActive(false);
        animT = GetComponent<Animator>();
        audioS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        AimFire();
        Tracking();
    }

    void AimFire()
    {
        if (target)
        {
            if (Time.time >= nextMoveTime)
            {
                aim.LookAt(target);
                aim.eulerAngles = new Vector3(0, aim.eulerAngles.y, 0);
                head.rotation = Quaternion.Lerp(head.rotation, aim.rotation, Time.deltaTime * turnSpeed);
            }

            if (Time.time >= nextFireTime && canSee == true) Fire();
            else
            {
                muzzleFlash.SetActive(false);
                animT.SetBool("isFiring", true);
            }
        }
        if (target == null) muzzleFlash.SetActive(false);
    }


    void Fire()
    {
        randomMuzzel = Random.Range(0, muzzelPos.Length);
        nextFireTime = Time.time + reloadTime;
        nextMoveTime = Time.time + firePauseTime;
        audioS.PlayOneShot(fireSound);
        muzzleFlash.SetActive(true);
        animT.SetBool("isFiring", true);
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
