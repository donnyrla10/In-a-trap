using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    int menu_number; //1:start, 2:continue, 3:exit
    Vector2 pos;

    //panel
    public Image panel; //검은 화면

    void Awake(){
        pos = transform.position;
        menu_number = 1;
    }

    void Update(){
        //Debug.Log("x값: "+transform.position.x);
        //Debug.Log("y값: "+transform.position.y);
        //화살표 상 누르면 START, CONTINUE 중 하나 선택할 수 있음
        //START 위로는 더 이상 올라가지 않음. 
        if(Input.GetKeyUp(KeyCode.UpArrow)){
            pos.y += 100;
            //start menu
            if(pos.y >= 300){
                Debug.Log("menu1");
                menu_number = 1;
                pos.y = 300;
                pos.x = 880;
                Debug.Log("no more [up]!");
            }
            //continue menu
            else if(pos.y == 200){
                Debug.Log("Up_menu2");
                menu_number = 2;
                pos.x = 800;
            }
        }

        //화살표 하 누르면 CONTINUE, EXIT 중 하나 선택할 수 있음
        //EXIT 아래로는 더 이상 내려가지 않음.
        else if(Input.GetKeyUp(KeyCode.DownArrow)){
            pos.y -= 100;
            //exit menu
            if(pos.y <= 100){
                Debug.Log("menu3");
                menu_number = 3;
                pos.y = 100;
                pos.x = 930;
                Debug.Log("no more [down]!");
            }
            //continue menu
            else if(pos.y == 200){
                Debug.Log("Down_menu2");
                menu_number = 2;
                pos.x = 800; 
            }
        }
        transform.position = new Vector2(pos.x, pos.y);
        
        if(Input.GetKeyUp(KeyCode.Space)){
            if(menu_number == 1){ //START_MENU
                Debug.Log("start menu");
                //첫 게임 화면으로 씬 전환
                FadeInOut();
            
            }else if(menu_number == 2){ //CONTINUE MENU
                Debug.Log("continue menu");
                //저장 시스템 UI 등장 OR 저장 시스템 Scene으로 전환
            }else if(menu_number == 3){ //EXIT MENU
                //게임 창 끄기
                UnityEditor.EditorApplication.isPlaying = false;
                //Application.Quit();
                Debug.Log("exit menu");
            }
        }

        if(Input.GetKeyUp(KeyCode.O)){
            //옵션 ui 등장
        }
    }

    void FadeInOut(){
        StartCoroutine(CoFadeIn());
    }

    IEnumerator CoFadeIn(/*System.Action nextEvent = null*/){
        Color color = panel.color;
        while(color.a < 1f){
            color.a += Time.deltaTime / 1.0f;
            panel.color = color;

            if(color.a >= 1f) color.a = 1f;

            yield return null;
        }
        panel.color = color;
        SceneManager.LoadScene("BABYROOM");        
    }
}
