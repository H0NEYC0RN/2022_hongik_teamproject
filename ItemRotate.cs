using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRotate : MonoBehaviour
{
    float rotSpeed = 50f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // ������ ���ۺ���
        transform.Rotate(new Vector3(0, rotSpeed * Time.deltaTime, 0));
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player") // �÷��̾ �����ۿ� ������ ������ ȹ��(���߿� ��ȣ�ۿ� Ű �Է����� ���� �ʿ�)
        {
            Debug.Log("Item Obtained");
            Destroy(gameObject);
        }
    }
}
