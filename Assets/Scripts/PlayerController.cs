using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Editable parameters on the inspector.
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _rotationAngle = 30f;
    [SerializeField] private float _rotationTime = 0.3f;

    private float _horizontalAxisValue;
    private float _verticalAxisValue;
    private Vector3 _currentViewportPos;


    private void Update()
    {
        // Gets Unity Input Manager for Horizontal and Vertical inputs.
        _horizontalAxisValue = Input.GetAxis("Horizontal");
        _verticalAxisValue = Input.GetAxis("Vertical");

        Move();
        ClampPosition();
        RotateSpaceship();
    }

    private void RotateSpaceship ()
    {
        //Handles ship tilt with adjustable parameters on the inspector, and depending on the movement.
        float rotationSpeed = _rotationAngle / _rotationTime;
        float rotationX = -_verticalAxisValue * _rotationAngle;
        float rotationZ = -_horizontalAxisValue * _rotationAngle;
        Quaternion desiredRotation = Quaternion.Euler(rotationX, transform.localRotation.y, rotationZ);
        transform.localRotation = Quaternion.RotateTowards(transform.localRotation, desiredRotation,rotationSpeed * Time.fixedDeltaTime);
    }

    //Ship movement using input value and a speed adjuster (editable).
    private void Move()
    {
        transform.localPosition += new Vector3(_horizontalAxisValue, _verticalAxisValue, 0) * _speed * Time.deltaTime;
    }

    private void ClampPosition ()
    {
        //Convert player world position to viewport position
        _currentViewportPos = Camera.main.WorldToViewportPoint(transform.position);

        _currentViewportPos.x = Mathf.Clamp(_currentViewportPos.x, 0.15f, 0.80f);
        _currentViewportPos.y = Mathf.Clamp(_currentViewportPos.y, 0.15f, 0.80f);

        //Convert back to world position and assign to ship
        transform.position = Camera.main.ViewportToWorldPoint(_currentViewportPos);
    }
}
