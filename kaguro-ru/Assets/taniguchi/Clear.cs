using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Clear : MonoBehaviour
{
    GameObject Furniture;

    void Start()
    {
        //�Ƌ�̏����擾
        Furniture = GameObject.Find("furniture");
    }

    void Update()
    {
        //�Ƌnull��������ClearScene�Ɉړ�
        if(Furniture==null)
        {
            SceneManager.LoadScene("Clear");
        }
    }
}
