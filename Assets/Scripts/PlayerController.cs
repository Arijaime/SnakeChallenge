using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()

    {
        int direction;
   
        if (Input.GetKey("left"))
        {
            gameObject.transform.Translate(-5f*Time.deltaTime,0,0);
        }
        
        gameObject.transform.Translate(-3f*Time.deltaTime,0,0);

    }
}
