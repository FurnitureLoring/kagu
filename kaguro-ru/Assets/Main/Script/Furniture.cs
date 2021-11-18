using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Furniture : MonoBehaviour
{
    GameObject Player;              //プレイヤー情報の格納変数
    GameObject Goal;                //ゴール情報の格納変数
    public Transform goal;          //ナビゲーションシステムのゴール情報を格納
    private NavMeshAgent agent;     //ナビゲーションシステム
    Rigidbody rigidbody;
    Result result_s;                //リザルトスクリプトの情報格納変数
    Player player_s;                //プレイヤースクリプトの情報格納変数
    private float Gauge;            //捕獲ゲージ
    private float Gauge_MAX = 10;   //捕獲ゲージMAX
    float Speed = 3.0f;             //移動スピード
    public Slider slider;           //sliderを入れる

    //テスト用


    void Start()
    {
        //プレイヤーの情報を取得・プレイヤースクリプトの情報を取得
        Player = GameObject.Find("Player");
        player_s = Player.GetComponent<Player>();

        //ゴールの情報を取得・リザルトスクリプトの情報を取得
        Goal = GameObject.Find("Goal");
        result_s = Goal.GetComponent<Result>();

        rigidbody = this.GetComponent<Rigidbody>();

        //ナビゲーションシステム
        agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;

        //スライダーの捕獲ゲージを0にする
        //slider.value = 0;
    }

    void Update()
    {
        //プレイヤーから捕獲ゲージを取得
        Gauge = player_s.gauge;

        //スライダーに現在の捕獲ゲージを入れる
        //slider.value = Gauge / Gauge_MAX;

        //前方に移動
        this.rigidbody.velocity = new Vector3(0, 0, Speed);

        //捕獲ゲージが設定された値を超えるとresultをfalseにして自身を削除
        if (Gauge > Gauge_MAX)
        {
            result_s.result = false;
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //Goalタグのオブジェクトに衝突したらresultをtrueにして自身を削除
        if (other.gameObject.CompareTag("Goal"))
        {
            result_s.result = true;
            Destroy(this.gameObject);
        }
    }
}
