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
    Result result_s;                //リザルトスクリプトの情報格納変数
    Player player_s;                //プレイヤースクリプトの情報格納変数
    private float Gauge;            //捕獲ゲージ
    private float Gauge_MAX = 10;   //捕獲ゲージMAX
    float Speed = 2.5f;             //移動スピード
    public Slider slider;           //sliderを入れる
    const int pathMax = 9;                      //パスの最大登録数
    Vector3[] positions = new Vector3[pathMax]; //座標リスト
    int position = 0;

    //テスト用

    IEnumerator Start()
    {
        //プレイヤーの情報を取得・プレイヤースクリプトの情報を取得
        Player = GameObject.Find("Player");
        player_s = Player.GetComponent<Player>();

        //ゴールの情報を取得・リザルトスクリプトの情報を取得
        Goal = GameObject.Find("Goal");
        result_s = Goal.GetComponent<Result>();

        //ナビゲーションシステム
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(goal.position);
        yield return new WaitWhile(() => agent.pathStatus != NavMeshPathStatus.PathComplete);
        agent.path.GetCornersNonAlloc(positions);

        //スライダーの捕獲ゲージを0にする
        slider.value = 0;
    }

    void FixedUpdate()
    {
        //プレイヤーから捕獲ゲージを取得
        Gauge = player_s.gauge;

        //スライダーに現在の捕獲ゲージを入れる
        slider.value = Gauge / Gauge_MAX;

        //障害物を避けながら前方に移動
        var tragetPosition = positions[position];
        if (Vector3.Distance(transform.position, tragetPosition) < 0.2f)
        {
            position = position + 1 < positions.Length ? position + 1 : position;
        }
        transform.localPosition = Vector3.MoveTowards(transform.position, tragetPosition, Speed * Time.deltaTime);

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
