using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Password_Input : MonoBehaviour
{
    [SerializeField] InputField field;
    [SerializeField] Text text;
    [SerializeField] int pw;
    string PW_str;

    // Start is called before the first frame update
    void Start()
    {
        pw = Random.Range(1000, 9999);
        PW_str = pw.ToString();
        field.text = "";
        text.text = "비밀번호를 입력하세요";
    }

    // Update is called once per frame
    void Update()
    {
        if(field.text == PW_str)
        {
            Debug.Log("비밀번호 입력됨");
            //씬 전환 ??
        }
        else
        {
            text.text = "비밀번호가 틀렸습니다";
        }
    }
}
