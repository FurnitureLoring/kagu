using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour
{
    public Transform Furniturepos;  //�Ƌ�摜�̈ʒu�������邽�߂̏��i�[�ϐ�
    public Transform Humanpos;      //�l�ԉ摜�̈ʒu�������邽�߂̏��i�[�ϐ�
    public RectTransform Rotatepos; //��]���邽�߂̈ʒu�������邽�߂̏��i�[�ϐ�
    public bool StartTitle;         //�����Ă��邩����
    public float time;              //�����܂ł̎��ԊԊu

    void Update()
    {
        //���Ԍ���
        time -= Time.deltaTime;

        //���ԊԊu��0�ȉ��Ȃ瓮��
        if (time <= 0)
        {
            if (!StartTitle)
            {
                StartTitle = true;
                //�摜����ʂ̍��[�ɔz�u����
                Furniturepos.position = new Vector3(-100.0f, 90.0f, 0.0f);
                Humanpos.position = new Vector3(-300.0f, 100.0f, 0.0f);

                //FurnitureAnimation�R���[�`���𓮂���
                StartCoroutine(FurnitureAnimation());
                //HumanAnimation�R���[�`���𓮂���
                StartCoroutine(HumanAnimation());
            }
            //���ԊԊu�Đݒ�
            time = 3.0f;
        }

    }

    //FurnitureAnimation�R���[�`��
    IEnumerator FurnitureAnimation()
    {
        for (int i = 0; i < 1000; i++)
        {
            //���[����E�[�Ɉړ�����
            Furniturepos.Translate(1.0f, 0.0f, 0.0f);
            //�摜����]������
            Rotatepos.Rotate(0.0f, 0.0f, -1.0f);
            
            yield return new WaitForSeconds(0.01f);
        }
    }

    //HumanAnimation�̃R���[�`��
    IEnumerator HumanAnimation()
    {
        for(int i = 0; i < 1000; i++)
        {
            //���[����E�[�Ɉړ�����
            Humanpos.Translate(-1.0f, 0.0f, 0.0f);

            yield return new WaitForSeconds(0.01f); 
        }

        StartTitle = false;
    }
}
