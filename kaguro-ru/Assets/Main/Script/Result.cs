using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour
{
    GameObject Furniture;   //Furniture���̊i�[�ϐ�
    GameObject Player;      //Player���̊i�[�ϐ�
    public bool result;     //���U���g�t���O
                            //false:�N���A   true:�Q�[���I�[�o�[

    void Start()
    {
        //�Ƌ�̏����擾
        Furniture = GameObject.Find("Furniture");        
        //�v���C���[�̏����擾
        Player = GameObject.Find("Player");

    }

    void FixedUpdate()
    {
        //�Ƌ�v���C���[��null�Ȃ瓮��
        if (Furniture == null || Player == null)
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
