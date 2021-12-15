using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGM : MonoBehaviour
{
    void Start()
    {
        //BGMタグがついたオブジェクトが一つも無ければDontDestroyし、
        //そうでなければ自身を削除
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
        //Stageが始まると自身を削除
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

    //BGMがフェードアウトしていく
    public void FadeOut()
    {
        this.GetComponent<AudioSource>().volume -= 0.01f;
    }
}
