using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstCamera : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 100f; //마우스가 움직이는 속도 = 감도
    [SerializeField] private Transform player = null; //플레이어를 바라보는 방향으로 움직이기위해 사용하는 변수
    float xRotation = 0f; //x의 회전값

    private void Update()
    {
        UpdateCamera();
    }

    /// <summary>
    /// 플레이어가 마우스를 움직일때 화면(카메라를)을 움직여주는 함수
    /// </summary>
    void UpdateCamera()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        player.Rotate(Vector3.up * mouseX);
    }
}
