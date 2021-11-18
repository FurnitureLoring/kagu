using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rigidbody;
    GameObject furniture;           //�Ƌ���̊i�[�ϐ�
    //GameObject pitfall;             //���Ƃ������̊i�[�ϐ�
    GameObject Goal;                //�S�[�����̊i�[�ϐ�
    //Pitfall pitfall_s;              //���Ƃ����X�N���v�g���̊i�[�ϐ�
    Result result_s;                //���U���g�X�N���v�g�̏��i�[�ϐ�

    public float distance;          //����
    float possible_distance = 1.5f; //�ߊl�\����
    public float gauge = 0;         //�ߊl�Q�[�W
    float Speed = 3.5f;//�ړ��X�s�[�h
    float CaptureSpeed = 3.0f;//�ߊl�\�������ł̃X�s�[�h
    
    //�e�X�g�p


    void Start()
    {
        //�Ƌ�̃I�u�W�F�N�g���擾
        furniture = GameObject.Find("Furniture");
        
        ////���Ƃ����̃I�u�W�F�N�g���擾�E���Ƃ����X�N���v�g�̏����擾
        //pitfall = GameObject.Find("Pitfall");
        //pitfall_s = pitfall.GetComponent<Pitfall>();
        
        //�S�[���̏����擾�E���U���g�X�N���v�g�̏����擾
        Goal = GameObject.Find("Goal");
        result_s = Goal.GetComponent<Result>();

        rigidbody = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        //�E�Ɉړ�
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * Speed * Time.deltaTime;
        }
        //���Ɉړ�
        if(Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * Speed * Time.deltaTime;
        }
        //�Ƌ���݂���Ƃ��ɓ���
        if (furniture != null)
        {
            //�Ƌ�Ƃ̋�������
            distance = Vector3.Distance(transform.position, furniture.transform.position);

            //�O���Ɉړ�
            //����������Ă���Α��x�������Ȃ�A�߂���Γ����ɂȂ�
            if (Input.GetKey(KeyCode.S))
            {
                transform.position = transform.position;
            }
            else if (distance < possible_distance)
            {
                this.rigidbody.velocity = new Vector3(0, 0, CaptureSpeed);
            }
            else
            {
                this.rigidbody.velocity = new Vector3(0, 0, Speed);
            }

            //�������ݒ肳�ꂽ�l���߂��Ƃ���
            //space�L�[����͂���ƕߊl�Q�[�W�𑝂₷
            if (Input.GetKey(KeyCode.Space))
            {
                if (distance <= possible_distance)
                {
                    //��b���Ƃ�+1�����
                    gauge += Time.deltaTime;
                }
            }
        }
    }

    //void OnTriggerEnter(Collider other)
    //{
    //    //Hole�^�O�̃I�u�W�F�N�g�ɏՓ˂�����result��true�ɂ��Ď��g���폜
    //    if (other.gameObject.CompareTag("Hole"))
    //    {
    //        result_s.result = true;
    //        //�R���|�[�l���g��OFF�ɂ���Ƃ����邩��
    //    }
    //}
}
