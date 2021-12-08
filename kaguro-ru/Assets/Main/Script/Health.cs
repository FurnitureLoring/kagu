using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int hp;          //主人公のHP
    public bool Hit;        //衝突したか判定用
    public float cooltime;  //クールタイム

    //テスト
    GameObject[] heart = new GameObject[5]; //HP配列
    public int downhp;                             //HPの減少量

    void Start()
    {
        Hit = false;
        hp = 5;
        cooltime = 2.0f;

        heart[0] = GameObject.Find("Heart0");
        heart[1] = GameObject.Find("Heart1");
        heart[2] = GameObject.Find("Heart2");
        heart[3] = GameObject.Find("Heart3");
        heart[4] = GameObject.Find("Heart4");
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
            downhp = 1;
            Hit = true;
            //もう一度当たるまでのクールタイムを開始
            StartCoroutine(CoolTime());
        }
        if(other.gameObject.CompareTag("MoveObstacle")&&Hit==false)
        {
            hp -= 2;
            downhp = 2;
            Hit = true;
            //もう一度当たるまでのクールタイムを開始
            StartCoroutine(CoolTime());
        }

        //HPは5しかないのでif分を5つ用意して数字の大きいものから非表示にしていく
        //障害物に当たった時にカウントが増やされ、増やしたカウントが0になるまで
        //HPのUIを非表示にする
        if (downhp > 0)
        {
            heart[hp + downhp - 1].SetActive(false);
            downhp--;
        }
    }

    //クールタイムコルーチン
    //もう一度当たるまでの時間は2秒
    IEnumerator CoolTime()
    {
        yield return new WaitForSeconds(cooltime);
        Hit = false;
    }

    //HPは5しかないのでif分を5つ用意して数字の大きいものから非表示にしていく
    //障害物に当たった時にカウントが増やされ、増やしたカウントが0になるまで
    //HPのUIを非表示にする
}
