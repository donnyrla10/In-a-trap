using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    public Image panel; //검은 화면
    
    void Awake(){
        StartCoroutine(CoFadeOut());
    }

    IEnumerator CoFadeOut(){
        Color color = panel.color;
        while(color.a > 0f){
            color.a -= Time.deltaTime / 1f;
            panel.color = color;
            if(color.a <= 0f) color.a = 0f;

            yield return null;
        }
        panel.color = color;
    }

}
