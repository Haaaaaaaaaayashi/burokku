using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayController : MonoBehaviour
{
    // ボール
    [SerializeField]
    private Rigidbody ball;

    // バー
    [SerializeField]
    private Rigidbody bar;

    // バーの移動量
    [SerializeField]
    private float barSpeed = 30f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // スペースキー押下で玉発射
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // true の時だけ処理される
            ball.velocity = Vector3.up * 30;
        }

        // バーの移動
        var dir = Input.GetAxis("Horizontal");
        bar.velocity = dir * Vector3.right * barSpeed;
    }
}
