using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    // 캐릭터한테 적용해야하는 스크립트! 이후에 스크립트 inspector에 손전등 오브젝트 넣어주기

    [SerializeField] GameObject FlashlightLight;
    private bool FlashlightActive = false; //off 상태가 기본


    // Start is called before the first frame update
    void Start()
    {
        FlashlightLight.gameObject.SetActive(false); // 시작 시에 off 상태(on으로 하려면 true로)
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
    }
}
