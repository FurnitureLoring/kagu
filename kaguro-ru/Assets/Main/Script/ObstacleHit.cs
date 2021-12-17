using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleHit : MonoBehaviour
{
    GameObject Player;              //Player情報の格納変数
    Player player_s;                //Playerスクリプトの情報格納変数
    Animation Playeranimation;      //アニメーションスクリプトの情報格納変数
    bool Hit;                       //障害物の衝突判定用

    void Start()
    {
        //Playerオブジェクト・Playerスクリプトの情報を取得
        Player = GameObject.Find("Player");
        player_s = Player.GetComponent<Player>();

        //Animationスクリプトの情報を取得
        Playeranimation = GetComponent<Animation>();

        //衝突判定をfalseで初期化
        Hit = false;
    }

    void FixedUpdate()
    {
        //衝突判定がfalseならプレイヤーの移動が可能
        //trueならプレイヤーが停止
        if(Hit==false)
        {
            player_s.enabled = true;
        }
        if (Hit == true)
        {
            player_s.enabled = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //障害物に当たると衝突判定がtrueに
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Hit = true;
            StartCoroutine(HitObstacle());   
        }
        if(other.gameObject.CompareTag("MoveObstacle"))
        {
            Hit = true;
            StartCoroutine(HitObstacle());
        }
    }

    //障害物に当たった時に動くコルーチン
    IEnumerator HitObstacle()
    {
        Playeranimation.AnimDamage();
        yield return new WaitForSeconds(2.0f);
        Hit = false;
    }
}
