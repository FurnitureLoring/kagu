using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Furniture : MonoBehaviour
{
    GameObject Player;              //�v���C���[���̊i�[�ϐ�
    GameObject Goal;                //�S�[�����̊i�[�ϐ�
    public Transform goal;          //�i�r�Q�[�V�����V�X�e���̃S�[�������i�[
    private NavMeshAgent agent;     //�i�r�Q�[�V�����V�X�e��
    Result result_s;                //���U���g�X�N���v�g�̏��i�[�ϐ�
    Player player_s;                //�v���C���[�X�N���v�g�̏��i�[�ϐ�
    private float Gauge;            //�ߊl�Q�[�W
    private float Gauge_MAX = 10;   //�ߊl�Q�[�WMAX
    float Speed = 2.5f;             //�ړ��X�s�[�h
    public Slider slider;           //slider������
    const int pathMax = 9;                      //�p�X�̍ő�o�^��
    Vector3[] positions = new Vector3[pathMax]; //���W���X�g
    int position = 0;

    //�e�X�g�p

    IEnumerator Start()
    {
        //�v���C���[�̏����擾�E�v���C���[�X�N���v�g�̏����擾
        Player = GameObject.Find("Player");
        player_s = Player.GetComponent<Player>();

        //�S�[���̏����擾�E���U���g�X�N���v�g�̏����擾
        Goal = GameObject.Find("Goal");
        result_s = Goal.GetComponent<Result>();

        //�i�r�Q�[�V�����V�X�e��
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(goal.position);
        yield return new WaitWhile(() => agent.pathStatus != NavMeshPathStatus.PathComplete);
        agent.path.GetCornersNonAlloc(positions);

        //�X���C�_�[�̕ߊl�Q�[�W��0�ɂ���
        slider.value = 0;
    }

    void FixedUpdate()
    {
        //�v���C���[����ߊl�Q�[�W���擾
        Gauge = player_s.gauge;

        //�X���C�_�[�Ɍ��݂̕ߊl�Q�[�W������
        slider.value = Gauge / Gauge_MAX;

        //��Q��������Ȃ���O���Ɉړ�
        var tragetPosition = positions[position];
        if (Vector3.Distance(transform.position, tragetPosition) < 0.2f)
        {
            position = position + 1 < positions.Length ? position + 1 : position;
        }
        transform.localPosition = Vector3.MoveTowards(transform.position, tragetPosition, Speed * Time.deltaTime);

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
