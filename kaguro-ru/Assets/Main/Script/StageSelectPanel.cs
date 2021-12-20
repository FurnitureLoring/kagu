using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageSelectPanel : MonoBehaviour
{
    GameObject[] Panel = new GameObject[3];     //StagePanel配列

    void Start()
    {
        Panel[0] = GameObject.Find("StagePanel1");
        Panel[1] = GameObject.Find("StagePanel2");
        Panel[2] = GameObject.Find("StagePanel3");
    }

    public void PanelBack()
    {
        //StageSelectパネルが端を超えて移動しないように制御
        if (Panel[0].transform.localPosition == new Vector3(0.0f, 0.0f, 0.0f)||
            Panel[1].transform.localPosition == new Vector3(0.0f, 0.0f, 0.0f))
        {
            for (int i = 0; i < 3; i++)
            {
                StartCoroutine(Back(Panel[i]));
            }
        }
    }

    public void PanelForward()
    {
        //StageSelectパネルが端を超えて移動しないように制御
        if (Panel[1].transform.localPosition == new Vector3(0.0f, 0.0f, 0.0f)||
            Panel[2].transform.localPosition == new Vector3(0.0f, 0.0f, 0.0f))
        {
            for (int i = 0; i < 3; i++)
            {
                StartCoroutine(Forward(Panel[i]));
            }
        }
    }

    //StageSelectパネルが左に移動
    IEnumerator Back(GameObject Panel)
    {
        for (int i = 0; i < 200; i++)
        {
            Panel.transform.localPosition -= new Vector3(4.0f, 0.0f, 0.0f);
            yield return new WaitForSeconds(0.0001f);
        }
    }

    //StageSelectパネルが右に移動
    IEnumerator Forward(GameObject Panel)
    {
        for(int i=0;i<200;i++)
        {
            Panel.transform.localPosition += new Vector3(4.0f, 0.0f, 0.0f);
            yield return new WaitForSeconds(0.0001f); 
        }
    }
}
