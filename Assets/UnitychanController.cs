using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitychanController : MonoBehaviour
{
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
    //�Q�[���I���̔���
    private bool isEnd = false;

    //�Q�[���I�����ɕ\������e�L�X�g
    private GameObject stateText;
    //�R���|�l���g
    private Text stateTextComponent;

    //�X�R�A��\������e�L�X�g
    private GameObject scoreText;
    //�R���|�l���g
    private Text scoreTextComponent;
    //���_(�ǉ�)
    private int score = 0;

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

        //�V�[������stateText�I�u�W�F�N�g���擾
        this.stateText = GameObject.Find("GameResultText");
        this.scoreText = GameObject.Find("ScoreText");
        //Text�R���|�l���g�̎擾
        this.stateTextComponent = this.stateText.GetComponent<Text>();
        this.scoreTextComponent = this.scoreText.GetComponent<Text>();

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

        //�������̓��͂ɂ�鑬�x
        float inputVelocityX = 0;
        //������̓��͂ɂ�鑬�x
        float inputVelocityY = 0;

        //Unity��������L�[�ɉ����Ĉړ�
        if ( (Input.GetKey(KeyCode.LeftArrow) || this.isLButtonDown)&& -this.movableRange < this.transform.position.x)
        {
            inputVelocityX = -this.velocityX;
        }
        if ( (Input.GetKey(KeyCode.RightArrow) || this.isRButtonDown) && this.movableRange > this.transform.position.x)
        {
            inputVelocityX = this.velocityX;
        }

        //�W�����v���Ă��Ȃ���ԂŃX�y�[�X�������ƃW�����v
        if ( (Input.GetKeyDown(KeyCode.Space) || this.isJButtonDown) && this.transform.position.y < 0.5f)
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
        if (other.gameObject.tag == "CarTag" || other.gameObject.tag == "TrafficConeTag")
        {
            this.isEnd = true;
            //GAME OVER
            this.stateTextComponent.text = "GAME OVER";
        }

        if (other.gameObject.tag == "GoalTag")
        {
            this.isEnd = true;
            //GAME OVER
            this.stateTextComponent.text = "CLEAR!!";
        }
        if (other.gameObject.tag == "CoinTag")
        {
            //�X�R�A�����Z
            this.score += 10;
            //�e�L�X�g�̕\��
            this.scoreTextComponent.text = "Score " + this.score + "pt";

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
