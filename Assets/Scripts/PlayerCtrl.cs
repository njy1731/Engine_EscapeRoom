using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerCtrl : MonoBehaviour
{
    private FirstCamera rotateToMouse; // ���콺 �̵����� ī�޶� ȸ��
    private CharacterController characterCtrl; //ĳ���� �̵� ��Ű�� ������Ʈ

    [SerializeField] private LayerMask keyLayer; //�������� ���̾� ����ũ

    private KeyCode crouchKey = KeyCode.LeftControl; //Ű �Ҵ�
    private KeyCode runKey = KeyCode.LeftShift;

    private Status status; //ĳ������ ������ �޾ƿ�

    [SerializeField] private float moveSpd; //�÷��̾��� �̵��ӵ�
    private Vector3 moveForce; //�÷��̾� �̵��� ���̴� Vector

    private float gravity = -9.8f; //�߷�
    private Vector3 _velocity; //�߷¿� ���Ǵ� Vector

    private bool isCrouch = false; //�ɾ� �ִ°� ���ִ°� �Ǻ�
    [SerializeField] Transform playerCam = null; //�÷��̾ ������ ī�޶��� �̵�

    /// <summary>
    /// �÷��̾� �ɱ⿡ �ʿ��� �����͵�
    /// </summary>
    [Range(0, 1.0f)]
    [SerializeField] private float crouchSpd = 0.3f;
    [SerializeField] private float crouchHeight = 2f;
    [SerializeField] private float standHeight = 1f;

    //�÷��̾� �ӵ��� ������Ƽ�� ����
    public float MoveSpd
    {
        set => moveSpd = Mathf.Max(0, value);
        get => moveSpd;
    }

    void Start()
    {
        characterCtrl = GetComponent<CharacterController>();
    }

    void Update()
    {
        isCrouch = Input.GetKey(crouchKey); //Boolean ����?���� ��� (������ true �������� false)
        RotateMouse(); //�÷��̾� ȸ��
        MovePlayer(); //���콺 �̵�
        setGravity(); //�÷��̾� �߷� ����
    }

    /// <summary>
    /// �÷��̾ ������ ����
    /// </summary>
    private void FixedUpdate()
    {
        var desiredHeight = isCrouch ? crouchHeight : standHeight;

        if (characterCtrl.height != desiredHeight)
        {
            CrouchPlayer(desiredHeight);

            var campos = playerCam.transform.position;
            campos.y = characterCtrl.height;
        }
    }

    /// <summary>
    /// �÷��̾ �ɴ� ���� �ε巴�� ����
    /// </summary>
    /// <param name="height">���̰� (ĳ���� ��Ʈ�ѷ�)</param>
    private void CrouchPlayer(float height)
    {
        characterCtrl.height = Mathf.Lerp(characterCtrl.height, height, crouchSpd);
        characterCtrl.center = Vector3.Lerp(characterCtrl.center, new Vector3(0, 0, 0), crouchSpd);
    }

    /// <summary>
    /// �����̴� ���� �Լ�
    /// </summary>
    /// <param name="direction">���� ������ ����</param>
    public void MoveTo(Vector3 direction)
    {
        direction = transform.rotation * new Vector3(direction.x, 0, direction.z);

        moveForce = new Vector3(direction.x * moveSpd, moveForce.y, direction.z * moveSpd);
    }

    /// <summary>
    /// ĳ��
    /// </summary>
    void Awake()
    {
        rotateToMouse = GetComponent<FirstCamera>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        status = GetComponent<Status>();
    }

    /// <summary>
    /// �÷��̾��� �߷� �Լ�
    /// </summary>
    void setGravity()
    {
        _velocity.y += gravity * Time.deltaTime;
        characterCtrl.Move(_velocity);
    }

    /// <summary>
    /// �÷��̾ ���콺�� �����϶� ȭ���� �������ִ� �Լ�
    /// </summary>
    void RotateMouse()
    {


        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        rotateToMouse.UpdateRotate(mouseX, mouseY);
    }

    /// <summary>
    /// �÷��̾��� ������, �޸����� ���� �Լ�
    /// </summary>
    void MovePlayer()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        if(x != 0 || z != 0)
        {
            bool isRun = false;
            isRun = Input.GetKey(runKey);
            MoveSpd = isRun == true ? status.RunSpd : status.WalkSpd;
        }

        characterCtrl.Move(moveForce * Time.deltaTime);
        MoveTo(new Vector3(x, 0, z).normalized);
    }

    /// <summary>
    /// �������� ����ĳ��Ʈ�� �޾Ƽ� Ȯ���ϴ� �Լ�
    /// </summary>
    void CheckItem()
    {
        RaycastHit raycast;
        if (Physics.Raycast(transform.position, transform.forward, out raycast, 3f, keyLayer))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {

            }
        }

        else
        {

        }
    }
}
