using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitychanUIController : MonoBehaviour
{
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

    // Start is called before the first frame update
    void Start()
    {

        //シーン中のstateTextオブジェクトを取得
        this.stateText = GameObject.Find("GameResultText");
        this.scoreText = GameObject.Find("ScoreText");
        //Textコンポネントの取得
        this.stateTextComponent = this.stateText.GetComponent<Text>();
        this.scoreTextComponent = this.scoreText.GetComponent<Text>();


    }

    // Update is called once per frame
    void Update()
    {

    }

    //衝突判定
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CarTag" || other.gameObject.tag == "TrafficConeTag")
        {
            //GAME OVER
            this.stateTextComponent.text = "GAME OVER";
        }

        if (other.gameObject.tag == "GoalTag")
        {
            //GAME OVER
            this.stateTextComponent.text = "CLEAR!!";
        }
        if (other.gameObject.tag == "CoinTag")
        {
            //スコアを加算
            this.score += 10;
            //テキストの表示
            this.scoreTextComponent.text = "Score " + this.score + "pt";
        }
    }

}
