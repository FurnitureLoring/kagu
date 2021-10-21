using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 pos;
    GameObject furniture;//�Ƌ�
    private float distance;//����

    //�e�X�g�p
    public float Speed = 4.0f;//�ړ��X�s�[�h
    public float gauge_test = 0;//�ߊl�Q�[�W
    public float distance_test = 1.5f;//�ߊl�\����

    void Start()
    {
        //�Ƌ�̃I�u�W�F�N�g��T���Ď擾
        furniture = GameObject.Find("furniture");
    }

    // Update is called once per frame
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
        //�O�Ɉړ�
        if(Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * Speed * Time.deltaTime;
        }

        //�Ƌ�Ƃ̋������ݒ肳�ꂽ�l���Z���Ƃ��ߊl�Q�[�W�𑝂₷
        if (Input.GetKey(KeyCode.Space))
        {

            distance = Vector3.Distance(transform.position, furniture.transform.position);
            if (distance < distance_test)
            {
                //��b���Ƃ�+1�����
                gauge_test += Time.deltaTime;
            }
        }

    }
}
