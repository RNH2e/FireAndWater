using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    Animator KapiAcilmaAnim;
    void Start()
    {
        KapiAcilmaAnim = GameObject.Find("CikisKapisi").GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name=="Tetikleme")
        {
            KapiAcilmaAnim.SetTrigger("KapiAcilma");
        }
    }
}
