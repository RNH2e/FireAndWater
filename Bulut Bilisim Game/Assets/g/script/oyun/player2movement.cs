using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2movement : MonoBehaviour
{

    [Header("Movement")]
    public float movespeed;
    public Rigidbody rb2;
    public float jump;
    public player1movement onemovement;
    public player2movement twomovement;

    ortak ortak2;

    Animator anim;
    AudioSource Olumsesi;
    [Header("Particles")]
    public Transform playerTwoHealParticle;
    void Start()
    {
        rb2 = GetComponent<Rigidbody>();
        ortak2 = GetComponent<ortak>();
        anim = GetComponent<Animator>();
        Olumsesi = GetComponent<AudioSource>();
    }

    void Update()
    {
        //Hareket etme
        if (Input.GetKey("left") || Input.GetKey("right"))
        {
            rb2.velocity = new Vector3(rb2.velocity.x, rb2.velocity.y, Input.GetAxis("Horizontal") * movespeed);
            anim.SetTrigger("Yurume");
        }
        else
        {
            anim.SetTrigger("Durma");
        }
        //Ayaðýn yere degene kadar sadece 1 kere zýplama hakký
        if (ortak2.isGrounded)
        {
            if (Input.GetKeyDown("up"))
            {
                rb2.velocity = new Vector3(rb2.velocity.x, jump, rb2.velocity.z);
                //anim.SetTrigger("Ziplama");
            }
        }
        //Sola dönünce sola, saga donunce saga bakma
        if (Input.GetKeyDown("left"))
        {
            transform.rotation = Quaternion.Euler(0,180, 0);
        }
        if (Input.GetKeyDown("right"))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

    }
    public void OnTriggerEnter(Collider other)
    {
        //Can alýnca particle cýkma
        if (other.gameObject.tag == "playertwohealth")
        {
            Instantiate(playerTwoHealParticle, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
        }
      
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Water")
        {
            anim.SetTrigger("Olme");
            Olumsesi.enabled = true;
            FindObjectOfType<GameManager>().EndGame();
            onemovement.enabled = false;
            twomovement.enabled = false;
        }
    }
}

