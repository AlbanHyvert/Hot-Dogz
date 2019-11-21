using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    [SerializeField] private GameObject _shibaHolder = null;
    private RaycastHit _hit;

    private void Start()
    {
        if(_shibaHolder == null)
            _shibaHolder = GetComponent<GameObject>();
    }

    private void Update()
    {
        PlayerInteraction();
        PlayerMouvement();
        Debug.DrawRay(transform.GetChild(0).position, transform.GetChild(0).forward);
    }

    private void PlayerMouvement()
    {
        float hor = Input.GetAxis("HorizontalMVT");
        float ver = Input.GetAxis("VerticalMVT");
        Vector3 playerMovement = new Vector3(hor,0f,ver) * _speed * Time.deltaTime;
        transform.Translate(playerMovement, Space.Self);
    }

    private void PlayerInteraction()
    {
        IInteract iIteract = null;
        BreakWindow _car;

        

        if (Input.GetButtonDown("GetDog"))
        {
            if (Physics.Raycast(transform.GetChild(0).position, transform.GetChild(0).forward, out _hit ,150))
            {
                if (_hit.transform.GetComponent<IInteract>() != null)
                {
                    Debug.Log("GET DOG");
                    _car = _hit.transform.GetComponent<BreakWindow>();

                    Debug.Log("Interact");
                    if (iIteract == null)
                        iIteract = _hit.transform.GetComponent<IInteract>();
                    if (_car.HitWindow >= 0)
                        iIteract.OnInteract();
                }
            }
        }
    }
}
