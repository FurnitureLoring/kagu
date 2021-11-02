using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Furniture : MonoBehaviour
{
    GameObject Player;
    public Transform goal;
    private NavMeshAgent agent;
    Rigidbody rigidbody;
    Player script;
    private float Gauge;
    public bool result;

    //テスト用
    public float Speed = 2.0f;//移動スピード
    private float Gauge_MAX = 10;//捕獲ゲージ

    void Start()
    {
        //プレイヤーの情報を探して取得
        Player = GameObject.Find("Player");
        script = Player.GetComponent<Player>();
        rigidbody = this.GetComponent<Rigidbody>();

        agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
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
            result = false;
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Goal"))
        {
            result = true;
            Destroy(this.gameObject);
        }
    }
}
