using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    private float time;//動き出すまでの時間間隔

    void Update()
    {
        //動くまでの時間間隔を減少
        time -= Time.deltaTime;

        if (time <= 0)
        {
            //コルーチン開始
            StartCoroutine(Move());
            
            //再び動き出すまでの時間間隔を設定
            time = Random.Range(0.0f, 10.0f);
        }
    }

    //横に移動してまた同じ位置に戻ってくる
    IEnumerator Move()
    {
        for (int i = 0; i < 120; i++)
        {
            transform.Translate(0.1f, 0, 0);
            yield return new WaitForSeconds(0.05f);
        }

        for (int i = 0; i < 120; i++)
        {
            transform.Translate(-0.1f, 0, 0);
            yield return new WaitForSeconds(0.05f);
        }
    }
}
