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
        // 아이템 빙글빙글
        transform.Rotate(new Vector3(0, rotSpeed * Time.deltaTime, 0));
        
        // 스페이스바로 물건 줍기
        if (isPickup && Input.GetKeyDown(KeyCode.Space))
        {
            PickUp();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player") // 플레이어가 아이템에 닿으면 아이템 획득(나중에 상호작용 키 입력으로 수정 필요)
        {
            Debug.Log("Item Obtained");
            isPickup = true;
        }
    }
    
    public void PickUp()
    {
        pickUpText.gameObject.SetActive(true);
        Destroy(gameObject);
    }
}
