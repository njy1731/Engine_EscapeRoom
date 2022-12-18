using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[RequireComponent(typeof(CharacterController))]
public class PlayerCtrl : MonoBehaviour
{
    [Header("Player Sound Info")]
    [SerializeField] private AudioSource footstepSound; //플레이어 발소리

    [Header("Player Info")]
    [SerializeField] private GameObject playerHitBox; //플레이어 피격범위
    [SerializeField] Transform playerCam = null; //플레이어가 앉을때 카메라의 이동
    private CharacterController characterCtrl; //캐릭터 이동 시키는 컴포넌트
    private Status status; //캐릭터의 스텟을 받아옴
    private GlitchEffect glitchEffect; //글리치 효과
    private CameraShake cameraShake; //카메라 흔들림효과

    [Header("Player Interact Key Info")]
    private KeyCode crouchKey = KeyCode.LeftControl; //키 할당
    private KeyCode runKey = KeyCode.LeftShift; //키 할당

    [Header("Player HP Info")]
    public GameObject healthBar; //플레이어 체력바
    public GameObject gameoverCutscene; //게임오버 컷신
    public float MaxHp; //플레이어 최대 HP
    public float currHp; //플레이어 현재 HP

    [Header("Player Move Info")]
    [SerializeField] private float moveSpd; //플레이어의 이동속도
    private Vector3 moveForce; //플레이어 이동에 쓰이는 Vector
    private float gravity = -9.8f; //중력값
    private Vector3 _velocity; //중력에 사용되는 Vector

    [Header("Player Bool Info")]
    private bool isWalking = false; //플레이어가 움직이고있는가?
    private bool isCrouch = false; //앉아 있는가 서있는가 판별
    private bool isRun = false; //플레이어가 달리고있는가?

    /// <summary>
    /// 플레이어 앉기에 필요한 데이터들
    /// </summary>
    [Header("Player Crouch Info")]
    [Range(0, 1.0f)]
    [SerializeField] private float crouchSpd = 0.1f; //앉기, 일어나는 속도
    [SerializeField] private float crouchHeight = 1f; //앉았을때 플레이어의 높이
    [SerializeField] private float standHeight = 2f; //서있을때 플레이어의 높이

    //플레이어 속도를 프로퍼티로 받음
    public float MoveSpd
    {
        set => moveSpd = Mathf.Max(0, value);
        get => moveSpd;
    }

    /// <summary>
    /// 캐싱
    /// </summary>
    void Awake()
    {
        StartCoroutine(FootStepStart());
        characterCtrl = GetComponent<CharacterController>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        status = GetComponent<Status>();
        currHp = MaxHp;
        cameraShake = GetComponent<CameraShake>();
        glitchEffect = GetComponentInChildren<GlitchEffect>();
    }

    void Update()
    {
        isCrouch = Input.GetKey(crouchKey); //Boolean 형식? 으로 사용 (앉으면 true 서있으면 false)
        MovePlayer(); //마우스 이동
        setGravity(); //플레이어 중력 적용
    }

    private void FixedUpdate()
    {
        PlayerCrouch();
    }

    /// <summary>
    /// 플레이어가 앉았을때 카메라의 위치와 플레이어의 높이를 조정해주는 함수
    /// </summary>
    private void PlayerCrouch()
    {
        var desiredHeight = isCrouch ? crouchHeight : standHeight; //플레이어가 앉는 것을 isCrouch Bool 변수에 앉았을때의 높이와 서있을때의 높이를 true, false에 따라 다르게 설정해줌

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
    /// 플레이어의 중력 함수
    /// </summary>
    void setGravity()
    {
        _velocity.y += gravity * Time.deltaTime;
        characterCtrl.Move(_velocity);
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
    /// 플레이어의 움직임, 달리기의 적용 함수
    /// </summary>
    void MovePlayer()
    {

        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        
        if (x != 0 || z != 0)
        {
            isRun = Input.GetKey(runKey);
            MoveSpd = isRun == true ? status.RunSpd : status.WalkSpd;
        }

        Vector3 moveDir = new Vector3(x, 0, z).normalized;
        isWalking = moveDir != Vector3.zero;

        characterCtrl.Move(moveForce * Time.deltaTime);
        MoveTo(moveDir);
    }

    /// <summary>
    /// 플레이어가 움질일때 발소리를 내는 함수
    /// </summary>
    /// <returns></returns>
    private IEnumerator FootStepStart()
    {
        while (true)
        {
            yield return new WaitUntil(() => isWalking);
            footstepSound.PlayOneShot(footstepSound.clip);
            footstepSound.volume = Random.Range(0.7f, 1f);
            footstepSound.pitch = Random.Range(1f, 1.1f);
            yield return new WaitForSeconds(isRun ? 0.5f : 1f);
        }
    }

    public void PlayerDamage(float damage)
    {
        currHp -= damage;
        playerHitBox.SetActive(false);
        Invoke("hitboxOn", 1f);
        if(currHp <= 0 )
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        glitchEffect.flipIntensity = 1f;
        glitchEffect.intensity = 1f;
        glitchEffect.colorIntensity = 1f;
        healthBar.SetActive(false);
        StartCoroutine(cameraShake.Shake());
        gameoverCutscene.SetActive(true);
    }

    private void hitboxOn()
    {
        playerHitBox.SetActive(true);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("HidePoint") == true)
        {
            if (other.GetComponentInChildren<ClosetCtrl>() != null) 
            {
                if(other.GetComponentInChildren<ClosetCtrl>().opened == true)
                {
                    playerHitBox.SetActive(true);
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
