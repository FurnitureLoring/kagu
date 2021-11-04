using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rigidbody;
    GameObject furniture;           //�Ƌ���̊i�[�ϐ�
    GameObject pitfall;             //���Ƃ������̊i�[�ϐ�
    GameObject Goal;                //�S�[�����̊i�[�ϐ�
    Pitfall pitfall_s;              //���Ƃ����X�N���v�g���̊i�[�ϐ�
    Result result_s;                //���U���g�X�N���v�g�̏��i�[�ϐ�
    public float distance;          //����
    float possible_distance = 1.5f; //�ߊl�\����
    public float gauge = 0;         //�ߊl�Q�[�W

    //�e�X�g�p
    public float Speed = 2.0f;//�ړ��X�s�[�h
    public float pitfall_time = 0;//���Ƃ����؍ݎ���
    public float x = 0;//���Ƃ����ɗ����Ă�������

    void Start()
    {
        //�Ƌ�̃I�u�W�F�N�g���擾
        furniture = GameObject.Find("Furniture");
        
        //���Ƃ����̃I�u�W�F�N�g���擾�E���Ƃ����X�N���v�g�̏����擾
        pitfall = GameObject.Find("Pitfall");
        pitfall_s = pitfall.GetComponent<Pitfall>();
        
        //�S�[���̏����擾�E���U���g�X�N���v�g�̏����擾
        Goal = GameObject.Find("Goal");
        result_s = Goal.GetComponent<Result>();

        rigidbody = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (pitfall!=null)
        {
            pitfall_time = pitfall_s.pitfall_time;

            //���̂Ƃ���e�X�g��3�b�ȏ㗎�Ƃ����̏�ɂ���Ɨ�����
            if(pitfall_time >= 2.0f)
            {
                while (true)
                {
                    transform.position += new Vector3(0, -x, 0);
                    x += Time.deltaTime;
                    if (x > 0.1f)
                    {
                        break;
                    }
                }
                result_s.result = true;
                Destroy(this.gameObject);
            }
        }


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
            if (distance < possible_distance)
            {
                this.rigidbody.velocity = new Vector3(0, 0, 0.1f);
            }
            else
            {
                this.rigidbody.velocity = new Vector3(0, 0, 1.5f);
            }

            //�������ݒ肳�ꂽ�l���߂��Ƃ���
            //space�L�[����͂���ƕߊl�Q�[�W�𑝂₷
            if (Input.GetKey(KeyCode.Space))
            {
                if (distance < possible_distance)
                {
                    //��b���Ƃ�+1�����
                    gauge += Time.deltaTime;
                }
            }
        }
    }
}
