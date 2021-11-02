using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 pos;
    Rigidbody rigidbody; 
    GameObject furniture;//�Ƌ�
    private float distance;//����
    private float time_interval;//

    //�e�X�g�p
    public float Speed = 2.0f;//�ړ��X�s�[�h
    public float gauge_test = 0;//�ߊl�Q�[�W
    public float distance_test = 1.0f;//�ߊl�\����

    void Start()
    {
        //�Ƌ�̃I�u�W�F�N�g��T���Ď擾
        furniture = GameObject.Find("furniture");
        rigidbody = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        pos = transform.position;

        //�E�Ɉړ�
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * Speed * Time.deltaTime;
            pos = transform.position;
        }
        //���Ɉړ�
        if(Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * Speed * Time.deltaTime;
            pos = transform.position;
        }
        //�Ƌ���݂���Ƃ��ɓ���
        if (furniture != null)
        {
            //�Ƌ�Ƃ̋���
            distance = Vector3.Distance(transform.position, furniture.transform.position);
          
            //�O���Ɉړ�
            //����������Ă���Α��x�������Ȃ�A�߂���Γ����ɂȂ�
            if (distance < distance_test)
            {
                this.rigidbody.velocity = new Vector3(0, 0, 1f);
            }
            else
            {
                this.rigidbody.velocity = new Vector3(0, 0, 1.5f);
            }

            //�������ݒ肳�ꂽ�l���߂��Ƃ��ߊl�Q�[�W�𑝂₷
            if (Input.GetKey(KeyCode.Space))
            {
                if (distance < distance_test)
                {
                    //��b���Ƃ�+1�����
                    gauge_test += Time.deltaTime;
                }
            }
        }
    }
}
