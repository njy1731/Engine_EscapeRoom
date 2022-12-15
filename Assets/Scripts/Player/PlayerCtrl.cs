using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[RequireComponent(typeof(CharacterController))]
public class PlayerCtrl : MonoBehaviour
{
    [SerializeField] private AudioSource footstepSound;
    //private bool isMove = false;

    private CharacterController characterCtrl; //캐릭터 이동 시키는 컴포넌트
    private Status status; //캐릭터의 스텟을 받아옴

    private KeyCode crouchKey = KeyCode.LeftControl; //키 할당
    private KeyCode runKey = KeyCode.LeftShift; //키 할당
    [SerializeField] private GameObject playerHitBox;
    private GlitchEffect glitchEffect;

    public GameObject healthBar;
    public GameObject gameoverCutscene;

    [SerializeField] private float moveSpd; //플레이어의 이동속도
    private Vector3 moveForce; //플레이어 이동에 쓰이는 Vector

    [SerializeField]
    public float MaxHp;
    [SerializeField]
    public float currHp;

    private float gravity = -9.8f; //중력
    private Vector3 _velocity; //중력에 사용되는 Vector


    private bool isCrouch = false; //앉아 있는가 서있는가 판별
    [SerializeField] Transform playerCam = null; //플레이어가 앉을때 카메라의 이동


    /// <summary>
    /// 플레이어 앉기에 필요한 데이터들
    /// </summary>
    [Range(0, 1.0f)]
    [SerializeField] private float crouchSpd = 0.1f;
    [SerializeField] private float crouchHeight = 2f;
    [SerializeField] private float standHeight = 1f;

    private CameraShake cameraShake;

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
        //footstepSound = GetComponent<AudioSource>();
        characterCtrl = GetComponent<CharacterController>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        status = GetComponent<Status>();
        currHp = MaxHp;
        cameraShake = GetComponent<CameraShake>();
        glitchEffect = GetComponentInChildren<GlitchEffect>();
        //footstepSound.Play();
    }

    void Update()
    {
        isCrouch = Input.GetKey(crouchKey); //Boolean 형식?으로 사용 (앉으면 true 서있으면 false)
        MovePlayer(); //마우스 이동
        setGravity(); //플레이어 중력 적용
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
            bool isRun = false;
            isRun = Input.GetKey(runKey);
            MoveSpd = isRun == true ? status.RunSpd : status.WalkSpd;
        }

        Vector3 moveDir = new Vector3(x, 0, z).normalized;

        if (moveDir != Vector3.zero)
        {
            StartCoroutine(FootStepStart());
        }

        else StartCoroutine(FootStepStop());

        characterCtrl.Move(moveForce * Time.deltaTime);
        MoveTo(moveDir);
    }

    private IEnumerator FootStepStart()
    {
        footstepSound.enabled = true;
        yield return new WaitForSeconds(1f);
        footstepSound.volume = Random.Range(0.7f, 1f);
        footstepSound.pitch = Random.Range(0.8f, 1.1f);
    }

    private IEnumerator FootStepStop()
    {
        footstepSound.enabled = false;
        yield return new WaitForSeconds(1f);
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

        //if (other.gameObject.CompareTag("Door"))
        //{
        //    other.GetComponentInParent<Animator>().Play("DoorOpen");
        //}
    }
}
