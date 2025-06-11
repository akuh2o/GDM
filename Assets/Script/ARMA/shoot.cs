using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
    {
        Instantiate(bullet, spawnPoint.transform.position, spawnPoint.transform.rotation);
    }

    }
}
