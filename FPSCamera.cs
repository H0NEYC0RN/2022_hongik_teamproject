using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCamera : MonoBehaviour
{
    // 플레이어한테 메인카메라 넣어주고, 스크립트는 카메라에 적용시키기

    [SerializeField] float Camera_Speed; // 카메라 이동 속도
    [SerializeField] float rotSpeed = 200; // 카메라 회전 속도
    [SerializeField] GameObject Player;
    [SerializeField] Vector3 Offset;

    // 마우스의 X, Y 각도를 나타냅니다
    float mouseX;
    float mouseY;
    float mouseZ;

    void Update()
    {
        transform.position = Player.transform.position + Offset;

        // 마우스의 움직임을 감지
        float h = Input.GetAxis("Mouse X");
        float v = Input.GetAxis("Mouse Y");
        float a = Input.GetAxis("Mouse Z");

        // 마우스로 움직인 각도 누적
        mouseX += h * rotSpeed * Time.deltaTime;
        mouseY += v * rotSpeed * Time.deltaTime;
        mouseZ += a * rotSpeed * Time.deltaTime;

        // mouseY 범위가 최소값 -90, 최대값 90으로 고정
        mouseY = Mathf.Clamp(mouseY, -90, 90);
        mouseZ = Mathf.Clamp(mouseY, -90, 90);

        transform.eulerAngles = new Vector3(-mouseY, mouseX, -mouseZ);
    }
}
