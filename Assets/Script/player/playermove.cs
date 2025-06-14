using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float sensitivity = 5.0f;
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _speedboost = 10;

    private float rotationX = 0.0f;
    private float rotationY = 0.0f; // Variable para la rotación vertical
    private float _posx;
    private float _posz;
    private float _posy;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    
    void Update()
    {
        // Rotación de la cámara
        rotationX += Input.GetAxis("Mouse X") * sensitivity;
        rotationY -= Input.GetAxis("Mouse Y") * sensitivity; // Invertir el eje Y para un movimiento natural
        rotationY = Mathf.Clamp(rotationY, 5f, 30f); // Limitar la rotación vertical

        transform.localRotation = Quaternion.Euler(0, rotationX, 0);
        Camera.main.transform.localRotation = Quaternion.Euler(rotationY, 0, 0); // Aplicar rotación vertical a la cámara

        // Movimiento del personaje
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

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _speed = _speedboost;
        }
        else
        {
            _speed = 5; // Velocidad normal
        }
    }

    public void OnPlayerDeath()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void OnPlayerWin()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
