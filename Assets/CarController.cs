using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private GameObject camera;

    // Start is called before the first frame update
    void Start()
    {
        this.camera = GameObject.Find("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        //�J�����O�ɏo����I�u�W�F�N�g��j��
        if (this.camera.transform.position.z > this.transform.position.z)
        {
            Destroy(gameObject);
        }
    }
}
