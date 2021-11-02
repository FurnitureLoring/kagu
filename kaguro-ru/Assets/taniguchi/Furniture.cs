using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Furniture : MonoBehaviour
{
    GameObject Player;
    public Transform goal;
    private NavMeshAgent agent;
    Rigidbody rigidbody;
    Player script;
    private float Gauge;
    public bool result;

    //�e�X�g�p
    public float Speed = 2.0f;//�ړ��X�s�[�h
    private float Gauge_MAX = 10;//�ߊl�Q�[�W

    void Start()
    {
        //�v���C���[�̏���T���Ď擾
        Player = GameObject.Find("Player");
        script = Player.GetComponent<Player>();
        rigidbody = this.GetComponent<Rigidbody>();

        agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
    }

    void Update()
    {
        //�v���C���[����ߊl�Q�[�W���擾
        Gauge = script.gauge_test;

        //�O���Ɉړ�
        this.rigidbody.velocity = new Vector3(0, 0, 1f);

        //�ߊl�Q�[�W���ݒ肳�ꂽ�l�𒴂���Ǝ��g���폜
        if (Gauge > Gauge_MAX)
        {
            result = false;
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Goal"))
        {
            result = true;
            Destroy(this.gameObject);
        }
    }
}
