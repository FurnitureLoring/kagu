using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Furniture : MonoBehaviour
{
    GameObject Player;              //�v���C���[���̊i�[�ϐ�
    GameObject Goal;                //�S�[�����̊i�[�ϐ�
    public Transform goal;          //�i�r�Q�[�V�����V�X�e���̃S�[�������i�[
    private NavMeshAgent agent;     //�i�r�Q�[�V�����V�X�e��
    Rigidbody rigidbody;
    Result result_s;                //���U���g�X�N���v�g�̏��i�[�ϐ�
    Player player_s;                //�v���C���[�X�N���v�g�̏��i�[�ϐ�
    private float Gauge;            //�ߊl�Q�[�W
    private float Gauge_MAX = 10;   //�ߊl�Q�[�WMAX

    //�e�X�g�p
    public float Speed = 2.0f;//�ړ��X�s�[�h

    void Start()
    {
        //�v���C���[�̏����擾�E�v���C���[�X�N���v�g�̏����擾
        Player = GameObject.Find("Player");
        player_s = Player.GetComponent<Player>();

        //�S�[���̏����擾�E���U���g�X�N���v�g�̏����擾
        Goal = GameObject.Find("Goal");
        result_s = Goal.GetComponent<Result>();

        rigidbody = this.GetComponent<Rigidbody>();

        //�i�r�Q�[�V�����V�X�e��
        agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
    }

    void Update()
    {
        //�v���C���[����ߊl�Q�[�W���擾
        Gauge = player_s.gauge;

        //�O���Ɉړ�
        this.rigidbody.velocity = new Vector3(0, 0, 1f);

        //�ߊl�Q�[�W���ݒ肳�ꂽ�l�𒴂����result��false�ɂ��Ď��g���폜
        if (Gauge > Gauge_MAX)
        {
            result_s.result = false;
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //Goal�^�O�̃I�u�W�F�N�g�ɏՓ˂�����result��true�ɂ��Ď��g���폜
        if (other.gameObject.CompareTag("Goal"))
        {
            result_s.result = true;
            Destroy(this.gameObject);
        }
    }
}
