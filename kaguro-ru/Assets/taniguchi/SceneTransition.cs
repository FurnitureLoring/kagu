using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{

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
    public void StageSelect2()
    {
        SceneManager.LoadScene("Stage2");
    }

    //ステージ3に移動
    public void StageSelect3()
    {
        SceneManager.LoadScene("Stage3");
    }

    //ステージ4に移動
    public void StageSelect4()
    {
        SceneManager.LoadScene("Stage4");
    }

}
