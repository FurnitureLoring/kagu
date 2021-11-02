using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rigidbody;
    GameObject furniture;           //家具情報の格納変数
    public float distance;         //距離
    float possible_distance = 1.5f; //捕獲可能距離
    public float gauge = 0;         //捕獲ゲージ

    //テスト用
    public float Speed = 2.0f;//移動スピード
    void Start()
    {
        //家具のオブジェクトを探して取得
        furniture = GameObject.Find("furniture");
        rigidbody = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        //右に移動
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * Speed * Time.deltaTime;
        }
        //左に移動
        if(Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * Speed * Time.deltaTime;
        }
        //家具が存在するときに動作
        if (furniture != null)
        {
            //家具との距離を代入
            distance = Vector3.Distance(transform.position, furniture.transform.position);

            //前方に移動
            //距離が離れていれば速度が速くなり、近ければ同速になる
            if (distance < possible_distance)
            {
                this.rigidbody.velocity = new Vector3(0, 0, 0.1f);
            }
            else
            {
                this.rigidbody.velocity = new Vector3(0, 0, 1.5f);
            }

            //距離が設定された値より近いときに
            //spaceキーを入力すると捕獲ゲージを増やす
            if (Input.GetKey(KeyCode.Space))
            {
                if (distance < possible_distance)
                {
                    //一秒ごとに+1される
                    gauge += Time.deltaTime;
                }
            }
        }
    }
}
