using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverBranch : MonoBehaviour
{
    public bool Hole;//GameOver‚Ì‚É‰æ‘œ•\¦‚Ì•ªŠò—p

    void Start()
    {
        Hole = false;
    }

    void FixedUpdate()
    {
        if ("GameOver"==SceneManager.GetActiveScene().name)
        {
            //—‚Æ‚µŒŠ‚É—‚¿‚½‚ÌGameOver‰æ–Ê
            if(Hole==true)
            {
                //UI‚Ìimage‰æ‘œ‚ğOFF‚ÉØ‚è‘Ö‚¦‚é
                GameObject.Find("GameOver").SetActive(false);
                
                Hole = false;
            }
        }
    }
}
