using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet3D : MonoBehaviour
{
    public LayerMask layermask;
    public float speed = 5f;
    public int damage = 10;
    public Rigidbody rb;
    public GameObject impactEffect;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.right * speed;
        rb.AddForce(transform.forward * speed);
        Destroy(gameObject, 3f);
    }
    void OnTriggerEnter(Collider collision)
    {
        Enemy3D enemy = collision.GetComponent<Enemy3D>(); //dañar zombies
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
            Destroy(gameObject);
            
    }

}
