using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    public Slider hpbar;
    public float maxHp;
    public float currenthp;
    bool runing;
    // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        hpbar.value = currenthp / maxHp;

        if (GameObject.Find("Player").GetComponent<Player>().IsRuning == true)
        {
            Debug.Log("IsRuning");
            currenthp -= 1;
        }

        if (GameObject.Find("Player").GetComponent<Player>().IsRuning == false)
        {
            if (currenthp <= maxHp)
            {
                Debug.Log("Is'nt runing");
                currenthp += 0.1f;
            }
        }
    }
}
