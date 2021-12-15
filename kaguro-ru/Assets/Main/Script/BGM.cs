using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGM : MonoBehaviour
{
    void Start()
    {
        //BGM�^�O�������I�u�W�F�N�g������������DontDestroy���A
        //�����łȂ���Ύ��g���폜
        if (GameObject.FindGameObjectsWithTag("BGM").Length<=1)
        {
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void FixedUpdate()
    {
        //Stage���n�܂�Ǝ��g���폜
        if ("Stage1" == SceneManager.GetActiveScene().name)
        {
            Destroy(this.gameObject);
        }
        if ("Stage2" == SceneManager.GetActiveScene().name)
        {
            Destroy(this.gameObject);
        }
        if ("Stage3" == SceneManager.GetActiveScene().name)
        {
            Destroy(this.gameObject);
        }
    }

    //BGM���t�F�[�h�A�E�g���Ă���
    public void FadeOut()
    {
        this.GetComponent<AudioSource>().volume -= 0.01f;
    }
}
