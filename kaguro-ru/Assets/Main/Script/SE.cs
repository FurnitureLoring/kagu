using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SE : MonoBehaviour
{
    public AudioClip ButtonSE;
    public AudioClip StopSE;
    public AudioClip CountDownSE;
    public AudioClip WalkingSE;
    public AudioClip JamSE;
    public AudioClip FallSE;
    public AudioClip DamageSE;

    public AudioClip GameOverSE;
    public AudioClip ClearSE;

    //ƒeƒXƒg
    bool SEflg;

    void Start()
    {
        SEflg = false;
    }

    void FixedUpdate()
    {
        if(SceneManager.GetActiveScene().name=="Clear"&&SEflg==false)
        {
            GetComponent<AudioSource>().PlayOneShot(ClearSE);
            SEflg = true;
        }

        if (SceneManager.GetActiveScene().name == "GameOver"&&SEflg==false)
        {
            GetComponent<AudioSource>().PlayOneShot(GameOverSE);
            SEflg = true;
        }
    }

    public void StartSE_Button()
    {
        GetComponent<AudioSource>().PlayOneShot(ButtonSE);
    }

    public void StartSE_Stop()
    {
        GetComponent<AudioSource>().PlayOneShot(StopSE);

    }

    public void StartSE_CountDown()

    {
        GetComponent<AudioSource>().PlayOneShot(CountDownSE);

    }

    public void StartSE_Walking()
    {
        GetComponent<AudioSource>().PlayOneShot(WalkingSE);

    }

    public void StartSE_Jam()
    {
        GetComponent<AudioSource>().PlayOneShot(JamSE);

    }

    public void StartSE_Fall()
    {
        GetComponent<AudioSource>().PlayOneShot(FallSE);

    }

    public void StartSE_Damage()
    {
        GetComponent<AudioSource>().PlayOneShot(DamageSE);
    }
}
