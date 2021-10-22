using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furniture : MonoBehaviour
{
    GameObject Player;
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
        script = Player.GetComponent<Player>();
        rigidbody = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        //プレイヤーから捕獲ゲージを取得
        Gauge = script.gauge_test;

        //前方に移動
        this.rigidbody.velocity = new Vector3(0, 0, 1f);

        //捕獲ゲージが設定された値を超えると自身を削除
        if (Gauge > Gauge_MAX)
        {
            Destroy(this.gameObject);
        }
    }
}
