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
    Result result;                  //���U���g�X�N���v�g�̏��i�[�ϐ�
    Player player;                  //�v���C���[�X�N���v�g�̏��i�[�ϐ�
    private float Gauge;            //�ߊl�Q�[�W
    private float Gauge_MAX = 10;   //�ߊl�Q�[�WMAX

    //�e�X�g�p
    public float Speed = 2.0f;//�ړ��X�s�[�h

    void Start()
    {
        //�v���C���[�̏���T���Ď擾
        Player = GameObject.Find("Player");
        player = Player.GetComponent<Player>();
        rigidbody = this.GetComponent<Rigidbody>();

        //�S�[���̏���T���Ď擾
        Goal = GameObject.Find("Goal");
        result = Goal.GetComponent<Result>();

        //�i�r�Q�[�V�����V�X�e��
        agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
    }

    void Update()
    {
        //�v���C���[����ߊl�Q�[�W���擾
        Gauge = player.gauge;

        //�O���Ɉړ�
        this.rigidbody.velocity = new Vector3(0, 0, 1f);

        //�ߊl�Q�[�W���ݒ肳�ꂽ�l�𒴂����result��false�ɂ��Ď��g���폜
        if (Gauge > Gauge_MAX)
        {
            result.result = false;
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //Goal�^�O�̃I�u�W�F�N�g�ɏՓ˂�����result��true�ɂ��Ď��g���폜
        if (other.gameObject.CompareTag("Goal"))
        {
            result.result = true;
            Destroy(this.gameObject);
        }
    }
}
