using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public Transform Player;
    public static bool Is_Note_On = false;      
    public GameObject noteMenuCanvas;           //쪽지 캔버스
    public GameObject note_key_Canvas;          //가까이 갔을 때 상호작용 캔버스



    void Update()
    {
        if (Player)
        {
            float dist = Vector3.Distance(Player.position, transform.position);

            if (dist <= 2.3)        //거리확인
            {
                Note_Key_On();      //거리 내에 있으면 상호작용 키 표시
                if (Input.GetKeyDown(KeyCode.E))
                {
                   

                    if (Is_Note_On)
                    {
                        Note_Off();
                    }
                    else
                    {
                        Note_On();

                    }
                }
            }
            else
            {
                Note_Key_Off();     //거리 밖이면 상호작용 키 안보이게
            }

        }
    }

    //쪽지 온오프
    public void Note_Off()
    {
        noteMenuCanvas.SetActive(false);
        Time.timeScale = 1f;
        Is_Note_On = false;
    }

    public void Note_On()
    {
        Note_Key_Off();
        noteMenuCanvas.SetActive(true);
        Time.timeScale = 0f;
        Is_Note_On = true;
    }


    //상호작용 키 온오프
    public void Note_Key_On()
    {
        note_key_Canvas.SetActive(true);
    }

    public void Note_Key_Off()
    {
        note_key_Canvas.SetActive(false);
    }
}
