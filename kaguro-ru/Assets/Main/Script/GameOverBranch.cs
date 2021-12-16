using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverBranch : MonoBehaviour
{
    public bool Hole;   //GameOver�̎��ɉ摜�\���̕���p

    void Start()
    {
        Hole = false;
    }

    void FixedUpdate()
    {
        if ("GameOver"==SceneManager.GetActiveScene().name)
        {
            //���Ƃ����ɗ���������GameOver���
            if(Hole==true)
            {
                //�ʏ펞��GAMEOVER��OFF�ɐ؂�ւ���
                GameObject.Find("GameOver").SetActive(false);
                
                Hole = false;
            }
        }
    }
}
