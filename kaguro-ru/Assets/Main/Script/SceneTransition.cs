using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{

    //�X�e�[�W�Z���N�g��ʂɈړ�
    public void StageSelect()
    {
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

}
