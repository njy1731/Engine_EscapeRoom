using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerCtrl : MonoBehaviour
{
    private CharacterController characterCtrl; //ĳ���� �̵� ��Ű�� ������Ʈ
    private Status status; //ĳ������ ������ �޾ƿ�

    private KeyCode crouchKey = KeyCode.LeftControl; //Ű �Ҵ�
    private KeyCode runKey = KeyCode.LeftShift; //Ű �Ҵ�
    public GameObject playerHitBox;

    public GameObject closet;

    [SerializeField] private float moveSpd; //�÷��̾��� �̵��ӵ�
    private Vector3 moveForce; //�÷��̾� �̵��� ���̴� Vector

    [SerializeField]
    private int MaxHp;
    [SerializeField]
    private int currHp;

    private float gravity = -9.8f; //�߷�
    private Vector3 _velocity; //�߷¿� ���Ǵ� Vector

    public ClosetCtrl closetCtrl;

    private bool isCrouch = false; //�ɾ� �ִ°� ���ִ°� �Ǻ�
    [SerializeField] Transform playerCam = null; //�÷��̾ ������ ī�޶��� �̵�

    /// <summary>
    /// �÷��̾� �ɱ⿡ �ʿ��� �����͵�
    /// </summary>
    [Range(0, 1.0f)]
    [SerializeField] private float crouchSpd = 0.1f;
    [SerializeField] private float crouchHeight = 2f;
    [SerializeField] private float standHeight = 1f;

    private CameraShake cameraShake;

    //�÷��̾� �ӵ��� ������Ƽ�� ����
    public float MoveSpd
    {
        set => moveSpd = Mathf.Max(0, value);
        get => moveSpd;
    }

    /// <summary>
    /// ĳ��
    /// </summary>
    void Awake()
    {
        characterCtrl = GetComponent<CharacterController>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        status = GetComponent<Status>();
        currHp = MaxHp;
        cameraShake = GetComponent<CameraShake>();
        closetCtrl = closet.GetComponentInChildren<ClosetCtrl>();
    }

    void Update()
    {
        isCrouch = Input.GetKey(crouchKey); //Boolean ����?���� ��� (������ true �������� false)
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
    /// �÷��̾��� �߷� �Լ�
    /// </summary>
    void setGravity()
    {
        _velocity.y += gravity * Time.deltaTime;
        characterCtrl.Move(_velocity);
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

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("NonLockedDoor"))
    //    {
    //        other.gameObject.GetComponent<Animator>().Play("DoorOpen");
    //    }
    //}

    public void PlayerDamage(int damage)
    {
        currHp -= damage;
        if(currHp <= 0 )
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        StartCoroutine(cameraShake.Shake());
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("HidePoint") == true)
        {
            if (other.GetComponentInChildren<ClosetCtrl>() != null) 
            {
                if(other.GetComponentInChildren<ClosetCtrl>().opened == true)
                {
                    
                }

            }
            else
            {
                playerHitBox.SetActive(false);
            }
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("HidePoint") == true)
        {
            playerHitBox.SetActive(true);
        }

    }
}
