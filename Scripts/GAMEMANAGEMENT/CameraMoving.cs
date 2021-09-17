using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    public float smoothTimeX, smoothTimeY;
    public Vector3 velocity;
    public GameObject player;
    public Vector3 minPos, maxPos;
    public bool bound;

    //캐릭터를 따라 카메라 이동
    void FixedUpdate(){
        float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x,
        ref velocity.x, smoothTimeX);
        //Math.SmoothDamp: 천천히 값을 증가시킨다.
        float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y,
        ref velocity.y, smoothTimeY);
        // float posZ = Mathf.SmoothDamp(transform.position.z, player.transform.position.z,
        // ref velocity.z, smoothTimeZ);

        //카메라 이동
        //다락방 등장하면 카메라 y축 제한 풀어주기
        transform.position = new Vector3(posX, posY, -20);

        //카메라 제한범위
        if(bound){
            //Math.Clamp(현재, 최대, 최소): 현재값이 최대값까지만 반환하주고 최소값보다 작으면 최소값까지만 반환
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minPos.x, maxPos.x),
            //다락방 등장하면 카메라 y축 제한 풀어주기
            Mathf.Clamp(transform.position.y, minPos.y, maxPos.y),
            // 0,
            // Mathf.Clamp(transform.position.z, minPos.z, maxPos.z)
            -20);
        }
    }

}
