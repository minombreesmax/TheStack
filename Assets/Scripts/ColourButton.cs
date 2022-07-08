using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourButton : MonoBehaviour
{
    public GameObject Check;
    public float[] ColorRGB = new float[4];

    public void Checked(float[] ColorRGB)
    {
        bool R, G, B, A;

        R = PlayerPrefs.GetFloat("colourR") == ColorRGB[0]? true : false;
        G = PlayerPrefs.GetFloat("colourG") == ColorRGB[1]? true : false;
        B = PlayerPrefs.GetFloat("colourB") == ColorRGB[2]? true : false;
        A = PlayerPrefs.GetFloat("colourA") == ColorRGB[3]? true : false;
        
        Check.SetActive(R & G & B & A? true : false);
    }

    public void CheckOn()
    {
        GameObject[] othersCheck = GameObject.FindGameObjectsWithTag("Check");

        for(int i = 0; i < othersCheck.Length; i++)
        {
            othersCheck[i].SetActive(false);
        }

        Check.SetActive(true);
    }

    public void FixedUpdate()
    {
        Checked(ColorRGB);
    }
}
