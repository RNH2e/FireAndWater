using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bitis : MonoBehaviour
{
    public Text finish;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player" || other.gameObject.name == "Player2")
        {
            finish.gameObject.SetActive(true);
            Time.timeScale = 0.5f;
          
        }
    }
      

}
