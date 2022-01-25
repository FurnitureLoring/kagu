using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    GameObject StageName;   //StageName���̊i�[�ϐ�
    StageName StageName_s;  //StageName�X�N���v�g�̏��i�[�ϐ�
    private string Stage;   //�X�e�[�W��������ϐ�

    void Start()
    {
        //StageName�I�u�W�F�N�g�̏����擾
        StageName = GameObject.Find("StageName");
        if (StageName != null)
        {
            //StageName�X�N���v�g�̏����擾
            StageName_s = StageName.GetComponent<StageName>();
            //�X�e�[�W�����擾
            Stage = StageName_s.Stage;
        }
    }

    //�X�e�[�W�Z���N�g��ʂɈړ�
    public void StageSelect()
    {
        Destroy(StageName);
        SceneManager.LoadScene("StageSelect");
    }

    //�^�C�g����ʂɈړ�
    public void Title()
    {
        SceneManager.LoadScene("Title");
    }

    //�X�e�[�W1�Ɉړ�
    public void StageStart1()
    {
        SceneManager.LoadScene("Stage1");
    }

    //�X�e�[�W2�Ɉړ�
    public void StageStart2()
    {
        SceneManager.LoadScene("Stage2");
    }

    //�X�e�[�W3�Ɉړ�
    public void StageStart3()
    {
        SceneManager.LoadScene("Stage3");
    }

    //�X�e�[�W4�Ɉړ�
    public void StageStart4()
    {
        SceneManager.LoadScene("Stage4");
    }

    //�X�e�[�W5�Ɉړ�
    public void StageStart5()
    {
        SceneManager.LoadScene("Stage5");
    }

    //�X�e�[�W6�Ɉړ�
    public void StageStart6()
    {
        SceneManager.LoadScene("Stage6");
    }


    //���g���C�@�\
    public void Retry()
    {
        switch (Stage)
        {
            case "Stage1":  //�X�e�[�W�P
                SceneManager.LoadScene("Stage1");
                Destroy(StageName); //�I�u�W�F�N�g��j��
                break;
            case "Stage2":  //�X�e�[�W�Q
                SceneManager.LoadScene("Stage2");
                Destroy(StageName); //�I�u�W�F�N�g��j��
                break;
            case "Stage3":  //�X�e�[�W�R
                SceneManager.LoadScene("Stage3");
                Destroy(StageName); //�I�u�W�F�N�g��j��
                break;
            case "Stage4":  //�X�e�[�W�S
                SceneManager.LoadScene("Stage4");
                Destroy(StageName); //�I�u�W�F�N�g��j��
                break;
            case "Stage5":  //�X�e�[�W�T
                SceneManager.LoadScene("Stage5");
                Destroy(StageName); //�I�u�W�F�N�g��j��
                break;
            case "Stage6":  //�X�e�[�W�U
                SceneManager.LoadScene("Stage6");
                Destroy(StageName); //�I�u�W�F�N�g��j��
                break;
        }
    }

}
