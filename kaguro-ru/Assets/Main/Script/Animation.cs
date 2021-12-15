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

    //�������Ɉړ�����t���O��ݒ�
    public void AnimLeft()
    {
        Playeranimation.SetBool("left", true);
    }

    //�E�����Ɉړ�����t���O��ݒ�
    public void AnimRight()
    {
        Playeranimation.SetBool("right", true);
    }

    //�A�C�h����Ԃ̃t���O��ݒ�
    public void AnimIdle()
    {
        Playeranimation.SetBool("idle", true);
    }

    //�������Ԃ̃t���O��ݒ�
    public void AnimFall()
    {
        Playeranimation.SetBool("fall", true);
    }

    //�_���[�W���󂯂���Ԃ̃t���O��ݒ�
    public void AnimDamage()
    {
        Playeranimation.SetBool("damage", true);
    }

    //�A�j���[�V�����t���O������
    public void AnimStop()
    {
        Playeranimation.SetBool("right", false);
        Playeranimation.SetBool("left", false);
        Playeranimation.SetBool("idle", false);
        Playeranimation.SetBool("damage", false);

    }
}
