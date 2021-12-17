using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    GameObject Furniture;           //家具情報の格納変数
    GameObject Goal;                //ゴール情報の格納変数
    GameObject Se;                  //SE情報の格納変数
    GameOverBranch branch;
    Animation Playeranimation;      //アニメーションスクリプトの情報格納変数
    public float distance;          //距離
    float possible_distance = 1.0f; //捕獲可能距離
    public float gauge = 0;         //捕獲ゲージ
    float Speed = 3.5f;             //移動スピード
    float CaptureSpeed = 3.0f;      //捕獲可能距離内でのスピード
    public bool hole;               //落とし穴判別用
    bool invert;                    //操作反転用
    bool stop;

    void Start()
    {
        //Animationスクリプトの情報を取得
        Playeranimation = GetComponent<Animation>();

        Se = GameObject.Find("SE");

        //家具のオブジェクトを取得
        Furniture = GameObject.Find("Furniture");

        //ゴールの情報を取得・リザルトスクリプトの情報を取得
        //Goal = GameObject.Find("Goal");
        //result_s = Goal.GetComponent<Result>();

        branch = GameObject.Find("StageName").GetComponent<GameOverBranch>();

        hole = false;

        invert = false;

        stop = false;
    }

    void FixedUpdate()
    {
        invert = false;

        //アニメーション初期化
        Playeranimation.AnimStop();

        //家具が存在するときと、落とし穴の上にいないときに動作
        if (Furniture != null && hole==false)
        {
            //前向きになる
            transform.rotation = Quaternion.Euler(0, 0, 0);

            //家具との距離を代入
            distance = Vector3.Distance(transform.position, Furniture.transform.position);

            //その場に停止
            if (Input.GetKey(KeyCode.Space))
            {
                invert = true;

                //後ろ向きになる
                transform.rotation = Quaternion.Euler(0, 180, 0);

                transform.position = transform.position;

                //アニメーションさせる
                Playeranimation.AnimIdle();

                //距離が設定された値より近くて、
                //プレイヤーのZ座標が家具のZ座標より大きいときに、
                //捕獲ゲージを増やす
                if (distance <= possible_distance && transform.position.z >= Furniture.transform.position.z)
                {
                    //一秒ごとに+1される
                    gauge += Time.deltaTime;
                    
                    //受け止めた時のSEを一度だけ再生
                    if(stop==false)
                    {
                        Se.GetComponent<SE>().StartSE_Stop();
                        stop = true;
                    }
                }
                else
                {
                    stop = false;
                }
            }            
            //前方に移動
            //距離が離れていれば速度が速くなり、近ければ同速になる
            else if (distance < possible_distance && invert==false)
            {
                transform.position += transform.forward * CaptureSpeed * Time.deltaTime;
            }
            else if(invert==false)
            {
                transform.position += transform.forward * Speed * Time.deltaTime;
            }

            if (invert == false)
            {
                //右に移動
                if (Input.GetKey(KeyCode.D))
                {
                    transform.position += transform.right * Speed * Time.deltaTime;

                    //アニメーションさせる
                    Playeranimation.AnimRight();
                }
                //左に移動
                if (Input.GetKey(KeyCode.A))
                {
                    transform.position -= transform.right * Speed * Time.deltaTime;

                    //アニメーションさせる
                    Playeranimation.AnimLeft();
                }
            }
            else
            {
                //右に移動
                if (Input.GetKey(KeyCode.A))
                {
                    transform.position += transform.right * Speed * Time.deltaTime * 0.1f;
                }
                //左に移動
                if (Input.GetKey(KeyCode.D))
                {
                    transform.position -= transform.right * Speed * Time.deltaTime * 0.1f;
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //Goalタグのオブジェクトに衝突したらresultをtrueにして自身を削除
        if (other.gameObject.CompareTag("Goal"))
        {
            SceneManager.LoadScene("GameOver");
        }
        //Holeタグのオブジェクトに衝突したら地面の下に落ちる
        if (other.gameObject.CompareTag("Hole"))
        {
            //落ちた時のSE
            Se.GetComponent<SE>().StartSE_Fall();

            //地面をすり抜けさせる
            this.GetComponent<BoxCollider>().isTrigger = true;
            hole = true;

            branch.Hole = true;

            Playeranimation.AnimFall();

            //GameOverに移動するためのコルーチン
            StartCoroutine(GameOverWait());
        }
    }

    //GameOverシーンに移動するコルーチン
    IEnumerator GameOverWait()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("GameOver");
    }
}
