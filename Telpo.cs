using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Telpo : MonoBehaviour
{
    Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        
        pos = this.gameObject.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "B1_stair")    //1->2
        {
            this.gameObject.transform.position = new Vector3(-6.09f, 2.13f, 1.7025f);
        }

        if (other.tag == "B2_stair")    //2->3
        {
            this.gameObject.transform.position = new Vector3(-5.7018f, 3.564f, 2.8f);
        }

        if (other.tag == "B3_stair")    //3->2
        {
            this.gameObject.transform.position = new Vector3(-6.09f, 2.13f, 1.7025f);
        }

        if (other.tag == "A1_stair")    //1->2
        {
            this.gameObject.transform.position = new Vector3(-8.597f, 4.234f, 8.953f);
        }

        if (other.tag == "A2_stair")    //2->3
        {
            this.gameObject.transform.position = new Vector3(-8.597f, 4.234f, 8.953f);
        }

        if (other.tag == "A_gurm")    //학생회실앞으로이동
        {
            this.gameObject.transform.position = new Vector3(5.7394f, 3.1149f, -0.15f);
        }
    }

}
