using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageName : MonoBehaviour
{
    public string Stage;    //ステージ名を入れる変数

    void Start()
    {
        //シーンを移動しても破壊されないようにする
        DontDestroyOnLoad(this);
        //Scene名を取得
        Stage = SceneManager.GetActiveScene().name;

    }
}
