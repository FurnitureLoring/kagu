using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour
{
    GameObject furniture;   //家具情報の格納変数
    GameObject Player;      //プレイヤー情報の格納変数
    public bool result;     //リザルトフラグ    false:クリア   true:ゲームオーバー

    void Start()
    {
        //家具の情報を取得
        furniture = GameObject.Find("Furniture");        
        //プレイヤーの情報を取得
        Player = GameObject.Find("Player");

    }

    void FixedUpdate()
    {
        //家具がnullなら動作
        if (furniture == null || Player == null)
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
