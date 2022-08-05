using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    private GameObject unitychan;
    //Unity�����̎��E
    private int unitychanView;

    //�I�u�W�F�N�g�̃v���t�@�u
    public GameObject carPrefab;
    public GameObject coinPrefab;
    public GameObject conePrefab;
    //�X�^�[�g�n�_
    private int startPos = 80;
    //�S�[���n�_
    private int goalPos = 360;
    //�A�C�e�����o��x�����͈̔�
    private float posRange = 3.4f;
    

    // Start is called before the first frame update
    void Start()
    {
        this.unitychan = GameObject.Find("unitychan");
    }

// Update is called once per frame
void Update()
    {
        //Unity�����̎��E��Unity�����45m��
        this.unitychanView = (int)(this.unitychan.transform.position.z) + 45;

        int i = startPos;
        if (this.unitychanView > startPos && this.unitychanView < goalPos)
        {
            int num = Random.Range(1, 11);
            //20%�R�[��, 80%item�̔z�u
            if (num <= 2)
            {
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    GameObject cone = Instantiate(conePrefab);
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, i);
                }
            }
            else
            {
                for (int j = -1; j <= 1; j++)
                {
                    //�A�C�e���̎��
                    int item = Random.Range(1, 11);
                    //�A�C�e����u��Z���W�̃I�t�Z�b�g
                    int offsetZ = Random.Range(-5, 6);
                    //60%�R�C���z�u:30%�Ԕz�u:10%�����Ȃ�
                    if (1 <= item && item <= 6)
                    {
                        //�R�C���𐶐�
                        GameObject coin = Instantiate(coinPrefab);
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, i + offsetZ);
                    }
                    else if (7 <= item && item <= 9)
                    {
                        //�Ԃ𐶐�
                        GameObject car = Instantiate(carPrefab);
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, i + offsetZ);
                    }
                }
            }
            startPos += 15;
        }
    }
}
