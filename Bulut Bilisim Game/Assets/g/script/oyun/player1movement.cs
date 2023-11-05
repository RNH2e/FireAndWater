using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class player1movement : MonoBehaviour
{
    public Text finish;
    [Header("Movement")]
    public float movespeed;
    public Rigidbody rb;
    public float jump;
    public player1movement onemovement;
    public player2movement twomovement;

    ortak ortak;
    [Header("Particles")]
    public Transform playerOneHealParticle;

    Animator Anim;

    AudioSource OlumSesi;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Anim = GetComponent<Animator>();
        ortak = GetComponent<ortak>();
        OlumSesi = GetComponent<AudioSource>();
    }

    void Update()
    {
        //Hareket etme
        if (Input.GetKey("a") || Input.GetKey("d"))
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, Input.GetAxis("Horizontal") * movespeed);
            Anim.SetTrigger("Yurume");
        }
        else
        {
            Anim.SetTrigger("Durma");
        }
        //Ayaðýn yere degene kadar sadece 1 kere zýplama hakký
        if (ortak.isGrounded)
        {
            if (Input.GetKeyDown("space") || Input.GetKeyDown("w"))
            {
                rb.velocity = new Vector3(rb.velocity.x, jump, rb.velocity.z);
                //Anim.SetTrigger("Ziplama");
            }
        }
        //Sola dönünce sola, saga donunce saga bakma
        if (Input.GetKeyDown("a"))
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (Input.GetKeyDown("d"))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

    }
    //Can alýnca particle cýkma
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "playeronehealth")
        {
            Instantiate(playerOneHealParticle, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Finish")
        {
            finish.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Lava")
        {
            Anim.SetTrigger("Olme");
            OlumSesi.enabled = true;
            FindObjectOfType<GameManager>().EndGame();
            onemovement.enabled = false;
            twomovement.enabled = false;
        }
    }
}
