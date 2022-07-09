using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayController : MonoBehaviour
{
    // ボール
    [SerializeField]
    private Ball ball;

    // バー
    [SerializeField]
    private Bar bar;

    //  ブロックコントローラー
    [SerializeField]
    private BlockControlloer blockController;

    //ボールの移動量
    [SerializeField]
    private float ballShotValue;

    // バーの移動量
    [SerializeField]
    private float barMoveValue;

    //発射フラグ
    private bool isShot;

    // Start is called before the first frame update
    void Start()
    {
        //ボールの初期化
        ball.OnInit(barMoveValue);

        //ボールがリセットされる
        //エリアに衝突した際に呼ばれる関数を登録
        ball.TriggerBall += TriggerBall;

        //バーの初期化
        bar.OnInit();

        
    }

    // Update is called once per frame
    void Update()
    {
        // スペースキー押下で玉発射
        if (Input.GetKeyDown(KeyCode.Space) && isShot == false)
        {
            isShot = true;
            // true の時だけ処理される
            ball.SetSpeed(ballShotValue);
        }
        //Rキーを押した時にリセット
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetGame();
        }
      
        // バーの移動
        bar.Onmove(barMoveValue);
    }
    /// <summary>
    /// ゲームのリセット
    /// ・ボールのリセット
    /// ・ブロックのリセット
    /// </summary>
    private void ResetGame()
    {
        //ボールを発射できるようにする
        isShot = false;

        //ボールのリセット
        ball.OnReset();

        //バーのリセット
        bar.OnReset();

        // ブロックのリセット
        blockController.OnReset();
    }
    private void TriggerBall()
    {
        ResetGame();
    }
}
