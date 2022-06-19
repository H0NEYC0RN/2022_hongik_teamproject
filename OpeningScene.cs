using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpeningScene : MonoBehaviour
{
    // OpenScene 캔버스와 그 자식 UI들에 전부 태그 각각 달아줄 것(이름과 같은 태그)
    public GameObject Opening; // OpeningScene Canvas
    public GameObject Title; // Title
    public GameObject OP1; // Opening01
    public GameObject OP2; // Opening02
    public GameObject OP3; // Opening03
    int enterCount = 0; // 숫자 카운트로 순서를 정해줄 것
    
    // Start is called before the first frame update
    void Start()
    {
        Opening = GameObject.FindWithTag("OpenScene");
        OP1 = GameObject.FindWithTag("Opening01");
        OP2 = GameObject.FindWithTag("Opening02");
        OP3 = GameObject.FindWithTag("Opening03");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Esc Pressed");
            Application.Quit(); // 게임 종료
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (enterCount == 0)
            {
                Debug.Log("SpaceBar Pressed");
                Title.SetActive(false);
                enterCount++;
            }

            else if (enterCount == 1)
            {
                Debug.Log("SpaceBar Pressed");
                OP1.SetActive(false);
                enterCount++;
            }

            else if (enterCount == 2)
            {
                Debug.Log("SpaceBar Pressed");
                OP2.SetActive(false);
                enterCount++;
            }

            else if (enterCount == 3)
            {
                Debug.Log("SpaceBar Pressed");
                OP3.SetActive(false);
                Opening.SetActive(false);
                SceneManager.LoadScene("Main", LoadSceneMode.Single); // 게임 Scene 이름을 넣어주기
            }
        }
        
    }
}
