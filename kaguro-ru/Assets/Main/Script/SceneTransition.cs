using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    GameObject StageName;
    StageName StageName_s;
    private string Stage;

    void Start()
    {
        //StageName = GameObject.Find("StageName");
        //StageName_s = StageName.GetComponent<StageName>();
        //Stage = StageName_s.Stage;
    }

    //ステージセレクト画面に移動
    public void StageSelect()
    {
        SceneManager.LoadScene("StageSelect");
    }

    //タイトル画面に移動
    public void Title()
    {
        SceneManager.LoadScene("Title");
    }

    //ステージ1に移動
    public void StageStart1()
    {
        SceneManager.LoadScene("Stage1");
    }

    //ステージ2に移動
    public void StageStart2()
    {
        SceneManager.LoadScene("Stage2");
    }

    //ステージ3に移動
    public void StageStart3()
    {
        SceneManager.LoadScene("Stage3");
    }

    //ステージ4に移動
    public void StageStart4()
    {
        SceneManager.LoadScene("Stage4");
    }

    //リトライ機能
    //public void Retry()
    //{
    //    switch (Stage)
    //    {
    //        case "Stage1":
    //            SceneManager.LoadScene("Stage1");
    //            break;
    //        case "Stage2":
    //            SceneManager.LoadScene("Stage2");
    //            break;
    //        case "Stage3":
    //            SceneManager.LoadScene("Stage3");
    //            break;
    //        case "Stage4":
    //            SceneManager.LoadScene("Stage4");
    //            break;
    //    }
    //}

}
