using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour
{
    public Transform Furniturepos;  //家具画像の位置情報を入れるための情報格納変数
    public Transform Humanpos;      //人間画像の位置情報を入れるための情報格納変数
    public RectTransform Rotatepos; //回転するための位置情報を入れるための情報格納変数
    public bool StartTitle;         //動いているか判別
    public float time;              //動くまでの時間間隔

    void Update()
    {
        //時間減少
        time -= Time.deltaTime;

        //時間間隔が0以下なら動く
        if (time <= 0)
        {
            if (!StartTitle)
            {
                StartTitle = true;
                //画像を画面の左端に配置する
                Furniturepos.position = new Vector3(-100.0f, 90.0f, 0.0f);
                Humanpos.position = new Vector3(-300.0f, 100.0f, 0.0f);

                //FurnitureAnimationコルーチンを動かす
                StartCoroutine(FurnitureAnimation());
                //HumanAnimationコルーチンを動かす
                StartCoroutine(HumanAnimation());
            }
            //時間間隔再設定
            time = 3.0f;
        }

    }

    //FurnitureAnimationコルーチン
    IEnumerator FurnitureAnimation()
    {
        for (int i = 0; i < 1000; i++)
        {
            //左端から右端に移動する
            Furniturepos.Translate(1.0f, 0.0f, 0.0f);
            //画像を回転させる
            Rotatepos.Rotate(0.0f, 0.0f, -1.0f);
            
            yield return new WaitForSeconds(0.01f);
        }
    }

    //HumanAnimationのコルーチン
    IEnumerator HumanAnimation()
    {
        for(int i = 0; i < 1000; i++)
        {
            //左端から右端に移動する
            Humanpos.Translate(-1.0f, 0.0f, 0.0f);

            yield return new WaitForSeconds(0.01f); 
        }

        StartTitle = false;
    }
}
