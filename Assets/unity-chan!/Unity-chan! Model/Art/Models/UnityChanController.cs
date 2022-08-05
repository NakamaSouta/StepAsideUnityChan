using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour
{
    //�A�j���[�V����������
    private Animator myAnimator;
    //Unity�������ړ�������R���|�l���g
    private Rigidbody myRigidbody;
    //�O�����̑��x
    private float velocityZ = 16.0f;


    // Start is called before the first frame update
    void Start()
    {
        //Animator�R���|�l���g���擾
        this.myAnimator = GetComponent<Animator>();
        //Rigidbody�R���|�l���g���擾
        this.myRigidbody = GetComponent<Rigidbody>();


        //����A�j���[�V�������J�n
        this.myAnimator.SetFloat("Speed", 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        this.myRigidbody.velocity = new Vector3(0, 0, this.velocityZ);
    }
}
