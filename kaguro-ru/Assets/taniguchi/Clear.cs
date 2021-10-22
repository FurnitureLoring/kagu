using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clear : MonoBehaviour
{
    GameObject Furniture;


    void Start()
    {
        Furniture = GameObject.Find("Furniture");
    }

    void Update()
    {
        if(Furniture==null)
        {

        }
    }
}
