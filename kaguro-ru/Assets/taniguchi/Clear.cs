using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Clear : MonoBehaviour
{
    GameObject Furniture;

    void Start()
    {
        //‰Æ‹ï‚Ìî•ñ‚ğæ“¾
        Furniture = GameObject.Find("furniture");
    }

    void Update()
    {
        //‰Æ‹ï‚ªnull‚¾‚Á‚½‚çClearScene‚ÉˆÚ“®
        if(Furniture==null)
        {
            SceneManager.LoadScene("Clear");
        }
    }
}
