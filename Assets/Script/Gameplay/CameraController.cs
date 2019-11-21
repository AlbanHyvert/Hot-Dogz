using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 1f;
    [SerializeField] private Transform _player = null;
    private float _mouseX;
    private float _mouseY;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void LateUpdate()
    {
        CamControl();
    }

    private void CamControl()
    {
        _mouseX += Input.GetAxis("HorizontalLOOK") * _rotationSpeed;
        _mouseY -= Input.GetAxis("VerticalLOOK") * _rotationSpeed;
        _player.rotation = Quaternion.Euler(0, _mouseX, 0);
    }
}
