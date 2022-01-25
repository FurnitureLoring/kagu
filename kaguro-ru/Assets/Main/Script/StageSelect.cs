using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageSelect : MonoBehaviour
{
    GameObject[] Panel = new GameObject[3];     //StagePanel�z��

    public GameObject Camera;

    void Start()
    {
        Panel[0] = GameObject.Find("StagePanel1");
        Panel[1] = GameObject.Find("StagePanel2");
        Panel[2] = GameObject.Find("StagePanel3");
    }

    public void Back()
    {
        //StageSelect�p�l�����[�𒴂��Ĉړ����Ȃ��悤�ɐ���
        if (Panel[1].transform.localPosition == new Vector3(0.0f, 0.0f, 0.0f)
            //||Panel[2].transform.localPosition == new Vector3(0.0f, 0.0f, 0.0f)
            )
        {
            for (int i = 0; i < 3; i++)
            {
                StartCoroutine(PanelBack(Panel[i]));
                StartCoroutine(CameraBack(Camera));
            }
        }
    }

    public void Forward()
    {
        //StageSelect�p�l�����[�𒴂��Ĉړ����Ȃ��悤�ɐ���
        if (Panel[0].transform.localPosition == new Vector3(0.0f, 0.0f, 0.0f)
            //||Panel[1].transform.localPosition == new Vector3(0.0f, 0.0f, 0.0f)
            )
        {
            for (int i = 0; i < 3; i++)
            {
                StartCoroutine(PanelForward(Panel[i]));
                StartCoroutine(CameraForward(Camera));
            }
        }
    }

    //StageSelect�p�l�������Ɉړ�
    IEnumerator PanelBack(GameObject Panel)
    {
        for (int i = 0; i < 100; i++)
        {
            Panel.transform.localPosition += new Vector3(8.0f, 0.0f, 0.0f);
            yield return new WaitForSeconds(0.0001f);
        }
    }

    //StageSelect�p�l�����E�Ɉړ�
    IEnumerator PanelForward(GameObject Panel)
    {
        for(int i=0;i<100;i++)
        {
            Panel.transform.localPosition -= new Vector3(8.0f, 0.0f, 0.0f);
            yield return new WaitForSeconds(0.0001f); 
        }
    }

    IEnumerator CameraBack(GameObject Camera)
    {
        for (int i = 0; i < 100; i++)
        {
            Camera.transform.localPosition -= new Vector3(0.015f,0.0f,0.0f);
            yield return new WaitForSeconds(0.002f);
        }
    }

    IEnumerator CameraForward(GameObject Camera)
    {
        for (int i = 0; i < 100; i++)
        {
            Camera.transform.localPosition += new Vector3(0.015f, 0.0f, 0.0f);
            yield return new WaitForSeconds(0.002f);
        }
    }
}
