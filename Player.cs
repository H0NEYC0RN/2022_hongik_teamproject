using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    float speed, MoveX, MoveY;
    [SerializeField] float normalSpeed, runSpeed;
    float hp;

    public bool IsRuning;

    // Start is called before the first frame update
    void Start()
    {
        IsRuning = false;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        { 

            if (GameObject.Find("HP_Bar").GetComponent<HP>().currenthp <= 5)
            {
                speed = normalSpeed;
                IsRuning = false;
            }

            else if(GameObject.Find("HP_Bar").GetComponent<HP>().currenthp >= 15)
            {

                speed = runSpeed;
                IsRuning = true;
            }

        }    
        else
        {
            speed = normalSpeed;
            IsRuning = false;
        }

        MoveX = Input.GetAxis("Horizontal");
        MoveY = Input.GetAxis("Vertical");

        // 캐릭터가 Z축(인스펙터상 Y축)으로 움직이지 않도록 고정
        Vector3 dir = new Vector3(MoveX, 0, MoveY); 
        dir.Normalize(); // 정규화

        // 현재 (메인)카메라가 바라보는 방향으로 이동
        dir = Camera.main.transform.TransformDirection(dir);
        // Player 가 공중, 바닥으로 이동하지 않도록 y(z)값을 고정
        dir.y = 0;

        transform.position += dir * speed * Time.deltaTime;
    }
}
