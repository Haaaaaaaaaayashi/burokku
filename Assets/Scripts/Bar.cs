using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{

    //自分自身
    [SerializeField]
    private Rigidbody body;

    //初期位置
    private Vector3 initPos;

    /// <summary>
    /// 初期化
    /// ・バーの初期位置
    /// </summary>

    public void OnInit()
    {
        initPos = transform.localPosition;
    }

    /// <summary>
    /// リセット
    /// ・バーを初期位置に移動させる
    /// ・バーの速度を０にするなど
    /// </summary>

    public void OnReset()
    {
        transform.localPosition = initPos;
        body.velocity = Vector3.zero;
    }


    public void Onmove(float speed)
    {
        //バーを移動させる
        var dir = Input.GetAxis("Horizontal");
        body.velocity = dir * Vector3.right * speed;
    }
}