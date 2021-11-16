using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageName : MonoBehaviour
{
    //StageName
    public string Stage;

    void Start()
    {
        //DontDestroyOnLoad(this);
    }

    void Update()
    {
        //åªç›ÇÃSceneÇãLâØ
        Stage = SceneManager.GetActiveScene().name;
        switch (Stage)
        {
            case "Stage1":
                Stage = "Stage1";
                break;
            case "Stage2":
                Stage = "Stage2";
                break;
            case "Stage3":
                Stage = "Stage3";
                break;
            case "Stage4":
                Stage = "Stage4";
                break;
        }
    }
}
