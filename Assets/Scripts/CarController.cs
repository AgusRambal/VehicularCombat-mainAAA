using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    private float horizontalInput;
    private float verticalInput;
    private float currentSteerAngle;
    private float currentbreakForce;
    private bool isBreaking;

    [SerializeField] private float motorForce;
    [SerializeField] private float breakForce;
    [SerializeField] private float maxSteerAngle;

    [SerializeField] private WheelCollider RuedaIzqAdelante;
    [SerializeField] private WheelCollider RuedaDerAdelante;
    [SerializeField] private WheelCollider RuedaIzqAtras;
    [SerializeField] private WheelCollider RuedaDerAtras;

    [SerializeField] private Transform RuedaIzqAdelanteT;
    [SerializeField] private Transform RuedaDerAdelanteT;
    [SerializeField] private Transform RuedaIzqAtrasT;
    [SerializeField] private Transform RuedaDerAtrasT;

    void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }

    private void GetInput()
    {
        horizontalInput = Input.GetAxis(HORIZONTAL);
        verticalInput = Input.GetAxis(VERTICAL);
        isBreaking = Input.GetKey(KeyCode.Space);
    }

    private void HandleMotor()
    {
        RuedaIzqAdelante.motorTorque = verticalInput * motorForce;
        RuedaDerAdelante.motorTorque = verticalInput * motorForce;
        currentbreakForce = isBreaking ? breakForce : 0f;
        ApplyBreaking();
    }

    private void ApplyBreaking()
    {
        RuedaDerAdelante.brakeTorque = currentbreakForce;
        RuedaIzqAdelante.brakeTorque = currentbreakForce;
        RuedaDerAtras.brakeTorque = currentbreakForce;
        RuedaIzqAtras.brakeTorque = currentbreakForce;

    }

    private void HandleSteering()
    {
        currentSteerAngle = maxSteerAngle * horizontalInput;
        RuedaIzqAdelante.steerAngle = currentSteerAngle;
        RuedaDerAdelante.steerAngle = currentSteerAngle;
    }

    private void UpdateWheels()
    {
        UpdateSingleWheel(RuedaIzqAdelante, RuedaIzqAdelanteT);
        UpdateSingleWheel(RuedaDerAdelante, RuedaDerAdelanteT);
        UpdateSingleWheel(RuedaIzqAtras, RuedaIzqAtrasT);
        UpdateSingleWheel(RuedaDerAtras, RuedaDerAtrasT);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }

}
