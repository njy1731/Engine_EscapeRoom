using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstCamera : MonoBehaviour
{
    [SerializeField] private Transform player = null; //�÷��̾ �ٶ󺸴� �������� �����̱����� ����ϴ� ����
    public static float mouseSensitivity = 100f; //���콺�� �����̴� �ӵ� = ����
    float xRotation = 0f; //x�� ȸ����

    private void Awake()
    {
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        UpdateCamera();
    }

    /// <summary>
    /// �÷��̾ ���콺�� �����϶� ȭ��(ī�޶�)�� �������ִ� �Լ�
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
