using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furniture : MonoBehaviour
{
    GameObject Player;
    GameObject Obstacle;
    Rigidbody rigidbody;
    Player script;
    private float Gauge;

    //テスト用
    public float Speed = 2.0f;//移動スピード
    private float Gauge_MAX = 1;//捕獲ゲージ

    void Start()
    {
        //プレイヤーの情報を探して取得
        Player = GameObject.Find("Player");
        Obstacle = GameObject.Find("obstacle");
        script = Player.GetComponent<Player>();
        rigidbody = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        //プレイヤーから捕獲ゲージを取得
        Gauge = script.gauge_test;

        //前方に移動
        this.rigidbody.velocity = new Vector3(0, 0, 1f);

        //前方に障害物があると横に避ける（未完成）
        ////Rayを飛ばして前方に物体があるか調べる
        ////Rayの作成　　　　　　　↓Rayを飛ばす原点　　　↓Rayを飛ばす方向
        //Ray ray = new Ray(transform.position, new Vector3(0, -1, 10));

        //RaycastHit hit;
        ////Rayの飛ばせる距離
        //int distance = 20;

        ////Ray可視化
        //Debug.DrawLine(ray.origin, ray.direction * distance, Color.red);

        ////もしRayにオブジェクトが衝突したら
        ////                  ↓Ray  ↓Rayが当たったオブジェクト ↓距離
        //if (Physics.Raycast(ray,out hit, distance))
        //{
        //    if(hit.collider.tag == "Obstacle")
        //    {
        //        this.rigidbody.velocity = new Vector3(1.0f, 0, 0);
        //    }
        //}


        //捕獲ゲージが設定された値を超えると自身を削除
        if (Gauge > Gauge_MAX)
        {
            Destroy(this.gameObject);
        }
    }
}
