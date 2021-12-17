using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    GameObject Furniture;           //�Ƌ���̊i�[�ϐ�
    GameObject Goal;                //�S�[�����̊i�[�ϐ�
    GameObject Se;                  //SE���̊i�[�ϐ�
    GameOverBranch branch;
    Animation Playeranimation;      //�A�j���[�V�����X�N���v�g�̏��i�[�ϐ�
    public float distance;          //����
    float possible_distance = 1.0f; //�ߊl�\����
    public float gauge = 0;         //�ߊl�Q�[�W
    float Speed = 3.5f;             //�ړ��X�s�[�h
    float CaptureSpeed = 3.0f;      //�ߊl�\�������ł̃X�s�[�h
    public bool hole;               //���Ƃ������ʗp
    bool invert;                    //���씽�]�p
    bool stop;

    void Start()
    {
        //Animation�X�N���v�g�̏����擾
        Playeranimation = GetComponent<Animation>();

        Se = GameObject.Find("SE");

        //�Ƌ�̃I�u�W�F�N�g���擾
        Furniture = GameObject.Find("Furniture");

        //�S�[���̏����擾�E���U���g�X�N���v�g�̏����擾
        //Goal = GameObject.Find("Goal");
        //result_s = Goal.GetComponent<Result>();

        branch = GameObject.Find("StageName").GetComponent<GameOverBranch>();

        hole = false;

        invert = false;

        stop = false;
    }

    void FixedUpdate()
    {
        invert = false;

        //�A�j���[�V����������
        Playeranimation.AnimStop();

        //�Ƌ���݂���Ƃ��ƁA���Ƃ����̏�ɂ��Ȃ��Ƃ��ɓ���
        if (Furniture != null && hole==false)
        {
            //�O�����ɂȂ�
            transform.rotation = Quaternion.Euler(0, 0, 0);

            //�Ƌ�Ƃ̋�������
            distance = Vector3.Distance(transform.position, Furniture.transform.position);

            //���̏�ɒ�~
            if (Input.GetKey(KeyCode.Space))
            {
                invert = true;

                //�������ɂȂ�
                transform.rotation = Quaternion.Euler(0, 180, 0);

                transform.position = transform.position;

                //�A�j���[�V����������
                Playeranimation.AnimIdle();

                //�������ݒ肳�ꂽ�l���߂��āA
                //�v���C���[��Z���W���Ƌ��Z���W���傫���Ƃ��ɁA
                //�ߊl�Q�[�W�𑝂₷
                if (distance <= possible_distance && transform.position.z >= Furniture.transform.position.z)
                {
                    //��b���Ƃ�+1�����
                    gauge += Time.deltaTime;
                    
                    //�󂯎~�߂�����SE����x�����Đ�
                    if(stop==false)
                    {
                        Se.GetComponent<SE>().StartSE_Stop();
                        stop = true;
                    }
                }
                else
                {
                    stop = false;
                }
            }            
            //�O���Ɉړ�
            //����������Ă���Α��x�������Ȃ�A�߂���Γ����ɂȂ�
            else if (distance < possible_distance && invert==false)
            {
                transform.position += transform.forward * CaptureSpeed * Time.deltaTime;
            }
            else if(invert==false)
            {
                transform.position += transform.forward * Speed * Time.deltaTime;
            }

            if (invert == false)
            {
                //�E�Ɉړ�
                if (Input.GetKey(KeyCode.D))
                {
                    transform.position += transform.right * Speed * Time.deltaTime;

                    //�A�j���[�V����������
                    Playeranimation.AnimRight();
                }
                //���Ɉړ�
                if (Input.GetKey(KeyCode.A))
                {
                    transform.position -= transform.right * Speed * Time.deltaTime;

                    //�A�j���[�V����������
                    Playeranimation.AnimLeft();
                }
            }
            else
            {
                //�E�Ɉړ�
                if (Input.GetKey(KeyCode.A))
                {
                    transform.position += transform.right * Speed * Time.deltaTime * 0.1f;
                }
                //���Ɉړ�
                if (Input.GetKey(KeyCode.D))
                {
                    transform.position -= transform.right * Speed * Time.deltaTime * 0.1f;
                }
            }
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
            //����������SE
            Se.GetComponent<SE>().StartSE_Fall();

            //�n�ʂ����蔲��������
            this.GetComponent<BoxCollider>().isTrigger = true;
            hole = true;

            branch.Hole = true;

            Playeranimation.AnimFall();

            //GameOver�Ɉړ����邽�߂̃R���[�`��
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
