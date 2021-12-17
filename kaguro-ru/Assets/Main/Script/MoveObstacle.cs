using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    private float time;     //動き出すまでの時間間隔
    private bool isMove;    //動いているかを判別

    void FixedUpdate()
    {
        //動くまでの時間間隔を減少
        time -= Time.deltaTime;

        if (time <= 0)
        {
            if (!isMove)
            {
                //フラグをtrueにする
                isMove = true;
                //コルーチンを動かす
                StartCoroutine(Move());
            }
            //再び動き出すまでの時間間隔を設定
            time = Random.Range(0.0f, 10.0f);
        }
    }

    //移動コルーチン
    IEnumerator Move()
    {
        for (int i = 0; i < 200; i++)
        {
            transform.Translate(0, 0, 0.1f);
            yield return new WaitForSeconds(0.05f);
        }

        //180°回転
        transform.Rotate(0, -180.0f, 0);

        for (int i = 0; i < 200; i++)
        {
            transform.Translate(0, 0, 0.1f);
            yield return new WaitForSeconds(0.05f);
        }
        //フラグをfalseにする
        isMove = false;

        //180°回転
        transform.Rotate(0, 180.0f, 0);
    }
}
