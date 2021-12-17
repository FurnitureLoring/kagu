using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour
{
    private float Speed = 3.5f;             //�ړ��X�s�[�h

    void FixedUpdate()
    {
        //�O�ɐi��
        transform.position += transform.forward * Speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Goal�ɓ�����Ə����ʒu�ɖ߂�
        if(other.gameObject.CompareTag("Goal"))
        {
            transform.position = new Vector3(0.0f, 0.0f, 14.0f);
        }
    }
}
