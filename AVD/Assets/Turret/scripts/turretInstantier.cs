using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretInstantier : MonoBehaviour
{
    public GameObject torretaPrefab;
    public float speed = 5f;
    public int damage = 10;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.right * speed;
        rb.AddForce(transform.forward * speed, ForceMode.Impulse);
        Destroy(gameObject, 3f);
    }

    void OnCollisionEnter(Collision collision) 
    {
        if (collision.gameObject.CompareTag("ground"))
        {

            GameObject[] torretes = GameObject.FindGameObjectsWithTag("torreta");
            foreach (GameObject torreta in torretes)
            {
                //torreta.GetComponent<Animator>().SetTrigger("Dead");
                GameObject.Destroy(torreta);
            }
            Instantiate(torretaPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            Destroy(gameObject);
        }
        else { Destroy(gameObject); }
    }
}
