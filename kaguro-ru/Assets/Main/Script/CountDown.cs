using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
	[SerializeField]
	private Text _textCountdown;	//�J�E���g�_�E���̃e�L�X�g����public�Ŏ󂯎��
	[SerializeField]
	private Image _imageMask;		//Mask�ƂȂ�摜����public�Ŏ󂯎��

	SceneTransition scenetrans;     //SceneTransition�X�N���v�g�̏��i�[�ϐ�

	void Start()
	{
		_textCountdown.text = "";

		//SceneTransition�̏����擾
		scenetrans = GetComponent<SceneTransition>();
	}

	//�J�E���g�_�E�����n�܂�X�e�[�W���n�܂�
	//string Stage	�F�n�߂����X�e�[�W��
	public void StageStart(string Stage)
    {
		StartCoroutine(CountDownStart(Stage));
    }

	//�J�E���g�_�E���R���[�`��
	//string Stage	�F�n�߂����X�e�[�W��
	IEnumerator CountDownStart(string Stage)
    {
		_imageMask.gameObject.SetActive(true);
		_textCountdown.gameObject.SetActive(true);

		_textCountdown.text = "3";
		yield return new WaitForSeconds(1.0f);

		_textCountdown.text = "2";
		yield return new WaitForSeconds(1.0f);

		_textCountdown.text = "1";
		yield return new WaitForSeconds(1.0f);

		_textCountdown.text = "GO!";
		yield return new WaitForSeconds(1.0f);

		if(Stage=="Stage1")
        {
			scenetrans.StageStart1();
        }
		if(Stage=="Stage2")
        {
			scenetrans.StageStart2();
        }
		if(Stage=="Stage3")
        {
			scenetrans.StageStart3();
        }

		_textCountdown.text = "";
		_textCountdown.gameObject.SetActive(false);
		_imageMask.gameObject.SetActive(false);
	}
}
