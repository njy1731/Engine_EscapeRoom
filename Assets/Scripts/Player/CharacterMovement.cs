using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float moveSpd;
    private Vector3 moveForce;

    private float gravity = -9.8f;
    private Vector3 _velocity;

    private bool isCrouch = false;
    [SerializeField] Transform playerCam = null;

    [Range(0, 1.0f)]
    [SerializeField] private float crouchSpd = 0.3f;
    [SerializeField] private float crouchHeight = 2f;
    [SerializeField] private float standHeight = 1f;

    private KeyCode crouchKey = KeyCode.LeftControl;

    //[SerializeField] private PostProcessVolume volume;
    //[SerializeField] private PostProcessProfile profile;

    public float MoveSpd
    {
        set => moveSpd = Mathf.Max(0, value);
        get => moveSpd;
    }

    private CharacterController characterCtrl;

    void Start()
    {
        characterCtrl = GetComponent<CharacterController>();
        //volume = GetComponent<PostProcessVolume>();
        //profile = GetComponent<PostProcessProfile>();
    }

    private void FixedUpdate()
    {
        var desiredHeight = isCrouch ? crouchHeight : standHeight;

        if (characterCtrl.height != desiredHeight)
        {
            Height(desiredHeight);

            var campos = playerCam.transform.position;
            campos.y = characterCtrl.height;
        }
    }

    private void Height(float height)
    {
        characterCtrl.height = Mathf.Lerp(characterCtrl.height, height, crouchSpd);
        characterCtrl.center = Vector3.Lerp(characterCtrl.center, new Vector3(0, 0, 0), crouchSpd);
    }

    void Update()
    {
        characterCtrl.Move(moveForce * Time.deltaTime);
        isCrouch = Input.GetKey(crouchKey);
        _velocity.y += gravity * Time.deltaTime;
        characterCtrl.Move(_velocity);
    }

    public void MoveTo(Vector3 direction)
    {
        direction = transform.rotation * new Vector3(direction.x, 0, direction.z);

        moveForce = new Vector3(direction.x * moveSpd, moveForce.y, direction.z * moveSpd);
    }
}
