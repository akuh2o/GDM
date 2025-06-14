using System;
using UnityEngine;

public class playermove : MonoBehaviour
{
    [SerializeField] private float sensitivity = 5.0f;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _speedboost = 10f;

    private float rotationX = 0.0f;
    private float rotationY = 0.0f;
    private float _posx;
    private float _posz;
    private float _posy;

    private bool isCrouching = false;

    private Animator animator;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        animator = GetComponent<Animator>();
    }

    void Update()
    {
        
        isCrouching = Input.GetKey(KeyCode.LeftControl);

      
        if (isCrouching)
        {
            _speed = 2.5f; 
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            _speed = _speedboost;
        }
        else
        {
            _speed = 5f;
        }

      
        animator.SetBool("isCrouching", isCrouching);

       
        rotationX += Input.GetAxis("Mouse X") * sensitivity;
        rotationY -= Input.GetAxis("Mouse Y") * sensitivity;
        rotationY = Mathf.Clamp(rotationY, 5f, 30f);

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
    }
}
