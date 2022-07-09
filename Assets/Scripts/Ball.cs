using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //自分自身
    [SerializeField]
    private Rigidbody body;

    //初期位置
    private Vector3 initPos;

    //最高速度
    private float maxSpeed;

    //ボールがリセットされる
    //エリアに来た際に呼ばれる関数（デリゲート）
    public System.Action TriggerBall;


    /// <summary>
    /// 初期化
    /// ・ボールの初期位置
    /// ・ボールの最高速度の設定など
    /// </summary>

    public void OnInit(float speed)
    {
        initPos = transform.localPosition;
    }

    /// <summary>
    /// リセット
    /// ・ボールを初期位置に移動させる
    /// ・ボールの速度を０にするなど
    /// </summary>

    public void OnReset()
    {
        transform.localPosition = initPos;
        body.velocity = Vector3.zero;
    }
    
    /// <summary>
    /// ボールの移動量をセットする
    /// </summary>

    public void SetSpeed(float speed)
    {
        // 左右斜め(上)方向を取得
        var dir = Vector3.zero;
        dir.x = Random.Range(-0.5f, 0.5f);
        dir.y = 1f;
        dir.Normalize();

        body.velocity = dir * speed;
    }




    private void OnCollisionEnter(Collision collision)
    {
        //衝突したオブジェクトを取得
        var obj = collision?.gameObject;

        //　衝突したオブジェクトのタグが特定のものであれば、
        //各自処理をする
        if (obj != null && obj.tag == "Block")
        {
            //オブジェクトを削除
            //Destroy(obj); //コスト高

            //オブジェクトをヒエラルキー上から消す
            //編集できない/見えないようにする
            obj.SetActive(false); //コスト低
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //衝突したオブジェクトを取得
        var obj = other?.gameObject;

        //衝突したオブジェクトのタグが特定のものであれば、
        //各自処理をする
        if(obj != null && obj.tag == "Reset")
        {
            //ボールのみをリセット
            OnReset();

            //この変数に要録された関数を呼び出す
            TriggerBall?.Invoke();          
        }
    }
}

