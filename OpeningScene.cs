using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpeningScene : MonoBehaviour
{
    [SerializeField] GameObject Title; // Title
    [SerializeField] GameObject OP1; // Opening01
    [SerializeField] GameObject OP2; // Opening02
    [SerializeField] GameObject OP3; // Opening03
    public bool isdone = false;
    int enterCount = 0; // 숫자 카운트로 순서를 정해줄 것

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (enterCount == 0)
            {
                Title.SetActive(false);
                enterCount++;
            }

            else if (enterCount == 1)
            {
                OP1.SetActive(false);
                enterCount++;
            }

            else if (enterCount == 2)
            {
                OP2.SetActive(false);
                enterCount++;
            }

            else if (enterCount == 3)
            {
                OP3.SetActive(false);
                isdone = true;
            }
        }
    }
}
