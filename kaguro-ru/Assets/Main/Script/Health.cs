using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int hp;          //��l����HP
    public bool Hit;        //�Փ˂���������p
    public float cooltime;  //�N�[���^�C��

    //�e�X�g
    GameObject[] heart = new GameObject[5]; //HP�z��
    public int downhp;                             //HP�̌�����

    void Start()
    {
        Hit = false;
        hp = 5;
        cooltime = 2.0f;

        heart[0] = GameObject.Find("Heart0");
        heart[1] = GameObject.Find("Heart1");
        heart[2] = GameObject.Find("Heart2");
        heart[3] = GameObject.Find("Heart3");
        heart[4] = GameObject.Find("Heart4");
    }

    void FixedUpdate()
    {
        //��l����HP��0�ɂȂ�ƃQ�[���I�[�o�[
        if (hp <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }    
    }

    //��Q���ɂԂ����HP������
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle")&&Hit==false)
        {
            hp--;
            downhp = 1;
            Hit = true;
            //������x������܂ł̃N�[���^�C�����J�n
            StartCoroutine(CoolTime());
        }
        if(other.gameObject.CompareTag("MoveObstacle")&&Hit==false)
        {
            hp -= 2;
            downhp = 2;
            Hit = true;
            //������x������܂ł̃N�[���^�C�����J�n
            StartCoroutine(CoolTime());
        }

        //HP��5�����Ȃ��̂�if����5�p�ӂ��Đ����̑傫�����̂����\���ɂ��Ă���
        //��Q���ɓ����������ɃJ�E���g�����₳��A���₵���J�E���g��0�ɂȂ�܂�
        //HP��UI���\���ɂ���
        if (downhp > 0)
        {
            heart[hp + downhp - 1].SetActive(false);
            downhp--;
        }
    }

    //�N�[���^�C���R���[�`��
    //������x������܂ł̎��Ԃ�2�b
    IEnumerator CoolTime()
    {
        yield return new WaitForSeconds(cooltime);
        Hit = false;
    }

    //HP��5�����Ȃ��̂�if����5�p�ӂ��Đ����̑傫�����̂����\���ɂ��Ă���
    //��Q���ɓ����������ɃJ�E���g�����₳��A���₵���J�E���g��0�ɂȂ�܂�
    //HP��UI���\���ɂ���
}
