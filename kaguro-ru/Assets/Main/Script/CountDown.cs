using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
	[SerializeField]
	private Text _textCountdown;	//カウントダウンのテキスト情報をpublicで受け取る
	[SerializeField]
	private Image _imageMask;		//Maskとなる画像情報をpublicで受け取る

	SceneTransition scenetrans;		//SceneTransitionスクリプトの情報格納変数

	void Start()
	{
		_textCountdown.text = "";

		//SceneTransitionの情報を取得
		scenetrans = GetComponent<SceneTransition>();
	}

	public void Stage1()
	{
		StartCoroutine(CountdownCoroutine1());
	}

	public void Stage2()
    {
		StartCoroutine(CountdownCoroutine2());
	}

	public void Stage3()
	{
		StartCoroutine(CountdownCoroutine3());
	}

	IEnumerator CountdownCoroutine()
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

        if ("Stage1" == GameObject.Find("Stage1").name)
        {
			scenetrans.StageStart1();
        }
        if ("Stage2" == GameObject.Find("Stage2").name)
        {
			scenetrans.StageStart2();
        }
		if ("Stage3" == GameObject.Find("Stage3").name)
		{
			scenetrans.StageStart3();
		}

		_textCountdown.text = "";
		_textCountdown.gameObject.SetActive(false);
		_imageMask.gameObject.SetActive(false);
	}

	IEnumerator CountdownCoroutine1()
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

		scenetrans.StageStart1();

		_textCountdown.text = "";
		_textCountdown.gameObject.SetActive(false);
		_imageMask.gameObject.SetActive(false);
	}

	IEnumerator CountdownCoroutine2()
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

		scenetrans.StageStart2();

		_textCountdown.text = "";
		_textCountdown.gameObject.SetActive(false);
		_imageMask.gameObject.SetActive(false);
	}

	IEnumerator CountdownCoroutine3()
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

		scenetrans.StageStart3();

		_textCountdown.text = "";
		_textCountdown.gameObject.SetActive(false);
		_imageMask.gameObject.SetActive(false);
	}
}
