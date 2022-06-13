using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    float speed, MoveX, MoveY;
    [SerializeField] float normalSpeed, runSpeed;
    
    float hp;
    public bool IsRuning = false;
    
    [SerializeField] GameObject State;
    public bool isReset;
    
    //Save Position (Stage별로 다르게 적용해줘야 함)
    [SerializeField] Vector3 Save1;
    [SerializeField] Vector3 Save2;
    [SerializeField] Vector3 Save3;
    [SerializeField] Vector3 Save4;


    void Start()
    {
        isReset = State.GetComponent<Player_state>().Reset_ON;

        IsRuning = false;
        speed = normalSpeed;
        State.SetActive(true);
    }


    void Update()
    {
        Movement();

        if (isReset == true)
        {
            Reset_check();
        }
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
        
        if (State.GetComponent<Player_state>().isHided == false)
        {
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
    
    
    void Reset_check()
    {
        if (State.GetComponent<Player_state>().Event_count == 0)
        {
            this.transform.position = Save1;
        }
        if (State.GetComponent<Player_state>().Event_count == 1)
        {
            this.transform.position = Save2;
        }
        if (State.GetComponent<Player_state>().Event_count == 2)
        {
            this.transform.position = Save3;
        }
        if (State.GetComponent<Player_state>().Event_count >= 3)
        {
            this.transform.position = Save4;
        }
    }
}
