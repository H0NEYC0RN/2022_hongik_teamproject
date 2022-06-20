using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note : MonoBehaviour
{
    [SerializeField] GameObject Note_Object;
    [SerializeField] GameObject Player_State;
    [SerializeField] GameObject Dialogue;
    public GameObject noteCanvas;
    public bool NOTE_done;

    private void Start()
    {
        noteCanvas.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {

        Debug.Log(GameObject.Find("Keypad").GetComponent<Keypad>().Stage_random);

        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                noteCanvas.SetActive(true);
                NOTE_done = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            noteCanvas.SetActive(false);
        }
    }
}
