using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Telpo : MonoBehaviour
{
    //해당 스크립트는 Player_State에 넣지만, 부모 오브젝트인 Player를 이동시켜야 함
    [SerializeField] GameObject Player;

    [SerializeField] Image Fade; //1920*1080(0,0,0)

    //Player의 시작 위치 지정(Inspector)
    [SerializeField] Vector3 Starting_point;

    //각 계단별 이동 위치 지정(Inspector)
    [SerializeField] Vector3 B1_B2;
    [SerializeField] Vector3 B2_B3;
    [SerializeField] Vector3 B3_B2;
    [SerializeField] Vector3 A1_A2;
    [SerializeField] Vector3 A2_A3;
    [SerializeField] Vector3 A_to_B;

    [SerializeField] GameObject Dialogue;
    [SerializeField] Text TEXT;
    [SerializeField] Text Location_TEXT;

    private int Stair_counnt = 0;

    private void Start()
    {
        Player.gameObject.transform.position = Starting_point;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Stair_counnt == 1)
            {
                FadeIN();
                Invoke("FadeOUT", 1f);
                Player.gameObject.transform.position = B1_B2;
                Location_TEXT.text = "B동 2층";
            }
            if (Stair_counnt == 2)
            {
                FadeIN();
                Invoke("FadeOUT", 1f);
                Player.gameObject.transform.position = B2_B3;
                Location_TEXT.text = "B동 3층";
            }
            if (Stair_counnt == 3)
            {
                FadeIN();
                Player.gameObject.transform.position = B3_B2;
                Location_TEXT.text = "B동 2층";
            }
            if (Stair_counnt == 4)
            {
                FadeIN();
                Player.gameObject.transform.position = A1_A2;
                Location_TEXT.text = "A동 2층";
            }
            if (Stair_counnt == 5)
            {
                FadeIN();
                Player.gameObject.transform.position = A2_A3;
                Location_TEXT.text = "A동 3층";
            }
            if (Stair_counnt == 6)
            {
                FadeIN();
                Player.gameObject.transform.position = A_to_B;
                Location_TEXT.text = "B동 ";
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "B1_stair")    //1->2
        {
            Stair_counnt = 1;
            Dialogue.SetActive(true);
            TEXT.text = "2층으로 올라갈까?\n(E키를 눌러 올라갈 수 있다.)";
        }

        if (other.tag == "B2_stair")    //2->3
        {
            Stair_counnt = 2;
            Dialogue.SetActive(true);
            TEXT.text = "3층으로 올라갈까?\n(E키를 눌러 올라갈 수 있다.)";
        }

        if (other.tag == "B3_stair")    //3->2
        {
            Stair_counnt = 3;
            Dialogue.SetActive(true);
            TEXT.text = "2층으로 내려갈까?\n(E키를 눌러 내려갈 수 있다.)";
        }

        if (other.tag == "A1_stair")    //1->2
        {
            Stair_counnt = 4;
            Dialogue.SetActive(true);
            TEXT.text = "2층으로 올라갈까?\n(E키를 눌러 올라갈 수 있다.)";
        }

        if (other.tag == "A2_stair")    //2->3
        {
            Stair_counnt = 5;
            Dialogue.SetActive(true);
            TEXT.text = "3층으로 올라갈까?\n(E키를 눌러 올라갈 수 있다.)";
        }

        if (other.tag == "A_gurm")    //A-B동 구름다리
        {
            Stair_counnt = 6;
            Dialogue.SetActive(true);
            TEXT.text = "구름다리를 건너면 B동으로 갈 수 있다.\n(E키를 눌러 갈 수 있다.)";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "B1_stair")
        {
            Stair_counnt = 0;
            Dialogue.SetActive(false);
            TEXT.text = "";
        }
        if (other.tag == "B2_stair")
        {
            Stair_counnt = 0;
            Dialogue.SetActive(false);
            TEXT.text = "";
        }
        if (other.tag == "B3_stair")
        {
            Stair_counnt = 0;
            Dialogue.SetActive(false);
            TEXT.text = "";
        }
        if (other.tag == "A1_stair")
        {
            Stair_counnt = 0;
            Dialogue.SetActive(false);
            TEXT.text = "";
        }
        if (other.tag == "A2_stair")
        {
            Stair_counnt = 0;
            Dialogue.SetActive(false);
            TEXT.text = "";
        }
        if (other.tag == "A_gurm")
        {
            Stair_counnt = 0;
            Dialogue.SetActive(false);
            TEXT.text = "";
        }
    }

    IEnumerator InFadeUI()
    {
        float StartAlpha = 0;
        while (StartAlpha < 1.0f)
        {
            StartAlpha += 0.05f;
            yield return new WaitForSeconds(0.01f);
            Fade.color = new Color(0, 0, 0, StartAlpha);

            if (StartAlpha == 1)
            {
                yield break;
            }
        }
    }

    void FadeIN()
    {
        StartCoroutine(InFadeUI());
    }

    // ȭ�� Fade OUT
    IEnumerator OUTFadeUI()
    {
        float StartAlpha = 1;
        while (StartAlpha >= 0.0f)
        {
            StartAlpha -= 0.05f;
            yield return new WaitForSeconds(0.01f);
            Fade.color = new Color(0, 0, 0, StartAlpha);
            if (StartAlpha == 0)
            {
                yield break;
            }
        }
    }

    void FadeOUT()
    {
        StartCoroutine(OUTFadeUI());
    }

}
