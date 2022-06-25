using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayController : MonoBehaviour
{
    // �{�[��
    [SerializeField]
    private Rigidbody ball;

    // �o�[
    [SerializeField]
    private Rigidbody bar;

    // �o�[�̈ړ���
    [SerializeField]
    private float barSpeed = 30f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // �X�y�[�X�L�[�����ŋʔ���
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // true �̎��������������
            ball.velocity = Vector3.up * 30;
        }

        // �o�[�̈ړ�
        var dir = Input.GetAxis("Horizontal");
        bar.velocity = dir * Vector3.right * barSpeed;
    }
}
