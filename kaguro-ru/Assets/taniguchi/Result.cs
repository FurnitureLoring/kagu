using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour
{
    GameObject furniture;   //�Ƌ���̊i�[�ϐ�
    public bool result;     //���U���g�t���O    false:�N���A   true:�Q�[���I�[�o�[

    void Start()
    {
        //�Ƌ�̏����擾
        furniture = GameObject.Find("Furniture");
    }

    void Update()
    {
        //�Ƌnull�Ȃ瓮��
        if (furniture == null)
        {
            //result��false�Ȃ�N���A�ɁAtrue�Ȃ�Q�[���I�[�o�[�Ɉړ�
            if (result == false)
            {
                SceneManager.LoadScene("Clear");
            }
            if (result == true)
            {
                SceneManager.LoadScene("GameOver");
            }
        }
    }
}
