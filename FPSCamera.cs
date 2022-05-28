using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCamera : MonoBehaviour
{
    // 플레이어한테 메인카메라 넣어주고, 스크립트는 카메라에 적용시키기

    public float rotSpeed = 200; // 카메라 회전 속도

    // 마우스의 X, Y 각도를 나타냅니다
    float mouseX;
    float mouseY;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 마우스의 움직임을 감지
        float h = Input.GetAxis("Mouse X");
        float v = Input.GetAxis("Mouse Y");

        // 마우스로 움직인 각도 누적
        mouseX += h * rotSpeed * Time.deltaTime;
        mouseY += v * rotSpeed * Time.deltaTime;

        // mouseY 범위가 최소값 -90, 최대값 90으로 고정
        mouseY = Mathf.Clamp(mouseY, -90, 90);

        transform.eulerAngles = new Vector3(-mouseY, mouseX, 0);
    }
}
