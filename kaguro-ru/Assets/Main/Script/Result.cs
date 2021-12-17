using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour
{
    GameObject Furniture;   //Furniture情報の格納変数
    GameObject Player;      //Player情報の格納変数
    public bool result;     //リザルトフラグ
                            //false:クリア   true:ゲームオーバー

    void Start()
    {
        //家具の情報を取得
        Furniture = GameObject.Find("Furniture");        
        //プレイヤーの情報を取得
        Player = GameObject.Find("Player");

    }

    void FixedUpdate()
    {
        //家具かプレイヤーがnullなら動作
        if (Furniture == null || Player == null)
        {
            //resultがfalseならクリアに、trueならゲームオーバーに移動
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
