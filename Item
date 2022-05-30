using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Item", menuName = "New Item/item")]
//Create > New Item > Item (에셋으로 생성가능)
public class Item : ScriptableObject // 게임 오브젝트 붙일 필요 X 
{
    public enum ItemType  // 아이템 유형
    {
        Equipment, //장비
        Used,      //소모품
        Ingredient,//재료 등등 원하는 유형 추가 가능
        ETC,
    }

    public string itemName; // 아이템의 이름
    public ItemType itemType; // 아이템 유형
    public Sprite itemImage; // 인벤토리 안에서 띄울 아이템 이미지
    public GameObject itemPrefab;  // 아이템의 프리팹 (아이템 생성시 프리팹으로)
}
