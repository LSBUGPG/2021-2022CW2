using UnityEngine;
using UnityEngine.AI;

public class EnemyChase : MonoBehaviour
{
    public Transform Player;

    public NavMeshAgent agent;

    public float attackRadius = 15f;
    [SerializeField] bool inRange;

    public Transform[] destinations;
    [SerializeField] float timer;
    [SerializeField] float maxtime = 8f;
    public int currentPoint;


    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //agent.destination = Player.position;

    }

    private void FixedUpdate()
    {
        float distTO = Vector3.Distance(transform.position, Player.position);

        if (distTO <= attackRadius)
        {
            timer += Time.deltaTime;

            if (timer > maxtime)
            {
                inRange = true;
                transform.LookAt(Player);

                Vector3 moveTo = Vector3.MoveTowards(transform.position, Player.position, 100f);
                agent.destination = moveTo;
            }
        }
        else if (distTO > attackRadius)
        {
            inRange = false;
            BackToPath();
        }
    }

    void BackToPath()
    {
        if (!inRange && agent.remainingDistance < 8.5f)
        {
            agent.destination = destinations[currentPoint].position;
            UpdateCurrentPoint();
        }
    }

    void UpdateCurrentPoint()
    {
        if (currentPoint == destinations.Length -1)
        {
            currentPoint = 0;
        }
        else
        {
            currentPoint++;
        }
    }
}
