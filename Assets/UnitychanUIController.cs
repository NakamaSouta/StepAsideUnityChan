using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitychanUIController : MonoBehaviour
{
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

    // Start is called before the first frame update
    void Start()
    {

        //�V�[������stateText�I�u�W�F�N�g���擾
        this.stateText = GameObject.Find("GameResultText");
        this.scoreText = GameObject.Find("ScoreText");
        //Text�R���|�l���g�̎擾
        this.stateTextComponent = this.stateText.GetComponent<Text>();
        this.scoreTextComponent = this.scoreText.GetComponent<Text>();


    }

    // Update is called once per frame
    void Update()
    {

    }

    //�Փ˔���
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
            //�X�R�A�����Z
            this.score += 10;
            //�e�L�X�g�̕\��
            this.scoreTextComponent.text = "Score " + this.score + "pt";
        }
    }

}
