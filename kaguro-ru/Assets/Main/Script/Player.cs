using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    GameObject furniture;           //�Ƌ���̊i�[�ϐ�
    GameObject Goal;                //�S�[�����̊i�[�ϐ�
    Result result_s;                //���U���g�X�N���v�g�̏��i�[�ϐ�
    Animator Playeranimation;
    public float distance;          //����
    float possible_distance = 1.5f; //�ߊl�\����
    public float gauge = 0;         //�ߊl�Q�[�W
    float Speed = 3.5f;             //�ړ��X�s�[�h
    float CaptureSpeed = 3.0f;      //�ߊl�\�������ł̃X�s�[�h
    bool hole;                      //���Ƃ������ʗp

    //�e�X�g�p
    public bool left;  //true�Ȃ��l�������Ɉړ�
    public bool right; //true�Ȃ��l�����E�Ɉړ�


    void Start()
    {
        //�Ƌ�̃I�u�W�F�N�g���擾
        furniture = GameObject.Find("Furniture");
               
        //�S�[���̏����擾�E���U���g�X�N���v�g�̏����擾
        Goal = GameObject.Find("Goal");
        result_s = Goal.GetComponent<Result>();

        hole = false;


        left = false;
        right = false;
    }

    void FixedUpdate()
    {
        //�E�Ɉړ�
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * Speed * Time.deltaTime;
            right = true;
        }
        //���Ɉړ�
        if(Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * Speed * Time.deltaTime;
            left = true;
        }
        //�Ƌ���݂���Ƃ��ƁA���Ƃ����̏�ɂ��Ȃ��Ƃ��ɓ���
        if (furniture != null && hole==false)
        {
            //�Ƌ�Ƃ̋�������
            distance = Vector3.Distance(transform.position, furniture.transform.position);

            transform.rotation = Quaternion.Euler(0, 0, 0);

            //���̏�ɒ�~
            if (Input.GetKey(KeyCode.S))
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);

                transform.position = transform.position;

                //�������ݒ肳�ꂽ�l���߂��āA
                //�v���C���[��Z���W���Ƌ��Z���W���傫���Ƃ��ɁA
                //�ߊl�Q�[�W�𑝂₷
                if (distance <= possible_distance && transform.position.z >= furniture.transform.position.z)
                {
                    //��b���Ƃ�+1�����
                    gauge += Time.deltaTime;
                }
            }
            //�O���Ɉړ�
            //����������Ă���Α��x�������Ȃ�A�߂���Γ����ɂȂ�
            else if (distance < possible_distance)
            {
                transform.position += transform.forward * CaptureSpeed * Time.deltaTime;
            }
            else
            {
                transform.position += transform.forward * Speed * Time.deltaTime;
            }

            ////�������ݒ肳�ꂽ�l���߂��āA
            ////�v���C���[��Z���W���Ƌ��Z���W���傫���Ƃ��ɁA
            ////space�L�[����͂���ƕߊl�Q�[�W�𑝂₷
            //if (Input.GetKey(KeyCode.Space))
            //{
            //}
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //Goal�^�O�̃I�u�W�F�N�g�ɏՓ˂�����result��true�ɂ��Ď��g���폜
        if (other.gameObject.CompareTag("Goal"))
        {
            SceneManager.LoadScene("GameOver");
        }
        //Hole�^�O�̃I�u�W�F�N�g�ɏՓ˂�����n�ʂ̉��ɗ�����
        if (other.gameObject.CompareTag("Hole"))
        {
            this.GetComponent<BoxCollider>().isTrigger = true;
            hole = true;
            StartCoroutine(GameOverWait());
        }
    }

    //GameOver�V�[���Ɉړ�����R���[�`��
    IEnumerator GameOverWait()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("GameOver");
    }
}
