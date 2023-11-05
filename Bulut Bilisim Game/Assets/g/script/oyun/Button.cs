//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Button : MonoBehaviour
//{

//    Transform scale;
//    Animator DownAnim;

//    private void Awake()
//    {
//        scale = GetComponent<Transform>();
//        DownAnim = GameObject.Find("Asansor").GetComponent<Animator>();
//    }

//    private void Update()
//    {
//    }
//    private void OnTriggerEnter(Collider other)
//    {
//        if (other.gameObject.tag=="Player")
//        {
//            scale.localScale = new Vector3(1, 0.1f, 1);
//            DownAnim.SetTrigger("TusaBasma");
//        }
//    }

//    private void OnTriggerExit(Collider other)
//    {
//        if (other.gameObject.tag=="Player")
//        {
//            scale.localScale = new Vector3(1, 0.3f, 1);
//            DownAnim.SetTrigger("TustanKalkma");
//        }
        
//    }
//}
