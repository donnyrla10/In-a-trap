using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private GameObject SlotsParent; //Slots의 부모인 Grid Setting

    private Slots[] slots;  //슬롯들 배열

    [SerializeField]
    public GameObject inventory_canvas; //전체 inventory object

    //연동 Script
    public PlayerOperation operation;

    void Start(){
        OCInventory(false);
        //슬롯들을 slots배열에 할당
        slots = SlotsParent.GetComponentsInChildren<Slots>();
	}

    //Open Close Inventory
    public void OCInventory(bool state){
        inventory_canvas.SetActive(state);  //inventory 열기
        operation.openInventory = state;    //open, close 상태 조작
    }  

    //아이템 습득하기
    public void AcquireItem(Item item){
        //아이템을 저장할 새로운 슬롯 찾기
        for(int i=0; i<slots.Length; i++){
            if(slots[i].items == null){ 
                slots[i].AddItem(item); //빈 슬롯을 찾았다면 AddItem()호출
                return;
            }
        }
    }

}
