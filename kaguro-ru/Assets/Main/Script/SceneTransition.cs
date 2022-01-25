using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    GameObject StageName;   //StageName情報の格納変数
    StageName StageName_s;  //StageNameスクリプトの情報格納変数
    private string Stage;   //ステージ名を入れる変数

    void Start()
    {
        //StageNameオブジェクトの情報を取得
        StageName = GameObject.Find("StageName");
        if (StageName != null)
        {
            //StageNameスクリプトの情報を取得
            StageName_s = StageName.GetComponent<StageName>();
            //ステージ名を取得
            Stage = StageName_s.Stage;
        }
    }

    //ステージセレクト画面に移動
    public void StageSelect()
    {
        Destroy(StageName);
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

    //ステージ5に移動
    public void StageStart5()
    {
        SceneManager.LoadScene("Stage5");
    }

    //ステージ6に移動
    public void StageStart6()
    {
        SceneManager.LoadScene("Stage6");
    }


    //リトライ機能
    public void Retry()
    {
        switch (Stage)
        {
            case "Stage1":  //ステージ１
                SceneManager.LoadScene("Stage1");
                Destroy(StageName); //オブジェクトを破棄
                break;
            case "Stage2":  //ステージ２
                SceneManager.LoadScene("Stage2");
                Destroy(StageName); //オブジェクトを破棄
                break;
            case "Stage3":  //ステージ３
                SceneManager.LoadScene("Stage3");
                Destroy(StageName); //オブジェクトを破棄
                break;
            case "Stage4":  //ステージ４
                SceneManager.LoadScene("Stage4");
                Destroy(StageName); //オブジェクトを破棄
                break;
            case "Stage5":  //ステージ５
                SceneManager.LoadScene("Stage5");
                Destroy(StageName); //オブジェクトを破棄
                break;
            case "Stage6":  //ステージ６
                SceneManager.LoadScene("Stage6");
                Destroy(StageName); //オブジェクトを破棄
                break;
        }
    }

}
