using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int hp;          //主人公のHP
    public bool Hit;        //衝突したか判定用
    public float cooltime;  //クールタイム

    void Start()
    {
        Hit = false;
        hp = 5;
        cooltime = 2.0f;
    }

    void FixedUpdate()
    {
        //主人公のHPが0になるとゲームオーバー
        if (hp <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }    
    }

    //障害物にぶつかるとHPが減少
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle")&&Hit==false)
        {
            hp--;
            Hit = true;
            //もう一度当たるまでのクールタイムを開始
            StartCoroutine(CoolTime());
        }
        if(other.gameObject.CompareTag("MoveObstacle")&&Hit==false)
        {
            hp -= 3;
            Hit = true;
            //もう一度当たるまでのクールタイムを開始
            StartCoroutine(CoolTime());
        }
    }

    //クールタイムコルーチン
    //もう一度当たるまでの時間は2秒
    IEnumerator CoolTime()
    {
        yield return new WaitForSeconds(cooltime);
        Hit = false;
    }


}
