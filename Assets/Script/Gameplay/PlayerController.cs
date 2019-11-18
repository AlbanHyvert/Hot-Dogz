using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    #region Fields
    private Interactable _focus = null;
    [SerializeField] private LayerMask _movementMask;
    [SerializeField] private int _getDog = 4;
    private bool _dropDog = false;
    [SerializeField] private Camera _cam = null;
    [SerializeField] private PlayerMotor _motor = null;
    #endregion Fields

    #region Properties
    public int GetDog { get { return _getDog; } set { _getDog = value; } }
    #endregion Properties

    private void Start()
    {
       _cam = Camera.main;
       _motor = GetComponent<PlayerMotor>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = _cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 100, _movementMask))
            {
                _motor.MoveToPoint(hit.point);
                RemoveFocus();
            }
        }


        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = _cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if(interactable != null)
                {
                    SetFocus(interactable);
                }
            }
        }
    }

    private void SetFocus(Interactable newFocus)
    {
        if(newFocus != _focus)
        {
            if (_focus != null)
                _focus.OnDeFocused();

            _focus = newFocus;
            _motor.FollowTarget(newFocus);
        }
        newFocus.OnFocused(transform);
    }

    private void RemoveFocus()
    {
        if(_focus != null)
            _focus.OnDeFocused();

        _focus = null;
        _motor.StopFollowingTarget();
    }
}
