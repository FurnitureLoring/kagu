using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverBranch : MonoBehaviour
{
    public bool Hole;   //GameOverの時に画像表示の分岐用

    void Start()
    {
        Hole = false;
    }

    void FixedUpdate()
    {
        //SceneがGameOverなら動く
        if ("GameOver"==SceneManager.GetActiveScene().name)
        {
            //落とし穴に落ちた時のGameOver画面
            if(Hole==true)
            {
                //通常時のGAMEOVERをOFFに切り替える
                GameObject.Find("GameOver").SetActive(false);
                
                Hole = false;
            }
        }
    }
}
