using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOperation : MonoBehaviour
{
    //Move var
    public float speed = 5f; //이동속도
    bool flip;        //좌우반전
    SpriteRenderer rend;
    public GameObject winter_L;
    public GameObject winter_R;

    //배경 이미지 변경
    //public Image panel; //검은 화면
    //public GameObject camera;
    //public GameObject CameraScript;

    //Jump var
    public float jump_power = 10f; //점프력
    bool isGround = true;  //2단 점프 이상 차단
    int jump_count = 1; 
    Rigidbody rigid;

    //Take var
    GameObject takeItem;  //부딪힌 아이템 수집
    bool isItem = false;  //아이템이랑 부딪혔을 경우
    public Inventory inventory; //inventory와 연동(item 수집,사용)
    public bool openInventory; //inventory가 열려있는지 확인

    void Awake(){
        rend = GetComponentInChildren<SpriteRenderer>();
        rigid = GetComponent<Rigidbody>();
        winter_R.SetActive(false);
        winter_L.SetActive(true);
        // winter_L = GetComponent<Light2D>();
        // winter_R = GetComponent<Light2D>();
        openInventory = false;
        //camera = GameObject.Find("Main Camera");
    }

    void Update(){
        Speed();        
    }

    void FixedUpdate(){
        Move();
        Jump();
        Take();

        //if you press the 'i' and inventory window is closed, inventory will be opened. 
        if(Input.GetKeyDown(KeyCode.I) && !openInventory){
            inventory.OCInventory(true);
        }
        //if you press the 'Q' and inventory window is opened, inventory will be closed.
        else if(Input.GetKeyDown(KeyCode.Q) && openInventory){
            inventory.OCInventory(false);
        }
    }

    void Speed(){
        //shift키를 누르는 동안 스피드 14
        //shift키에서 손 떼면 스피드 7
        if(Input.GetKeyDown(KeyCode.LeftShift)){
            speed = 10f;
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift)){
            speed = 5f;
        }
    }

    void Move(){
        float X = Input.GetAxisRaw("Horizontal");
        if(Input.GetAxisRaw("Horizontal") > 0){ //오른쪽 방면
            flip = true; 
            winter_L.SetActive(false);
            winter_R.SetActive(true);
        }
        else if(Input.GetAxisRaw("Horizontal") < 0){ //왼쪽 방면
            flip = false;
            winter_L.SetActive(true);
            winter_R.SetActive(false);
        }
        rend.flipX = flip;
        float Z = Input.GetAxisRaw("Vertical");
        transform.Translate(new Vector3(X,0,Z)*Time.deltaTime*speed);
    }

    void Jump(){
        if(isGround){
            jump_count = 1;
            if(Input.GetKeyDown(KeyCode.Space)){
                if(jump_count == 1){
                    rigid.AddForce(Vector3.up * jump_power, ForceMode.Impulse);
                    isGround = false;
                    jump_count = 0;           
                }
            }
        }
    }

    void Take(){
        //if object's tag was the item and you pressed the 'x', 
        if(isItem){
            if(Input.GetKeyDown("x")){
                //audio
                inventory.AcquireItem(takeItem.transform.GetComponent<ItemPickUp>().items);
                takeItem.SetActive(false);
                isItem = false;
            }
        }
    }

    private void OnCollisionEnter(Collision col){
        //점프시, 바닥에 닿았는지 확인 용
        if(col.gameObject.tag == "ground"){
            // Debug.Log("바닥에 닿음");
            isGround = true; //바닥에 닿으면 isGround == true
            jump_count = 1;  //점프 횟수 초기화 1
        }
        //아이템 
        else if(col.gameObject.tag == "item"){
            Debug.Log("collision the item!");
            takeItem = col.gameObject;
            isItem = true;
        }
    }

    private void OnCollisionExit(Collision col){
        isItem = false;
    }


    // void OnTriggerStay2D(Collider2D other){
    //     if(other.tag == "main_rw"){
    //         Debug.Log("Trigger");
    //         //만약 main에서 오른쪽으로 이동하면
    //         // 1. Fade in/out
    //         ChangeBG(new Vector2(26.0f, gameObject.transform.position.y));
    //     }
    //     // else if(other.tag == "main_lw"){
    //     // }
    // }

    // void ChangeBG(Vector2 pos){
    //     StartCoroutine(FadeIn());
    //     gameObject.transform.position = pos;
    //     StartCoroutine(FadeOut());
    //     // 2. 카메라 이동:  3.88 -> 34.7
    //     camera.transform.position = new Vector2(34.7f, 0.0f);
    //     // 3. 카메라 제한 범위 변경
    //     camera.GetComponent<CameraTracking>().minPos = new Vector3(34.7f, 0.0f, 0.0f);
    //     camera.GetComponent<CameraTracking>().maxPos = new Vector3(45.2f, 0.0f, 0.0f);
    // }

    // IEnumerator FadeIn(){
    //     Color color = panel.color;
    //     while(color.a < 1f){
    //         color.a += Time.deltaTime / 0.6f;
    //         panel.color = color;
    //         if(color.a >= 1f) color.a = 1f;

    //         yield return null;
    //     }
    //     panel.color = color;
    // }

    // IEnumerator FadeOut(){
    //     Color color = panel.color;
    //     while(color.a > 0f){
    //         color.a -= Time.deltaTime / 0.99f;
    //         panel.color = color;
    //         if(color.a <= 0f) color.a = 0f;

    //         yield return null;
    //     }
    //     panel.color = color;
    // }
}
