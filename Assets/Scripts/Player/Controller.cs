using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Controller : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private NavMeshAgent navMesh;
    [SerializeField] private GameObject finishSpot;

    private Camera mainCamera;

    public bool isHiding = false;

    void Start()
    {
        mainCamera = Camera.main;
        navMesh = GetComponent<NavMeshAgent>();

        Invoke("ActiveEndSpot", 10f);
    }
    void Update()
    {
        if (Input.GetMouseButton(0))
            Movement();

        if (Input.GetKey(KeyCode.Space))
        {
            Hide();
        }
        else
        {
            isHiding = false;
            transform.localScale = new Vector3(1f, 1f, 1f);
            navMesh.speed = 8;
        }
    }
    void Movement()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out RaycastHit hit))
        {
            navMesh.SetDestination(hit.point);
        }
    }
    void  Hide()
    {
        isHiding = true;
        transform.localScale = new Vector3(2f, 0.4f, 2f);
        navMesh.speed = 0;
    }
    void ActiveEndSpot()
    {
        finishSpot.SetActive(true);
    }
        
}
