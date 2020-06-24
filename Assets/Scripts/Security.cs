using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Security : MonoBehaviour
{
    private NavMeshAgent navMesh;
    private Controller player;
    private Light flashLight;
    private GameObject finishSpot;

    private bool isPatroling = true;
    private int currentWP;

    [Header("References")]
    public GameObject target;
    public GameObject[] waypoints;

    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
        finishSpot = GameObject.FindGameObjectWithTag("Finish Spot");
        flashLight = GetComponent<Light>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>();

        currentWP = 0;
    }

    void Update()
    {
        if (waypoints.Length == 0)
            return;

        if (Vector3.Distance(waypoints[currentWP].transform.position, transform.position) < 3f)
        {
            currentWP++;
            if(currentWP >= waypoints.Length)
            {
                currentWP = 0;
            }
        }

        if (isPatroling)
        {
            navMesh.SetDestination(waypoints[currentWP].transform.position);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(player.isHiding == true)
            {
                isPatroling = true;
            }
            else
            {
                isPatroling = false;
                flashLight.color = Color.red;

                InvokeRepeating("Follow", 0f, 0.1f);

                FindObjectOfType<GameManager>().FailLevel();
                FindObjectOfType<GameManager>().gameHasEnded = true;
            }
        }
    }
    void Follow()
    {
        navMesh.SetDestination(target.transform.position);
        navMesh.speed = 8f;
    }
}
