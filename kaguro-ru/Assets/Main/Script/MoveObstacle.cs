using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    private float time;     //�����o���܂ł̎��ԊԊu
    private bool isMove;    //�����Ă��邩�𔻕�

    void FixedUpdate()
    {
        //�����܂ł̎��ԊԊu������
        time -= Time.deltaTime;

        if (time <= 0)
        {
            if (!isMove)
            {
                //�t���O��true�ɂ���
                isMove = true;
                //�R���[�`���𓮂���
                StartCoroutine(Move());
            }
            //�Ăѓ����o���܂ł̎��ԊԊu��ݒ�
            time = Random.Range(0.0f, 10.0f);
        }
    }

    //�ړ��R���[�`��
    IEnumerator Move()
    {
        for (int i = 0; i < 200; i++)
        {
            transform.Translate(0, 0, 0.1f);
            yield return new WaitForSeconds(0.05f);
        }

        //180����]
        transform.Rotate(0, -180.0f, 0);

        for (int i = 0; i < 200; i++)
        {
            transform.Translate(0, 0, 0.1f);
            yield return new WaitForSeconds(0.05f);
        }
        //�t���O��false�ɂ���
        isMove = false;

        //180����]
        transform.Rotate(0, 180.0f, 0);
    }
}
