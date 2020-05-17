using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : MonoBehaviour
{

    public AudioClip openChestSound;
    public GameObject TresureChest;
    private Animator anim;
    private bool hasPlayer;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(hasPlayer && Input.GetKeyDown("e")) 
        {
            anim.Play("openChest");
        }
    }
    private void onTriggerEnter(Collider col)
    {
        Debug.Log(col.CompareTag("Player"));
        if (col.CompareTag("Player"))
        {
            hasPlayer = true;
        }
    }

    private void onTriggerExit(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            hasPlayer = false;
        }
    }
}
