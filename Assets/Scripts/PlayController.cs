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
    private Bar bar;

    //  �u���b�N�R���g���[���[
    [SerializeField]
    private BlockControlloer blockController;

    //�{�[���̈ړ���
    [SerializeField]
    private float ballShotValue;

    // �o�[�̈ړ���
    [SerializeField]
    private float barMoveValue;

    //���˃t���O
    private bool isShot;

    // Start is called before the first frame update
    void Start()
    {
        //�{�[���̏�����
        ball.OnInit(barMoveValue);

        //�{�[�������Z�b�g�����
        //�G���A�ɏՓ˂����ۂɌĂ΂��֐���o�^
        ball.TriggerBall += TriggerBall;

        //�o�[�̏�����
        bar.OnInit();

        
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
            ResetGame();
        }
      
        // �o�[�̈ړ�
        bar.Onmove(barMoveValue);
    }
    /// <summary>
    /// �Q�[���̃��Z�b�g
    /// �E�{�[���̃��Z�b�g
    /// �E�u���b�N�̃��Z�b�g
    /// </summary>
    private void ResetGame()
    {
        //�{�[���𔭎˂ł���悤�ɂ���
        isShot = false;

        //�{�[���̃��Z�b�g
        ball.OnReset();

        //�o�[�̃��Z�b�g
        bar.OnReset();

        // �u���b�N�̃��Z�b�g
        blockController.OnReset();
    }
    private void TriggerBall()
    {
        ResetGame();
    }
}
