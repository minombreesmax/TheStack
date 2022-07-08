using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    Rigidbody blockRigidbody;
    float diration = 1;
    float i, k;

    void Start()
    {
        blockRigidbody = GetComponent<Rigidbody>();
    }

    void BlockMotion(float speed)
    {   
        if(blockRigidbody.transform.position.x >= 2)
        {
            diration = -1 * k;
        }
            
        if(blockRigidbody.transform.position.x <= -2)
        {
            diration = 1 * k;
        }

        blockRigidbody.velocity = new Vector3(diration * speed, 0, 0);
    }

    void FixedUpdate()
    {
        if(DataHolder.gameOver == false)
        {
            BlockMotion(DataHolder.downTime);
        }
       

        i = DataHolder.score;
        k = 1 + i / 40;
    }
   
}
