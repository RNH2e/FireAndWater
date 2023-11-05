using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deneme : MonoBehaviour
{
    Vector3 move;
    Vector3 velocity;
    [Header("scripts")]
    public deneme onemovement;
    public player2movement twomovement;

    [Header("Character Controller")]
    [SerializeField] CharacterController controller;
    public float speed;
    public float jump;
    public float sensitivity;
    public float gravity = -9.81f;
    [Header("Effects")]
    public Transform playerOneHealParticle;
    [Header("Audio")]
    AudioSource OlumSesi;

    Animator Anim;
    void Start()
    {
        Anim = GetComponent<Animator>();
        OlumSesi = GetComponent<AudioSource>();
    }

    void Update()
    {
        move = new Vector3(0, 0, Input.GetAxis("Vertical"));
        if (Input.GetKey("a") || Input.GetKey("d"))
        {
            Anim.SetTrigger("Yurume");
        }
        else
        {
            Anim.SetTrigger("Durma");
        }
                
        MovePlayer();
    }

    public void MovePlayer()
    {
        Vector3 MoveVector = move;

        if (controller.isGrounded)
        {
            velocity.y = -1f;
            if (Input.GetKeyDown(KeyCode.W))
            {
                velocity.y = jump;
                Anim.SetBool("Ziplama",true);
                Anim.SetBool("Havada", true);
                if (controller.isGrounded)
                {
                    Anim.SetBool("Inme", true);
                }
                else
                {
                    Anim.SetBool("Inme", false);
                }
            }
            else
            {
                Anim.SetBool("Ziplama", false);
                Anim.SetBool("Havada", false);
            }
        }
        else
        {
            velocity.y -= gravity * -2f * Time.deltaTime;
        }

        controller.Move(MoveVector * speed * Time.deltaTime);
        controller.Move(velocity*Time.deltaTime);

        if (Input.GetKeyDown("a"))
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (Input.GetKeyDown("d"))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "playeronehealth")
        {
            Instantiate(playerOneHealParticle, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Lava"))
        {
            Anim.SetTrigger("Olme");
            OlumSesi.enabled = true;
            FindObjectOfType<GameManager>().EndGame();
            onemovement.enabled = false;
            twomovement.enabled = false;
        }
    }


}
