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
        //家具の情報を取得
        Furniture = GameObject.Find("furniture");
    }

    void Update()
    {
        if (Furniture != null)
        {
            result = Furniture.GetComponent<Furniture>().result;
        }
        //家具がnullだったらClearSceneに移動
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
