using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SE : MonoBehaviour
{
    public AudioClip ButtonSE;      //�{�^��������SE
    public AudioClip StopSE;        //�Ƌ���󂯎~�߂Ă��鎞��SE
    public AudioClip CountDownSE;   //�J�E���g�_�E��SE
    public AudioClip WalkingSE;     //�����Ă��鎞��SE
    public AudioClip FallSE;        //���ɗ���������SE
    public AudioClip DamageSE;      //�_���[�W���󂯂�����SE
    public AudioClip GameOverSE;    //�Q�[���I�[�o�[�ɂȂ�������SE
    public AudioClip ClearSE;       //�N���A��������SE

    bool SEflg;                     //�������x���Ȃ�Ȃ��悤�Ƀt���O�ŊǗ�


    //�e�X�g

    void Start()
    {
        SEflg = false;
    }

    void FixedUpdate()
    {
        //�N���A��������SE���Đ�
        if(SceneManager.GetActiveScene().name=="Clear"&&SEflg==false)
        {
            GetComponent<AudioSource>().PlayOneShot(ClearSE);
            SEflg = true;
        }

        //�Q�[���I�[�o�[�ɂȂ�������SE���Đ�
        if (SceneManager.GetActiveScene().name == "GameOver"&&SEflg==false)
        {
            GetComponent<AudioSource>().PlayOneShot(GameOverSE);
            SEflg = true;
        }
    }

    //�{�^��������������SE
    public void StartSE_Button()
    {
        GetComponent<AudioSource>().PlayOneShot(ButtonSE);
    }

    //�Ƌ���󂯎~�߂Ă��鎞��SE
    public void StartSE_Stop()
    {
        GetComponent<AudioSource>().PlayOneShot(StopSE);
    }

    //�J�E���g�_�E��SE
    public void StartSE_CountDown()

    {
        GetComponent<AudioSource>().PlayOneShot(CountDownSE);

    }

    //�����Ă��鎞��SE
    public void StartSE_Walking()
    {
        GetComponent<AudioSource>().PlayOneShot(WalkingSE);

    }

    //���ɗ���������SE
    public void StartSE_Fall()
    {
        GetComponent<AudioSource>().PlayOneShot(FallSE);

    }

    //�_���[�W���󂯂�����SE
    public void StartSE_Damage()
    {
        GetComponent<AudioSource>().PlayOneShot(DamageSE);
    }
}
