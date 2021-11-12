using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rigidbody;
    GameObject furniture;           //家具情報の格納変数
    //GameObject pitfall;             //落とし穴情報の格納変数
    GameObject Goal;                //ゴール情報の格納変数
    //Pitfall pitfall_s;              //落とし穴スクリプト情報の格納変数
    Result result_s;                //リザルトスクリプトの情報格納変数

    public float distance;          //距離
    float possible_distance = 1.5f; //捕獲可能距離
    public float gauge = 0;         //捕獲ゲージ
    float Speed = 3.5f;//移動スピード
    float CaptureSpeed = 3.0f;//捕獲可能距離内でのスピード
    
    //テスト用


    void Start()
    {
        //家具のオブジェクトを取得
        furniture = GameObject.Find("Furniture");
        
        ////落とし穴のオブジェクトを取得・落とし穴スクリプトの情報を取得
        //pitfall = GameObject.Find("Pitfall");
        //pitfall_s = pitfall.GetComponent<Pitfall>();
        
        //ゴールの情報を取得・リザルトスクリプトの情報を取得
        Goal = GameObject.Find("Goal");
        result_s = Goal.GetComponent<Result>();

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
            if (Input.GetKey(KeyCode.S))
            {
                transform.position = transform.position;
            }
            else if (distance < possible_distance)
            {
                this.rigidbody.velocity = new Vector3(0, 0, CaptureSpeed);
            }
            else
            {
                this.rigidbody.velocity = new Vector3(0, 0, Speed);
            }

            //距離が設定された値より近いときに
            //spaceキーを入力すると捕獲ゲージを増やす
            if (Input.GetKey(KeyCode.Space))
            {
                if (distance <= possible_distance)
                {
                    //一秒ごとに+1される
                    gauge += Time.deltaTime;
                }
            }
        }
    }

    //void OnTriggerEnter(Collider other)
    //{
    //    //Holeタグのオブジェクトに衝突したらresultをtrueにして自身を削除
    //    if (other.gameObject.CompareTag("Hole"))
    //    {
    //        result_s.result = true;
    //        //コンポーネントをOFFにするといけるかも
    //    }
    //}
}
