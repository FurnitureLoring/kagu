using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    Animator Playeranimation;//アニメーション情報格納変数

    private void Start()
    {
        //プレイヤーのアニメーション情報を取得
        Playeranimation = GetComponent<Animator>();
    }

    //左方向に移動するアニメーション
    public void AnimLeft()
    {
        Playeranimation.SetBool("left", true);
    }

    //右方向に移動するアニメーション
    public void AnimRight()
    {
        Playeranimation.SetBool("right", true);
    }

    //アイドル状態のアニメーション
    public void AnimIdle()
    {
        Playeranimation.SetBool("idle", true);
    }

    //アニメーション初期化
    public void AnimStop()
    {
        Playeranimation.SetBool("right", false);
        Playeranimation.SetBool("left", false);
        Playeranimation.SetBool("idle", false);
    }
}
