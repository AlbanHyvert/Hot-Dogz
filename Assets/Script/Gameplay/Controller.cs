using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    [SerializeField] private GameObject _shibaHolder = null;
    [SerializeField] private float _throwForce = 10f;
    private float _tempSpeed = 0;
    private RaycastHit _hit;

    public GameObject ShibaHolder { get { return _shibaHolder; } set { _shibaHolder = value; } }
    private void Start()
    {
        _tempSpeed = _speed;

        if(_shibaHolder == null)
            _shibaHolder = GetComponent<GameObject>();
    }

    private void Update()
    {
        if(_speed <= 0)
        {
            if (_shibaHolder.GetComponentInChildren<Rigidbody>() != null)
            {
                Rigidbody rb = _shibaHolder.GetComponentInChildren<Rigidbody>();
                Transform transformShiba = _shibaHolder.GetComponentInChildren<Rigidbody>().transform;

                rb.useGravity = true;
                rb.isKinematic = false;
                transformShiba.SetParent(null);
                _speed = 0;
            }

        }

        if(_shibaHolder.GetComponentInChildren<Rigidbody>() == null)
        {
            if (_speed < _tempSpeed)
            {
                _speed += 0.5f;
            }
            else
                _speed = _tempSpeed;
        }

        PlayerInteraction();
        PlayerMouvement();
        Debug.DrawRay(transform.GetChild(1).position, transform.GetChild(1).forward);

        if (_shibaHolder.GetComponentInChildren<Rigidbody>() != null)
        {
            PlayerManager.Instance.Heat += 0.02f;

            if (PlayerManager.Instance.Heat > 12)
            {
                _speed -= _speed * (PlayerManager.Instance.Heat / 2);
            }
        }

        if(_shibaHolder.GetComponentInChildren<Rigidbody>() == null)
        {
            if (PlayerManager.Instance.Heat > 0)
                PlayerManager.Instance.Heat -= 0.03f;
            if(PlayerManager.Instance.Heat <= 0)
            {
                PlayerManager.Instance.Heat = 0;
            }
        }

        Debug.Log("Speed: " + _speed);
    }

    private void PlayerMouvement()
    {
        float hor = Input.GetAxis("HorizontalMVT");
        float ver = Input.GetAxis("VerticalMVT");
        Vector3 playerMovement = new Vector3(hor, 0f, ver) * (_speed)* Time.deltaTime;
        transform.Translate(playerMovement, Space.Self);
    }

    private void PlayerInteraction()
    {
        IInteract iIteract = null;
        BreakWindow _car;

        if (Input.GetButtonDown("GetDog"))
        {

            if (_shibaHolder.GetComponentInChildren<Rigidbody>() != null)
            {
                Rigidbody rb = _shibaHolder.GetComponentInChildren<Rigidbody>();
                Transform transformShiba = _shibaHolder.GetComponentInChildren<Rigidbody>().transform;

                rb.useGravity = true;
                rb.isKinematic = false;

                rb.AddForce(0, _throwForce/2, _throwForce/4, ForceMode.Force);

                transformShiba.SetParent(null);

            }

            if (_shibaHolder.GetComponentInChildren<Rigidbody>() == null)
            {
                if (Physics.Raycast(transform.GetChild(1).position, transform.GetChild(1).forward, out _hit, 150))
                {
                    if (_hit.transform.GetComponent<Shiba>() != null)
                    {
                        _hit.transform.GetComponent<Shiba>().transform.SetParent(ShibaHolder.transform);
                        _hit.transform.GetComponent<Shiba>().transform.position = ShibaHolder.transform.position;
                        _hit.transform.GetComponent<Rigidbody>().useGravity = true;
                        _hit.transform.GetComponent<Rigidbody>().isKinematic = false;
                    }
                }
                

                if (Physics.Raycast(transform.GetChild(1).position, transform.GetChild(1).forward, out _hit, 150))
                {
                    if (_hit.transform.GetComponent<IInteract>() != null)
                    {
                        _car = _hit.transform.GetComponent<BreakWindow>();

                        if (iIteract == null)
                            iIteract = _hit.transform.GetComponent<IInteract>();
                        if (_car.HitWindow >= 0)
                            iIteract.OnInteract();
                    }
                }
            }
        }
    }
}
