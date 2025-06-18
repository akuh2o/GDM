using System;
using UnityEngine;

public class playermove : MonoBehaviour
{
    [SerializeField] private float sensitivity = 5.0f;
    [SerializeField] private float walkSpeed = 0f;
    [SerializeField] private float crouchSpeed = 0f;
    [SerializeField] private float speedBoost = 0f;

    private float _speed = 0f;
    private float rotationX = 0.0f;
    private float rotationY = 0.0f;
    private float _posx;
    private float _posz;
    private float _posy;

    private bool isCrouching = false;

    private Animator animator;

    [SerializeField] private AudioClip walkClip;
    [SerializeField] private AudioClip jumpClip;

    private AudioSource footstepAudioSource;
    private AudioSource jumpAudioSource;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        animator = GetComponent<Animator>();

        footstepAudioSource = gameObject.AddComponent<AudioSource>();
        footstepAudioSource.loop = true;
        footstepAudioSource.playOnAwake = false;

        jumpAudioSource = gameObject.AddComponent<AudioSource>();
        jumpAudioSource.loop = false;
        jumpAudioSource.playOnAwake = false;
    }

    void Update()
    {
        isCrouching = Input.GetKey(KeyCode.LeftControl);

        if (isCrouching)
        {
            _speed = crouchSpeed;
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            _speed = speedBoost;
        }
        else
        {
            _speed = walkSpeed;
        }

        animator.SetBool("isCrouching", isCrouching);

        rotationX += Input.GetAxis("Mouse X") * sensitivity;
        rotationY -= Input.GetAxis("Mouse Y") * sensitivity;
        rotationY = Mathf.Clamp(rotationY, -30f, 30f);

        transform.localRotation = Quaternion.Euler(0, rotationX, 0);
        Camera.main.transform.localRotation = Quaternion.Euler(rotationY, 0, 0);

        _posx = Input.GetAxis("Horizontal") * _speed;
        _posz = Input.GetAxis("Vertical") * _speed;
        _posy = Input.GetAxis("Jump") * _speed;

        Vector3 forward = transform.forward;
        Vector3 right = transform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        Vector3 movement = forward * _posz + right * _posx + new Vector3(0, _posy, 0);

        transform.position += movement * Time.deltaTime;

        // AUDIO PASOS
        Vector3 horizontalVelocity = new Vector3(_posx, 0, _posz);
        if (horizontalVelocity.magnitude > 0.1f && Physics.Raycast(transform.position, Vector3.down, 0.2f))
        {
            if (!footstepAudioSource.isPlaying || footstepAudioSource.clip != walkClip)
            {
                footstepAudioSource.clip = walkClip;
                footstepAudioSource.loop = true;
                footstepAudioSource.Play();
            }
            if (isCrouching) footstepAudioSource.pitch = 0.7f;
            else if (Input.GetKey(KeyCode.LeftShift)) footstepAudioSource.pitch = 1.3f;
            else footstepAudioSource.pitch = 1f;
        }
        else
        {
            if (footstepAudioSource.isPlaying && footstepAudioSource.clip == walkClip)
                footstepAudioSource.Stop();
        }

        if (Input.GetButtonDown("Jump") && Physics.Raycast(transform.position, Vector3.down, 0.2f))
        {
            jumpAudioSource.PlayOneShot(jumpClip);
        }
    }
}