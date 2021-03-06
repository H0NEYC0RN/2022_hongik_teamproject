using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flashlight : MonoBehaviour
{
    // Flash 작동 관련
    [SerializeField] GameObject FlashlightLight;
    [SerializeField] Image Flash_Ready;
    private bool isReady;
    private bool FlashlightActive = false;

    // Battery 관련
    public float LimitTime;
    public float Left_over;
    private float Left_Output;
    [SerializeField] Text text_Timer;

    // Charger 관련
    [SerializeField] Text Charger_UI;
    [SerializeField] GameObject Charger_Objcet;
    [SerializeField] Vector3 Charger_A;
    [SerializeField] Vector3 Charger_B;
    [SerializeField] Vector3 Charger_C;

    //UI관련
    [SerializeField] GameObject Dialogue;
    [SerializeField] Text Text;
    [SerializeField] GameObject Event_UI;

    private float Charger;
    private bool isHaveBattery;
    private bool isPickup;
    private bool isDestroy;


    void Start()
    {
        isPickup = false;
        isReady = true;
        isHaveBattery = false;
        FlashlightLight.gameObject.SetActive(false);
        Color color_true = Flash_Ready.color;
        color_true.a = 1.0f;
        Flash_Ready.color = color_true;


        Left_Output = Left_over / 10;
        text_Timer.text = Left_Output.ToString("") + "%";
        Charger_UI.text = Charger.ToString("") + " 개";

        Instantiate(Charger_Objcet, Charger_A, Quaternion.identity);
        Instantiate(Charger_Objcet, Charger_B, Quaternion.identity);
        Instantiate(Charger_Objcet, Charger_C, Quaternion.identity);
    }


    void Update()
    {
        // 배터리의 현재 잔량을 00.0%의 형태로 출력
        Left_Output = Left_over / 10;
        text_Timer.text = Left_Output.ToString("N1") + "%";

        if (isReady == true)
        {
            // 손전등이 사용 가능하고, 손전등이 작동중일 때
            if (FlashlightActive == true)
            {
                Time_pass();
            }

            // F를 눌러 손전등 작동
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (FlashlightActive == false)
                {
                    FlashlightLight.gameObject.SetActive(true);
                    FlashlightActive = true;
                }
                else
                {
                    FlashlightActive = false;
                    FlashlightLight.gameObject.SetActive(false);
                }
            }
        }
        // 손전등이 사용 불가능한 상태일때, 손전등을 비활성화
        else
        {
            Color color_false = Flash_Ready.color;
            color_false.a = 0.0f;
            Flash_Ready.color = color_false;
            FlashlightActive = false;
            FlashlightLight.gameObject.SetActive(false);
        }

        // 보조 배터리를 보유하고 있을때, B키를 누르면 배터리를 사용함
        if (isHaveBattery == true && Input.GetKeyDown(KeyCode.B))
        {
            Battery_Charger();
        }

        // 보조 배터리 보유 여부 체크
        Charger_check();


        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isPickup == true)
            {
                Charger += 1;
                Charger_UI.text = Charger.ToString("") + " 개";
                isDestroy = true;
                isPickup = false;
            }
        }
    }

    void Battery_Charger()
    {
        Charger -= 1;
        Charger_UI.text = Charger.ToString("") + " 개";

        Left_over += 500;
        isReady = true;
        Color color_true = Flash_Ready.color;
        color_true.a = 1.0f;
        Flash_Ready.color = color_true;

        // 배터리를 충전했을때, 남은 시간이 배터리의 최대 시간보다 커지면
        // 배터리의 남은 시간을 배터리의 최대 시간과 동일하게 함
        if (Left_over >= LimitTime)
        {
            Left_over = LimitTime;
        }
    }

    void Charger_check()
    {
        if (Charger >= 1)
        {
            isHaveBattery = true;
        }
        else
        {
            isHaveBattery = false;
        }
    }

    void Time_pass()
    {
        if (Left_over >= 0f)
        {
            // 잔여시간 = (현재의 잔여시간 - 1초)
            Left_over = Left_over -= Time.deltaTime;
        }
        else
        {
            // 잔여시간이 음수가 되지 않도록, 0f보다 작아지면 =0 으로 고정함
            Left_over = 0;
            // 잔여시간이 0이되면 손전등 사용 가능 여부 비활성화
            isReady = false;
        }
    }

    // 보조 배터리 태그(Charger)를 달고있는 오브젝트에 닿으면
    // 보조 배터리를 획득하고, 해당 오브젝트 파괴
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Charger")
        {
            Event_UI.SetActive(true);
            Dialogue.SetActive(true);
            Text.text = "E키를 눌러 상호작용 할 수 있다.";

            isPickup = true;
            if (isDestroy == true)
            {
                Destroy(other.gameObject);
                isDestroy = false;
                isPickup = false;
                Event_UI.SetActive(false);
                Dialogue.SetActive(false);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Charger")
        {
            Event_UI.SetActive(false);
            Dialogue.SetActive(false);
            Text.text = "";
        }
    }
}
