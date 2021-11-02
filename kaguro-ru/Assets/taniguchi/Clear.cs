using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Clear : MonoBehaviour
{
    GameObject Furniture;
    bool result;

    void Start()
    {
        //‰Æ‹ï‚Ìî•ñ‚ğæ“¾
        Furniture = GameObject.Find("furniture");
    }

    void Update()
    {
        if (Furniture != null)
        {
            result = Furniture.GetComponent<Furniture>().result;
        }
        //‰Æ‹ï‚ªnull‚¾‚Á‚½‚çClearScene‚ÉˆÚ“®
        if (Furniture == null && result == false)
        {
            SceneManager.LoadScene("Clear");
        }
        if (Furniture == null && result == true)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
