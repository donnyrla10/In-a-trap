using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ScriptableObject: 데이터들을 저장하는데 사용할 수 있는 데이터 컨테이너 에셋

[CreateAssetMenu(fileName="New Item", menuName="Resources/Item")]
public class Item : ScriptableObject{ //게임 오브젝트에 붙일 필요 없음.
    //아이템 유형
    public enum ItemType{
        special,
        normal,
    }

    public string item_name;    //아이템 이름 - 한글
    public ItemType itemType;   //아이템 유형 [special, normal]
    public Sprite itemImage;    //아이템 이미지 (인벤토리에 띄울)
}
