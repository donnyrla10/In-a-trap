using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slots : MonoBehaviour
{
    public Item items;     //획득한 아이템
    public Image itemImage; //획득한 아이템 이미지

    // public Items fitItems;     //장착 아이템
    // public Image fitItemImage; //장착 아이템 이미지

    //아이템 이미지 투명도 조절
    //아이템이 없는 슬롯이면 아이템 이미지 Item_image의 현재 sprite 이미지도 할당되어 있지 않고 투명도가 0인 상태이기 때문에
    //아이템이 슬롯에 추가되면 투명도를 다시 불투명하게 올려줘야 한다.
    //SetColor(0) : 투명하게, SetColor(1) : 불투명하게
    private void SetColor(Image thisImage, float _alpha){
        Color color = thisImage.color;
        color.a = _alpha;
        thisImage.color = color;
    }

    //인벤토리에 새로운 아이템 슬롯 추가
    public void AddItem(Item _item){
        //아이템, 아이템 이름, 아이템 개수, 아이템 이미지 sprite 할당
        items = _item;
        itemImage.sprite = items.itemImage;
        SetColor(itemImage, 1);  //슬롯에 아이템이 들어왔으니, 불투명하게.
    }


    //해당 슬롯을 인벤토리에서 삭제
    public void ClearSlot(){
        //아이템, 개수, 이미지 초기화
        items = null;
        itemImage.sprite = null;
        SetColor(itemImage, 0);      //아이템 이미지를 투명하게.
    }

    //아이템 장착하기
    // public void FitItem(Items _fititem){
    //     Debug.Log("fit the item");
    //     fitItems = _fititem;
    //     firItemImage.sprite = fitItems.fitItemImage;
    //     SetColor(fitItemImage, 1); //장착아이템 ui 불투명하게
    // }

    //아이템 사용하기
    public void UseItem(){ 
        Debug.Log("use the item");
        //SetColor(fitItemImage, 0); //장착아이템 ui 투명하게

        //item 특징만 모아놓은 script의 함수로 연동해서 보내기.
        ClearSlot();

        //면역제라면
        // if(items.itemType == Items.ItemType.pill){
        //     playerState.SetHP(5, 0);
        //     Debug.Log("use pill");
        //     SetSlotCount(-1);    
        // }
    }

}
