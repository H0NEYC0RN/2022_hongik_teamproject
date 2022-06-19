using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note_Password : MonoBehaviour
{
    [SerializeField] Text note;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Keypad").GetComponent<Keypad>().Stage_random == 1)
        { note.text = "1005".ToString(); }

        if (GameObject.Find("Keypad").GetComponent<Keypad>().Stage_random == 2)
        { note.text = "1229".ToString(); }

        if (GameObject.Find("Keypad").GetComponent<Keypad>().Stage_random == 3)
        { note.text = "1214".ToString(); }

        if (GameObject.Find("Keypad").GetComponent<Keypad>().Stage_random == 4)
        { note.text = "1102".ToString(); }
    }
}
