using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    // ĳ�������� �����ؾ��ϴ� ��ũ��Ʈ! ���Ŀ� ��ũ��Ʈ inspector�� ������ ������Ʈ �־��ֱ�

    [SerializeField] GameObject FlashlightLight;
    private bool FlashlightActive = false; //off ���°� �⺻


    // Start is called before the first frame update
    void Start()
    {
        FlashlightLight.gameObject.SetActive(false); // ���� �ÿ� off ����(on���� �Ϸ��� true��)
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F)) // FŰ ������ �۵�
        {
            if(FlashlightActive == false) //�������� ���� ������ ���
            {
                Debug.Log("FlashLight ON");
                FlashlightLight.gameObject.SetActive(true);
                FlashlightActive = true;
            }

            else  // �������� �����ִ� ������ ��
            {
                Debug.Log("FlashLight OFF");
                FlashlightLight.gameObject.SetActive(false);
                FlashlightActive = false;
            }
        }
    }
}
