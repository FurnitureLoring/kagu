using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SE : MonoBehaviour
{
    public AudioClip ButtonSE;      //ボタン押下のSE
    public AudioClip StopSE;        //家具を受け止めている時のSE
    public AudioClip CountDownSE;   //カウントダウンSE
    public AudioClip WalkingSE;     //歩いている時のSE
    public AudioClip FallSE;        //穴に落ちた時のSE
    public AudioClip DamageSE;      //ダメージを受けた時のSE
    public AudioClip GameOverSE;    //ゲームオーバーになった時のSE
    public AudioClip ClearSE;       //クリアした時のSE

    bool SEflg;                     //音が何度もならないようにフラグで管理


    //テスト

    void Start()
    {
        SEflg = false;
    }

    void FixedUpdate()
    {
        //クリアした時にSEを再生
        if(SceneManager.GetActiveScene().name=="Clear"&&SEflg==false)
        {
            GetComponent<AudioSource>().PlayOneShot(ClearSE);
            SEflg = true;
        }

        //ゲームオーバーになった時にSEを再生
        if (SceneManager.GetActiveScene().name == "GameOver"&&SEflg==false)
        {
            GetComponent<AudioSource>().PlayOneShot(GameOverSE);
            SEflg = true;
        }
    }

    //ボタン押下した時のSE
    public void StartSE_Button()
    {
        GetComponent<AudioSource>().PlayOneShot(ButtonSE);
    }

    //家具を受け止めている時のSE
    public void StartSE_Stop()
    {
        GetComponent<AudioSource>().PlayOneShot(StopSE);
    }

    //カウントダウンSE
    public void StartSE_CountDown()

    {
        GetComponent<AudioSource>().PlayOneShot(CountDownSE);

    }

    //歩いている時のSE
    public void StartSE_Walking()
    {
        GetComponent<AudioSource>().PlayOneShot(WalkingSE);

    }

    //穴に落ちた時のSE
    public void StartSE_Fall()
    {
        GetComponent<AudioSource>().PlayOneShot(FallSE);

    }

    //ダメージを受けた時のSE
    public void StartSE_Damage()
    {
        GetComponent<AudioSource>().PlayOneShot(DamageSE);
    }
}
