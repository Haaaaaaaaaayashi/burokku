using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayController : MonoBehaviour
{
    // �{�[��
    [SerializeField]
    private Ball ball;

    // �o�[
    [SerializeField]
    private Rigidbody bar;

    //  �u���b�N�R���g���[���[
    [SerializeField]
    private BlockControlloer blockController;

    //�{�[���̈ړ���
    [SerializeField]
    private float ballShotValue;

    // �o�[�̈ړ���
    [SerializeField]
    private float barSpeed = 30f;

    //���˃t���O
    private bool isShot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // �X�y�[�X�L�[�����ŋʔ���
        if (Input.GetKeyDown(KeyCode.Space) && isShot == false)
        {
            isShot = true;
            // true �̎��������������
            ball.SetSpeed(ballShotValue);
        }
        //R�L�[�����������Ƀ��Z�b�g
        if (Input.GetKeyDown(KeyCode.R))
        {
            //�{�[���̃��Z�b�g
            ball.OnReset();
            //�u���b�N�̃��Z�b�g
            blockController.OnReset();
        }

        // �o�[�̈ړ�
        var dir = Input.GetAxis("Horizontal");
        bar.velocity = dir * Vector3.right * barSpeed;
    }
}
