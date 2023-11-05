using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ortak : MonoBehaviour
{
    [Header("Particle")]
    public Transform effect;
    [Header("Zemin")]
    public bool isGrounded;
    [Header("Movement")]
    Rigidbody rbcommon;

    Animator anim;

    AudioSource deathSound;
    [Header("Scripts")]
    public player1movement onemovement;
    public player2movement twomovement;

    void Start()
    {
        anim = GetComponent<Animator>();
        deathSound = GetComponent<AudioSource>();
        rbcommon = GetComponent<Rigidbody>();
    }


    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        //Can alma particle
        if (other.gameObject.tag == "health")
        {
            Instantiate(effect, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
        }
        //Engele carpýp ölme
        if (other.gameObject.tag == "spikes")
        {
            anim.SetTrigger("Olme");
            FindObjectOfType<GameManager>().EndGame();
            deathSound.enabled = true;
            onemovement.enabled = false;
            twomovement.enabled = false;
        }

     
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            isGrounded = true;
        }

        
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            isGrounded = true;
        }
        if (collision.gameObject.tag == "itilecekNesne")
        {
            anim.SetTrigger("itme");
            rbcommon.AddForce(new Vector3(0, transform.position.y, 3));
        }
    }

        private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            isGrounded = false;
        }
        if (collision.gameObject.tag == "itilecekNesne")
        {
            anim.ResetTrigger("itme");
        }
    }
}