using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flashlight : MonoBehaviour
{
    // 캐릭터한테 적용해야하는 스크립트! 이후에 스크립트 inspector에 손전등 오브젝트 넣어주기

    public GameObject FlashlightLight;
    private bool FlashlightActive = false; //off 상태가 기본

    // 배터리 잔량 표시를 위한 코드
    public float LimitTime;
    public Text text_Timer; // TMP 말고 그냥 Text 가져와야함
    
    private bool ChargeActive = false;

    bool isHaveBattery = false; // 보조 배터리를 줍기 전이라서 false라고 적었음

    // Start is called before the first frame update
    void Start()
    {
        text_Timer.text = " 1000 / " + Mathf.Round(LimitTime);

        FlashlightLight.gameObject.SetActive(false); // 시작 시에 off 상태(on으로 하려면 true로)
        ChargeActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F)) // F키 눌러서 작동
        {
            if(FlashlightActive == false) //손전등이 꺼진 상태일 경우
            {
                Debug.Log("FlashLight ON");
                FlashlightLight.gameObject.SetActive(true);
                FlashlightActive = true;
            }

            else  // 손전등이 켜져있는 상태일 때
            {
                Debug.Log("FlashLight OFF");
                FlashlightLight.gameObject.SetActive(false);
                FlashlightActive = false;
            }
        }

        while(FlashlightActive == true) // 손전등이 켜진 상태일 때만
        {
            text_Timer.text = " 1000 / " + Mathf.Round(LimitTime);

            if (Mathf.Round(LimitTime) > 0.0f)
            {
                LimitTime -= Time.deltaTime; // 매 초마다 배터리가 줄어듦
            }
            else //배터리가 방전됐을 경우
            {
                Debug.Log("Low Battery");
                FlashlightLight.gameObject.SetActive(false);
                FlashlightActive = false;
            }
            
            break;
        }
        
        // 보조 배터리 작동
        if (isHaveBattery = true && Input.GetKeyDown(KeyCode.B)) // B키 눌러서 작동
        {
            if (ChargeActive == false) //보조 배터리 사용 안하는 경우
            {
                Debug.Log("Start Charging");
                ChargeActive = true;
            }

            else  // 보조 배터리 사용 중일 경우
            {
                Debug.Log("Stop Charging");
                ChargeActive = false;
            }
        }

        while (ChargeActive == true) // 손전등이 켜진 상태일 때만
        {
            text_Timer.text = " 1000 / " + Mathf.Round(LimitTime);

            if (Mathf.Round(LimitTime) < 1000.0f)
            {
                LimitTime += Time.deltaTime; // 매 초마다 충전
            }
            else //배터리가 충전 완료됐을 경우
            {
                Debug.Log("Full Battery");
                ChargeActive = false;
            }

            break;
        }
    }
}
