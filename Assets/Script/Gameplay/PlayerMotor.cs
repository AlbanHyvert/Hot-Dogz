using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour
{
    private Transform _target = null;
    private NavMeshAgent _agent;
    // Start is called before the first frame update

        public NavMeshAgent Agent { get { return _agent; } }

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if(_target != null)
        {
            _agent.SetDestination(_target.position);
            FaceTarget();
        }
    }

    public void MoveToPoint(Vector3 point)
    {
        _agent.SetDestination(point);
    }

    /*public void FollowTarget(Transform newTarget)
    {
        _agent.stoppingDistance = newTarget.transform.position;
        _agent.updateRotation = false;
        _target = newTarget.transform;
    }*/

    public void StopFollowingTarget()
    {
        _target = null;
        _agent.updateRotation = true;
    }

    private void FaceTarget()
    {
        Vector3 direction = (_target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 1f);
    }
}
