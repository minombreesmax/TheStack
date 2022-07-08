using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limits : MonoBehaviour
{
    RaycastHit hit;
    public GameObject Block1, Block2;

    void Rays()
    {
        var position1 = new Vector3(Block1.transform.position.x - 2.5f, Block1.transform.position.y, Block1.transform.position.z);
        var position2 = new Vector3(Block2.transform.position.x + 2.5f, Block2.transform.position.y, Block2.transform.position.z);
        Ray ray1 = new Ray(position1, Block1.transform.up);
        Ray ray2 = new Ray(position2, Block2.transform.up);
        Debug.DrawRay(position1, Block1.transform.up * 100, Color.green);
        Debug.DrawRay(position2, Block2.transform.up * 100, Color.green);

        if (Physics.Raycast(ray1, out hit) || Physics.Raycast(ray2, out hit))
        {
            if(hit.collider.gameObject.name == "Cube(Clone)" && hit.collider.gameObject.tag == "Platform")
            {
                DataHolder.gameOver = true;
            }
        }
    }

    void FixedUpdate()
    {
        gameObject.transform.localScale = new Vector3(1, DataHolder.score, 1);
        float posY = 0.5f * DataHolder.score - 5;
        gameObject.transform.position = new Vector3(0, posY, 0);
        Rays();
    }
}
