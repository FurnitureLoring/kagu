using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Furniture : MonoBehaviour
{
    GameObject Player;              //プレイヤー情報の格納変数
    GameObject Goal;                //ゴール情報の格納変数
    public Transform goal;          //ナビゲーションシステムのゴール情報を格納
    private NavMeshAgent agent;     //ナビゲーションシステム
    Rigidbody rigidbody;
    Result result;                  //リザルトスクリプトの情報格納変数
    Player player;                  //プレイヤースクリプトの情報格納変数
    private float Gauge;            //捕獲ゲージ
    private float Gauge_MAX = 10;   //捕獲ゲージMAX

    //テスト用
    public float Speed = 2.0f;//移動スピード

    void Start()
    {
        //プレイヤーの情報を探して取得
        Player = GameObject.Find("Player");
        player = Player.GetComponent<Player>();
        rigidbody = this.GetComponent<Rigidbody>();

        //ゴールの情報を探して取得
        Goal = GameObject.Find("Goal");
        result = Goal.GetComponent<Result>();

        //ナビゲーションシステム
        agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
    }

    void Update()
    {
        //プレイヤーから捕獲ゲージを取得
        Gauge = player.gauge;

        //前方に移動
        this.rigidbody.velocity = new Vector3(0, 0, 1f);

        //捕獲ゲージが設定された値を超えるとresultをfalseにして自身を削除
        if (Gauge > Gauge_MAX)
        {
            result.result = false;
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //Goalタグのオブジェクトに衝突したらresultをtrueにして自身を削除
        if (other.gameObject.CompareTag("Goal"))
        {
            result.result = true;
            Destroy(this.gameObject);
        }
    }
}
