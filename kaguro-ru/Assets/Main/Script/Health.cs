using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int hp;          //��l����HP
    public bool Hit;        //�Փ˂���������p
    public float cooltime;  //�N�[���^�C��

    void Start()
    {
        Hit = false;
        hp = 5;
        cooltime = 2.0f;
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
            Hit = true;
            //������x������܂ł̃N�[���^�C�����J�n
            StartCoroutine(CoolTime());
        }
        if(other.gameObject.CompareTag("MoveObstacle")&&Hit==false)
        {
            hp -= 3;
            Hit = true;
            //������x������܂ł̃N�[���^�C�����J�n
            StartCoroutine(CoolTime());
        }
    }

    //�N�[���^�C���R���[�`��
    //������x������܂ł̎��Ԃ�2�b
    IEnumerator CoolTime()
    {
        yield return new WaitForSeconds(cooltime);
        Hit = false;
    }


}
