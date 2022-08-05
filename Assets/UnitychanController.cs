using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitychanController : MonoBehaviour
{
    //アニメーションするためのコンポネント
    private Animator myAnimator;
    //移動させるためのコンポネント
    private Rigidbody myRigidbody;

    //前方向の速度
    private float velocityZ = 16.0f;
    //横方向の速度
    private float velocityX = 10.0f;
    //左右の移動できる範囲
    private float movableRange = 3.4f;
    //上方向の速度
    private float velocityY = 10.0f;

    //動きを減速させる係数
    private float coefficient = 0.99f;
    //ゲーム終了の判定
    private bool isEnd = false;

    //ゲーム終了時に表示するテキスト
    private GameObject stateText;
    //コンポネント
    private Text stateTextComponent;

    //スコアを表示するテキスト
    private GameObject scoreText;
    //コンポネント
    private Text scoreTextComponent;
    //得点(追加)
    private int score = 0;

    //ボタンの判定
    private bool isLButtonDown = false;
    private bool isRButtonDown = false;
    private bool isJButtonDown = false;

    // Start is called before the first frame update
    void Start()
    {
        //コンポネントの取得
        this.myAnimator = GetComponent<Animator>();
        this.myRigidbody = GetComponent<Rigidbody>();

        //シーン中のstateTextオブジェクトを取得
        this.stateText = GameObject.Find("GameResultText");
        this.scoreText = GameObject.Find("ScoreText");
        //Textコンポネントの取得
        this.stateTextComponent = this.stateText.GetComponent<Text>();
        this.scoreTextComponent = this.scoreText.GetComponent<Text>();

        //移動アニメーション
        this.myAnimator.SetFloat("Speed", 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //ゲーム終了のときUnityちゃんの動きを減衰する
        if (this.isEnd)
        {
            this.velocityZ *= this.coefficient;
            this.velocityX *= this.coefficient;
            this.velocityY *= this.coefficient;
            this.myAnimator.speed *= this.coefficient;
        }

        //横方向の入力による速度
        float inputVelocityX = 0;
        //上方向の入力による速度
        float inputVelocityY = 0;

        //Unityちゃんを矢印キーに応じて移動
        if ( (Input.GetKey(KeyCode.LeftArrow) || this.isLButtonDown)&& -this.movableRange < this.transform.position.x)
        {
            inputVelocityX = -this.velocityX;
        }
        if ( (Input.GetKey(KeyCode.RightArrow) || this.isRButtonDown) && this.movableRange > this.transform.position.x)
        {
            inputVelocityX = this.velocityX;
        }

        //ジャンプしていない状態でスペースを押すとジャンプ
        if ( (Input.GetKeyDown(KeyCode.Space) || this.isJButtonDown) && this.transform.position.y < 0.5f)
        {
            //ジャンプアニメを再生
            this.myAnimator.SetBool("Jump", true);
            //上方向への速度を代入
            inputVelocityY = this.velocityY;
        }
        else
        {
            //現在のY軸の速度を代入
            inputVelocityY = this.myRigidbody.velocity.y;
        }

        //Jumpステートの場合Jumpはfalse
        if (this.myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
        {
            this.myAnimator.SetBool("Jump", false);
        }


        //Unityちゃんに速度を与える
        this.myRigidbody.velocity = new Vector3(inputVelocityX, inputVelocityY, this.velocityZ);
    }

    //衝突判定
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
            //スコアを加算
            this.score += 10;
            //テキストの表示
            this.scoreTextComponent.text = "Score " + this.score + "pt";

            //パーティクルを再生
            GetComponent<ParticleSystem>().Play();

            Destroy(other.gameObject);
        }
    }

    //ジャンプボタン
    public void GetMyJumpButtonDown()
    {
        this.isJButtonDown = true;
    }
    public void GetMyJumpButtonUp()
    {
        this.isJButtonDown = false;
    }

    //左ボタン
    public void GetMyLeftButtonDown()
    {
        this.isLButtonDown = true;
    }
    public void GetMyLeftButtonUp()
    {
        this.isLButtonDown = false;
    }

    //右ボタン
    public void GetMyRightButtonDown()
    {
        this.isRButtonDown = true;
    }
    public void GetMyRightButtonUp()
    {
        this.isRButtonDown = false;
    }
}
