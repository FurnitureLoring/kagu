using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageName : MonoBehaviour
{
    public string Stage;    //�X�e�[�W��������ϐ�

    void Start()
    {
        //�V�[�����ړ����Ă��j�󂳂�Ȃ��悤�ɂ���
        DontDestroyOnLoad(this);
        //Scene�����擾
        Stage = SceneManager.GetActiveScene().name;

    }
}
