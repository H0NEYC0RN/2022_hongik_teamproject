using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpeningScene : MonoBehaviour
{
    // OpenScene ĵ������ �� �ڽ� UI�鿡 ���� �±� ���� �޾��� ��(�̸��� ���� �±�)
    public GameObject Opening; // OpeningScene Canvas
    public GameObject OP1; // Opening01
    public GameObject OP2; // Opening02
    public GameObject OP3; // Opening03
    int enterCount = 0; // ���� ī��Ʈ�� ������ ������ ��
    
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (enterCount == 0)
            {
                Debug.Log("SpaceBar Pressed");
                OP1.SetActive(false);
                enterCount++;
            }

            else if (enterCount == 1)
            {
                Debug.Log("SpaceBar Pressed");
                OP2.SetActive(false);
                enterCount++;
            }

            else if (enterCount == 2)
            {
                Debug.Log("SpaceBar Pressed");
                OP3.SetActive(false);
                enterCount++;
            }

            else if (enterCount == 3)
            {
                Debug.Log("SpaceBar Pressed");
                Opening.SetActive(false);
            }
        }
        
    }
}
