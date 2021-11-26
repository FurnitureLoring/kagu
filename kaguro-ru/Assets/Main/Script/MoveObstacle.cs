using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    private float time;//�����o���܂ł̎��ԊԊu

    void Update()
    {
        //�����܂ł̎��ԊԊu������
        time -= Time.deltaTime;

        if (time <= 0)
        {
            //�R���[�`���J�n
            StartCoroutine(Move());
            
            //�Ăѓ����o���܂ł̎��ԊԊu��ݒ�
            time = Random.Range(0.0f, 10.0f);
        }
    }

    //���Ɉړ����Ă܂������ʒu�ɖ߂��Ă���
    IEnumerator Move()
    {
        for (int i = 0; i < 120; i++)
        {
            transform.Translate(0.1f, 0, 0);
            yield return new WaitForSeconds(0.05f);
        }

        for (int i = 0; i < 120; i++)
        {
            transform.Translate(-0.1f, 0, 0);
            yield return new WaitForSeconds(0.05f);
        }
    }
}
