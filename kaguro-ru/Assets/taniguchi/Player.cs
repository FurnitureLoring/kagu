using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 pos;
    Rigidbody rigidbody; 
    GameObject furniture;//家具
    private float distance;//距離
    private float time_interval;//

    //テスト用
    public float Speed = 2.0f;//移動スピード
    public float gauge_test = 0;//捕獲ゲージ
    public float distance_test = 1.0f;//捕獲可能距離

    void Start()
    {
        //家具のオブジェクトを探して取得
        furniture = GameObject.Find("furniture");
        rigidbody = this.GetComponent<Rigidbody>();
    }

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
        //家具が存在するときに動作
        if (furniture != null)
        {
            //家具との距離
            distance = Vector3.Distance(transform.position, furniture.transform.position);
          
            //前方に移動
            //距離が離れていれば速度が速くなり、近ければ同速になる
            if (distance < distance_test)
            {
                this.rigidbody.velocity = new Vector3(0, 0, 1f);
            }
            else
            {
                this.rigidbody.velocity = new Vector3(0, 0, 1.5f);
            }

            //距離が設定された値より近いとき捕獲ゲージを増やす
            if (Input.GetKey(KeyCode.Space))
            {
                if (distance < distance_test)
                {
                    //一秒ごとに+1される
                    gauge_test += Time.deltaTime;
                }
            }
        }
    }
}
