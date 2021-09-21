using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{    
    [Tooltip("추적할 대상의 Transform")]
    public Transform targetTransform;
    [Tooltip("카메라와 타겟 사이의 거리 값")]
    public float distance = 3.0f;
    [Tooltip("카메라 회전 속도 값")]
    public float cameraRotateSpeed = 1.0f;
    [Tooltip("얼마나 오래 카메라 떨림(쉐이크)이 나타날지 설정하는 시간 값")]
    public float cameraShakeTime = 0.8f;
    
    float rotateX;
    float rotateY;

    Vector3 pos;
    void Start()
    {        
        targetTransform = targetTransform == null ? GameObject.Find("Player").transform : targetTransform;
        pos = targetTransform.position;
    }
    
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            rotateX += Input.GetAxisRaw("Mouse X") * cameraRotateSpeed;
            rotateY += Input.GetAxisRaw("Mouse Y") * cameraRotateSpeed;
        }

        distance += -Input.GetAxis("Mouse ScrollWheel");

        rotateY = Mathf.Clamp(rotateY, -60f, 60f);
        distance = Mathf.Clamp(distance, 1.5f, 4.5f);

    }
    
    void FixedUpdate()
    {
        //  카메라가 부드럽게 따라가는 코드        
        pos = Vector3.Lerp(pos, targetTransform.position, 10f * Time.fixedDeltaTime);
        //  정확하게 따라가는 코드
        //pos = targetTransform.position;
    }
    
    private void LateUpdate()
    {                
        transform.rotation = Quaternion.Euler(-rotateY, rotateX, 0);                
        transform.position = pos + transform.rotation * new Vector3(0, 1, -distance);
    }

    /// <summary>
    /// 추적 대상을 현재 대상에서 인자 값으로 받아온 타켓 트랜스폼으로 바꾸는 함수
    /// </summary>
    /// <param name="target"></param>
    public void ChangeTarget(Transform target)
    {
        targetTransform = target;
    }
}
