using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Clear : MonoBehaviour
{
    GameObject Furniture;

    void Start()
    {
        //家具の情報を取得
        Furniture = GameObject.Find("furniture");
    }

    void Update()
    {
        //家具がnullだったらClearSceneに移動
        if(Furniture==null)
        {
            SceneManager.LoadScene("Clear");
        }
    }
}
