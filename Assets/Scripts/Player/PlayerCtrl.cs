using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[RequireComponent(typeof(CharacterController))]
public class PlayerCtrl : MonoBehaviour
{
    [SerializeField] private AudioSource footstepSound;
    //private bool isMove = false;

    private CharacterController characterCtrl; //ĳ���� �̵� ��Ű�� ������Ʈ
    private Status status; //ĳ������ ������ �޾ƿ�

    private KeyCode crouchKey = KeyCode.LeftControl; //Ű �Ҵ�
    private KeyCode runKey = KeyCode.LeftShift; //Ű �Ҵ�
    [SerializeField] private GameObject playerHitBox;
    private GlitchEffect glitchEffect;

    public GameObject healthBar;
    public GameObject gameoverCutscene;

    [SerializeField] private float moveSpd; //�÷��̾��� �̵��ӵ�
    private Vector3 moveForce; //�÷��̾� �̵��� ���̴� Vector

    [SerializeField]
    public float MaxHp;
    [SerializeField]
    public float currHp;

    private float gravity = -9.8f; //�߷�
    private Vector3 _velocity; //�߷¿� ���Ǵ� Vector

    private bool isWalking = false;
    private bool isCrouch = false; //�ɾ� �ִ°� ���ִ°� �Ǻ�
    private bool isRun = false;
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

        //if (other.gameObject.CompareTag("Door"))
        //{
        //    other.GetComponentInParent<Animator>().Play("DoorOpen");
        //}
    }
}
