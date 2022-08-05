using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    private GameObject camera;

    // Start is called before the first frame update
    void Start()
    {
        this.camera = GameObject.Find("MainCamera");

        //��]���J�n����p�x
        this.transform.Rotate(0, Random.Range(0, 360), 0);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0, 3, 0);

        //�J�����O�ɏo����I�u�W�F�N�g��j��
        if (this.camera.transform.position.z > this.transform.position.z)
        {
            Destroy(gameObject);
        }
    }
}
