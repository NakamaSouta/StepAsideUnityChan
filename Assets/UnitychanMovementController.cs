using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitychanMovementController : MonoBehaviour
{
    //�Q�[���I���̔���
    private bool isEnd = false;

    //�A�j���[�V�������邽�߂̃R���|�l���g
    private Animator myAnimator;
    //�ړ������邽�߂̃R���|�l���g
    private Rigidbody myRigidbody;

    //�O�����̑��x
    private float velocityZ = 16.0f;
    //�������̑��x
    private float velocityX = 10.0f;
    //���E�̈ړ��ł���͈�
    private float movableRange = 3.4f;
    //������̑��x
    private float velocityY = 10.0f;

    //����������������W��
    private float coefficient = 0.99f;

    //�{�^���̔���
    private bool isLButtonDown = false;
    private bool isRButtonDown = false;
    private bool isJButtonDown = false;

    // Start is called before the first frame update
    void Start()
    {
        //�R���|�l���g�̎擾
        this.myAnimator = GetComponent<Animator>();
        this.myRigidbody = GetComponent<Rigidbody>();

        //�ړ��A�j���[�V����
        this.myAnimator.SetFloat("Speed", 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //�Q�[���I���̂Ƃ�Unity�����̓�������������
        if (this.isEnd)
        {
            this.velocityZ *= this.coefficient;
            this.velocityX *= this.coefficient;
            this.velocityY *= this.coefficient;
            this.myAnimator.speed *= this.coefficient;
        }

        //�Q�[���I���̂Ƃ�Unity�����̓�������������
        if (this.isEnd)
        {
            this.velocityZ *= this.coefficient;
            this.velocityX *= this.coefficient;
            this.velocityY *= this.coefficient;
            this.myAnimator.speed *= this.coefficient;
        }

        //�������̓��͂ɂ�鑬�x
        float inputVelocityX = 0;
        //������̓��͂ɂ�鑬�x
        float inputVelocityY = 0;

        //Unity��������L�[�ɉ����Ĉړ�
        if ((Input.GetKey(KeyCode.LeftArrow) || this.isLButtonDown) && -this.movableRange < this.transform.position.x)
        {
            inputVelocityX = -this.velocityX;
        }
        if ((Input.GetKey(KeyCode.RightArrow) || this.isRButtonDown) && this.movableRange > this.transform.position.x)
        {
            inputVelocityX = this.velocityX;
        }

        //�W�����v���Ă��Ȃ���ԂŃX�y�[�X�������ƃW�����v
        if ((Input.GetKeyDown(KeyCode.Space) || this.isJButtonDown) && this.transform.position.y < 0.5f)
        {
            //�W�����v�A�j�����Đ�
            this.myAnimator.SetBool("Jump", true);
            //������ւ̑��x����
            inputVelocityY = this.velocityY;
        }
        else
        {
            //���݂�Y���̑��x����
            inputVelocityY = this.myRigidbody.velocity.y;
        }

        //Jump�X�e�[�g�̏ꍇJump��false
        if (this.myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
        {
            this.myAnimator.SetBool("Jump", false);
        }


        //Unity�����ɑ��x��^����
        this.myRigidbody.velocity = new Vector3(inputVelocityX, inputVelocityY, this.velocityZ);
    }
    //�Փ˔���
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "CoinTag")
        {
            this.isEnd = true;
        }
        if (other.gameObject.tag == "CoinTag")
        {
            //�p�[�e�B�N�����Đ�
            GetComponent<ParticleSystem>().Play();

            Destroy(other.gameObject);
        }
    }

    //�W�����v�{�^��
    public void GetMyJumpButtonDown()
    {
        this.isJButtonDown = true;
    }
    public void GetMyJumpButtonUp()
    {
        this.isJButtonDown = false;
    }

    //���{�^��
    public void GetMyLeftButtonDown()
    {
        this.isLButtonDown = true;
    }
    public void GetMyLeftButtonUp()
    {
        this.isLButtonDown = false;
    }

    //�E�{�^��
    public void GetMyRightButtonDown()
    {
        this.isRButtonDown = true;
    }
    public void GetMyRightButtonUp()
    {
        this.isRButtonDown = false;
    }
}
