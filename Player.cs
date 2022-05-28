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

        MoveX = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        MoveY = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        transform.Translate(MoveX, 0, MoveY);
    }
}
