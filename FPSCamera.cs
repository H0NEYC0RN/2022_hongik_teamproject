using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCamera : MonoBehaviour
{
    // �÷��̾����� ����ī�޶� �־��ְ�, ��ũ��Ʈ�� ī�޶� �����Ű��

    public float rotSpeed = 200; // ī�޶� ȸ�� �ӵ�

    // ���콺�� X, Y ������ ��Ÿ���ϴ�
    float mouseX;
    float mouseY;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // ���콺�� �������� ����
        float h = Input.GetAxis("Mouse X");
        float v = Input.GetAxis("Mouse Y");

        // ���콺�� ������ ���� ����
        mouseX += h * rotSpeed * Time.deltaTime;
        mouseY += v * rotSpeed * Time.deltaTime;

        // mouseY ������ �ּҰ� -90, �ִ밪 90���� ����
        mouseY = Mathf.Clamp(mouseY, -90, 90);

        transform.eulerAngles = new Vector3(-mouseY, mouseX, 0);
    }
}
