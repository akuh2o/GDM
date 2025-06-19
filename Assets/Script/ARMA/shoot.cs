using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float aimingFOV = 30f;
    private float defaultFOV;
    private static bool isAiming = false;

    [SerializeField] private AudioClip shootClip;
    [SerializeField] private AudioClip chargeClip;

    private AudioSource audioSource;

    [SerializeField] private float shootDelay = 2f;
    private float lastShootTime = -Mathf.Infinity;

    void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
        if (mainCamera != null)
        {
            defaultFOV = mainCamera.fieldOfView;
        }

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            isAiming = true;
            Debug.Log("Apuntando");
            if (mainCamera != null)
            {
                mainCamera.fieldOfView = aimingFOV;
            }
            if (chargeClip != null)
            {
                audioSource.PlayOneShot(chargeClip);
            }
        }
        if (Input.GetMouseButtonUp(1))
        {
            isAiming = false;
            Debug.Log("Dejó de apuntar");
            if (mainCamera != null)
            {
                mainCamera.fieldOfView = defaultFOV;
            }
        }

        if (isAiming && Input.GetMouseButtonDown(0) && Time.time - lastShootTime >= shootDelay)
        {
            GameObject newBullet = Instantiate(bullet, spawnPoint.transform.position, spawnPoint.transform.rotation);
            if (shootClip != null)
            {
                audioSource.PlayOneShot(shootClip);
            }
            lastShootTime = Time.time;
        }
    }
}

