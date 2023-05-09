using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] float carSpeed;
    [SerializeField] float maxSpeed;

    [SerializeField] float steerAngle;

    [SerializeField] float dragAmount;
    [SerializeField] float traction;

    public Transform lw, rw;
    Vector3 _rotVec;

    Vector3 _moveVec;
    void Start()
    {

    }


    void Update()
    {
        _moveVec += transform.forward * carSpeed * Time.deltaTime;
        transform.position += _moveVec * Time.deltaTime;

        _rotVec += new Vector3(0, Input.GetAxis("Horizontal"), 0);


        //Drift yapma açýsý
        transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * steerAngle * Time.deltaTime * _moveVec.magnitude);

        _moveVec *= dragAmount;
        _moveVec = Vector3.ClampMagnitude(_moveVec, maxSpeed);
        _moveVec = Vector3.Lerp(_moveVec.normalized, transform.forward, traction * Time.deltaTime)*_moveVec.magnitude;


        _rotVec = Vector3.ClampMagnitude(_rotVec, steerAngle + 20f);

        lw.localRotation = Quaternion.Euler(_rotVec );
        rw.localRotation = Quaternion.Euler(_rotVec);
    }
}
