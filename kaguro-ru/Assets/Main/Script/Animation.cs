using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    Animator Playeranimation;//�A�j���[�V�������i�[�ϐ�

    private void Start()
    {
        //�v���C���[�̃A�j���[�V���������擾
        Playeranimation = GetComponent<Animator>();
    }

    //�������Ɉړ�����A�j���[�V����
    public void AnimLeft()
    {
        Playeranimation.SetBool("left", true);
    }

    //�E�����Ɉړ�����A�j���[�V����
    public void AnimRight()
    {
        Playeranimation.SetBool("right", true);
    }

    //�A�C�h����Ԃ̃A�j���[�V����
    public void AnimIdle()
    {
        Playeranimation.SetBool("idle", true);
    }

    //�A�j���[�V����������
    public void AnimStop()
    {
        Playeranimation.SetBool("right", false);
        Playeranimation.SetBool("left", false);
        Playeranimation.SetBool("idle", false);
    }
}
