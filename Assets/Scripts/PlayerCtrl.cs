using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerCtrl : MonoBehaviour
{
    private FirstCamera rotateToMouse; // 마우스 이동으로 카메라 회전
    private CharacterController characterCtrl;

    [SerializeField] private LayerMask keyLayer; //아이템의 레이어 마스크

    private KeyCode crouchKey = KeyCode.LeftControl; //키 할당
    private KeyCode runKey = KeyCode.LeftShift;

    private Status status; //캐릭터의 스텟을 받아옴

    [SerializeField] private float moveSpd; //플레이어의 이동속도
    private Vector3 moveForce; //플레이어 이동에 쓰이는 Vector

    private float gravity = -9.8f; //중력
    private Vector3 _velocity; //중력에 사용되는 Vector

    private bool isCrouch = false; //앉아 있는가 서있는가 판별
    [SerializeField] Transform playerCam = null; //플레이어가 앉을때 카메라의 이동

    /// <summary>
    /// 플레이어 앉기에 필요한 데이터들
    /// </summary>
    [Range(0, 1.0f)]
    [SerializeField] private float crouchSpd = 0.3f;
    [SerializeField] private float crouchHeight = 2f;
    [SerializeField] private float standHeight = 1f;

    //플레이어 속도를 프로퍼티로 받음
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
        isCrouch = Input.GetKey(crouchKey); //Boolen 형식으로 사용 (앉으면 true 서있으면 false)
        RotateMouse(); //플레이어 회전
        MovePlayer(); //마우스 이동
        getGravity(); //플레이어 중력 적용
    }

    /// <summary>
    /// 플레이어가 앉을때 사용됨
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
    /// 플레이어가 앉는 것을 부드럽게 해줌
    /// </summary>
    /// <param name="height">높이값 (캐릭터 컨트롤러)</param>
    private void CrouchPlayer(float height)
    {
        characterCtrl.height = Mathf.Lerp(characterCtrl.height, height, crouchSpd);
        characterCtrl.center = Vector3.Lerp(characterCtrl.center, new Vector3(0, 0, 0), crouchSpd);
    }

    /// <summary>
    /// 움직이는 로직 함수
    /// </summary>
    /// <param name="direction">현재 가려는 방향</param>
    public void MoveTo(Vector3 direction)
    {
        direction = transform.rotation * new Vector3(direction.x, 0, direction.z);

        moveForce = new Vector3(direction.x * moveSpd, moveForce.y, direction.z * moveSpd);
    }

    /// <summary>
    /// 캐싱
    /// </summary>
    void Awake()
    {
        rotateToMouse = GetComponent<FirstCamera>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        status = GetComponent<Status>();
    }

    /// <summary>
    /// 플레이어의 중력 함수
    /// </summary>
    void getGravity()
    {
        _velocity.y += gravity * Time.deltaTime;
        characterCtrl.Move(_velocity);
    }

    /// <summary>
    /// 플레이어가 마우스를 움직일때 화면을 움직여주는 함수
    /// </summary>
    void RotateMouse()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        rotateToMouse.UpdateRotate(mouseX, mouseY);
    }

    /// <summary>
    /// 플레이어의 움직임, 달리기의 적용 함수
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
        MoveTo(new Vector3(x, 0, z));
    }

    /// <summary>
    /// 아이템을 레이캐스트로 받아서 확인하는 함수
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
