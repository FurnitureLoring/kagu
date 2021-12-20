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

	SceneTransition scenetrans;     //SceneTransitionスクリプトの情報格納変数

	void Start()
	{
		_textCountdown.text = "";

		//SceneTransitionの情報を取得
		scenetrans = GetComponent<SceneTransition>();
	}

	//カウントダウンが始まりステージが始まる
	//string Stage	：始めたいステージ名
	public void StageStart(string Stage)
    {
		StartCoroutine(CountDownStart(Stage));
    }

	//カウントダウンコルーチン
	//string Stage	：始めたいステージ名
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
