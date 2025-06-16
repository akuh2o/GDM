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
    }void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            isAiming = true;
            Debug.Log("Apuntando con la mira");
            if (mainCamera != null)
            {
                mainCamera.fieldOfView = aimingFOV;
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

        if (isAiming && Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet, spawnPoint.transform.position, spawnPoint.transform.rotation);
        }
   
    }
}
