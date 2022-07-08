using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    Rigidbody cubeRigidBody;
    Color cubeColor;
    public GameObject audioSource;
    public Material Material;
    
    void Start()
    {
        cubeRigidBody = GetComponent<Rigidbody>();
        audioSource.SetActive(false);
        cubeColor = new Color(PlayerPrefs.GetFloat("colourR"), PlayerPrefs.GetFloat("colourG"), PlayerPrefs.GetFloat("colourB"), PlayerPrefs.GetFloat("colourA"));
        Material.SetColor("_Color", cubeColor);
    }


    void FixedUpdate()
    {
        if(gameObject.tag != "Platform")
        {
            cubeRigidBody.velocity = new Vector3(0, -10, 0);
        }
        
        if(transform.position.x < -9 || transform.position.x > 9)
        {
            Destroy(gameObject);
            DataHolder.gameOver = true;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            gameObject.tag = "Platform";
            audioSource.SetActive(PlayerPrefs.GetString("Sound") == "On"? true : false);
        }
    }
}
