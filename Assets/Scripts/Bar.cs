using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{

    //�������g
    [SerializeField]
    private Rigidbody body;

    //�����ʒu
    private Vector3 initPos;

    /// <summary>
    /// ������
    /// �E�o�[�̏����ʒu
    /// </summary>

    public void OnInit()
    {
        initPos = transform.localPosition;
    }

    /// <summary>
    /// ���Z�b�g
    /// �E�o�[�������ʒu�Ɉړ�������
    /// �E�o�[�̑��x���O�ɂ���Ȃ�
    /// </summary>

    public void OnReset()
    {
        transform.localPosition = initPos;
        body.velocity = Vector3.zero;
    }


    public void Onmove(float speed)
    {
        //�o�[���ړ�������
        var dir = Input.GetAxis("Horizontal");
        body.velocity = dir * Vector3.right * speed;
    }
}