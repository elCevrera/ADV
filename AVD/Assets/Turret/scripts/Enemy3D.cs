using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3D : MonoBehaviour
{
    public int health = 100;
    public int damage = 10;
    
     public AudioClip hitsound;
    public void TakeDamage (int damage)
    {
        health -= damage;
        if(health <=0) {
            Die();
        }
    }
    void Die() 
    {
        GetComponent<AudioSource>().PlayOneShot(hitsound);
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<Animator>().SetTrigger("Death");
    }
}
