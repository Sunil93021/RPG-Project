using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class Mover : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator animator;
    private const string FORWARD_SPEED= "forwardSpeed";
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            MoveToCursor();
        }
        UpdateAnimation();

    }

    private void MoveToCursor()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        bool hasHit = Physics.Raycast(ray, out hit);
        if (hasHit)
        {
            agent.destination = hit.point;
        }
    }

    private void UpdateAnimation()
    {
        Vector3 globalVelocity = agent.velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(globalVelocity);
        animator.SetFloat(FORWARD_SPEED,localVelocity.z);
    }
}
