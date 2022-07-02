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
    private Rigidbody bar;

    //  ブロックコントローラー
    [SerializeField]
    private BlockControlloer blockController;

    //ボールの移動量
    [SerializeField]
    private float ballShotValue;

    // バーの移動量
    [SerializeField]
    private float barSpeed = 30f;

    //発射フラグ
    private bool isShot;

    // Start is called before the first frame update
    void Start()
    {
        
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
            //ボールのリセット
            ball.OnReset();
            //ブロックのリセット
            blockController.OnReset();
        }

        // バーの移動
        var dir = Input.GetAxis("Horizontal");
        bar.velocity = dir * Vector3.right * barSpeed;
    }
}
