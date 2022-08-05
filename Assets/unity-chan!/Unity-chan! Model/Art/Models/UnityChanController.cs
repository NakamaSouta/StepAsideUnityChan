using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour
{
    //アニメーションを入れる
    private Animator myAnimator;
    //Unityちゃんを移動させるコンポネント
    private Rigidbody myRigidbody;
    //前方向の速度
    private float velocityZ = 16.0f;


    // Start is called before the first frame update
    void Start()
    {
        //Animatorコンポネントを取得
        this.myAnimator = GetComponent<Animator>();
        //Rigidbodyコンポネントを取得
        this.myRigidbody = GetComponent<Rigidbody>();


        //走るアニメーションを開始
        this.myAnimator.SetFloat("Speed", 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        this.myRigidbody.velocity = new Vector3(0, 0, this.velocityZ);
    }
}
