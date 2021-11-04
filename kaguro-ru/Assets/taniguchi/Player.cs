using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rigidbody;
    GameObject furniture;           //家具情報の格納変数
    GameObject pitfall;             //落とし穴情報の格納変数
    Pitfall pitfall_s;              //落とし穴スクリプト情報の格納変数
    public float distance;          //距離
    float possible_distance = 1.5f; //捕獲可能距離
    public float gauge = 0;         //捕獲ゲージ

    //テスト用
    public float Speed = 2.0f;//移動スピード
    public float pitfall_time = 0;

    void Start()
    {
        //家具のオブジェクトを探して取得
        furniture = GameObject.Find("furniture");
        //落とし穴のオブジェクトを探して取得・落とし穴スクリプトの情報を取得
        pitfall = GameObject.Find("pitfall");
        pitfall_s = pitfall.GetComponent<Pitfall>();

        rigidbody = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (pitfall!=null)
        {
            pitfall_time = pitfall_s.pitfall_time;

            //今のところテストで３秒以上落とし穴の上にいると落ちる
            while(pitfall_time <= 3.0f)
            {
                Destroy(this.gameObject);
            }
        }


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
