using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerControllerMouse : MonoBehaviour
{
    private bool _focus = false;
    private bool _dropDog = false;
    [SerializeField] private PlayerMotor _motor = null;
    private Transform _target = null;
    private IInteract _iIteract = null;
    private void Start()
    {
        _dropDog = false;
        _focus = false;
        if (_motor == null)
            _motor = GetComponent<PlayerMotor>();
        _iIteract = null;
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        Physics.Raycast(ray, out hit, 100);
        if(Input.GetMouseButtonDown(0))
        {
            if (hit.collider.GetComponent<IInteract>() != null)
            {
                _focus = true;
                _iIteract = hit.collider.GetComponent<IInteract>();
                _target = hit.collider.transform;
            }

            if(hit.collider.GetComponent<IInteract>() == null)
            {
                _focus = false;
                _iIteract = null;
                _motor.MoveToPoint(hit.point);
            }
        }

        /*if(_focus == true)
        {
            Debug.Log("Focus : " + _focus);
            _motor.Agent.SetDestination(_target.position);
            FaceTarget();
            if (_motor.Agent.remainingDistance < 1.5f)
            {
                //_motor.Agent.stoppingDistance = ;
                Debug.Log("We are in bois");
                _iIteract.OnInteract();
                _motor.StopFollowingTarget();
            }

        }*/
    }


    private void FaceTarget()
    {
        Vector3 direction = (_target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 1f);
    }
}
