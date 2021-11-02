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
        //�Ƌ�̏����擾
        Furniture = GameObject.Find("furniture");
    }

    void Update()
    {
        if (Furniture != null)
        {
            result = Furniture.GetComponent<Furniture>().result;
        }
        //�Ƌnull��������ClearScene�Ɉړ�
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
