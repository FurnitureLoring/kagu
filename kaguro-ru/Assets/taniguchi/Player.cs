using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 pos;
    GameObject furniture;//家具
    private float distance;//距離

    //テスト用
    public float Speed = 4.0f;//移動スピード
    public float gauge_test = 0;//捕獲ゲージ
    public float distance_test = 1.5f;//捕獲可能距離

    void Start()
    {
        //家具のオブジェクトを探して取得
        furniture = GameObject.Find("furniture");
    }

    // Update is called once per frame
    void Update()
    {
        pos = transform.position;

        //右に移動
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * Speed * Time.deltaTime;
            pos = transform.position;
        }
        //左に移動
        if(Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * Speed * Time.deltaTime;
            pos = transform.position;
        }
        //前に移動
        if(Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * Speed * Time.deltaTime;
        }

        //家具との距離が設定された値より短いとき捕獲ゲージを増やす
        if (Input.GetKey(KeyCode.Space))
        {

            distance = Vector3.Distance(transform.position, furniture.transform.position);
            if (distance < distance_test)
            {
                //一秒ごとに+1される
                gauge_test += Time.deltaTime;
            }
        }

    }
}
