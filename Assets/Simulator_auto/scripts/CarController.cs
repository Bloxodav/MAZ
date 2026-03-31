using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Content.Interaction;

public class CarController : MonoBehaviour
{

    [SerializeField] private AudioSource idle;
    [SerializeField] private AudioSource moving;
    [SerializeField] private AudioSource stopping;


   [SerializeField] private Rigidbody carRigidbody; 
    [SerializeField] private float currentSpeed;

    private float currentSteerAngle;
    private float currentbreakForce;

    [SerializeField] private InputAction brakeControl;
    [SerializeField] private InputAction carControl;
    [SerializeField] private XRKnob steeringWheel;

    [SerializeField] private float motorForce;


    [SerializeField] private float breakForce;
    [SerializeField] private float maxSteerAngle;

    [SerializeField] private WheelCollider frontLeftWheelCollider;
    [SerializeField] private WheelCollider frontRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider;
    [SerializeField] private WheelCollider rearRightWheelCollider;

    [SerializeField] private Transform frontLeftWheelTransform;
    [SerializeField] private Transform frontRightWheeTransform;
    [SerializeField] private Transform rearLeftWheelTransform;
    [SerializeField] private Transform rearRightWheelTransform;

    private void Start()
    {
        carRigidbody = GetComponent<Rigidbody>();
    }
    private void OnEnable()
    {
        carControl.Enable();
        brakeControl.Enable();
    }

    private void OnDisable()
    {
        carControl.Disable();
        brakeControl.Disable();
    }

    private void FixedUpdate()
    {
        HandleMotor();
        HandleSteering();
        UpdateWheels();
        HandleBrake();
        currentSpeed = carRigidbody.velocity.magnitude;
    }
    public float GetCurrentSpeed()
    {
        return currentSpeed;
    }
    private void HandleBrake()
    {
        float brakeValue = brakeControl.ReadValue<float>();
        bool isBraking = brakeValue > 0;
        currentbreakForce = isBraking ? breakForce : 0f;
        bool isMoving = carControl.ReadValue<float>() > 0;
        if (isBraking && currentSpeed >0.05f)
        {
            if (!stopping.isPlaying )
            {
                stopping.Play();
            }
        }
        else
        {
            stopping.Stop(); 
        }

        ApplyBreaking();
    }
    private void HandleSteering()
    {
        float steeringValue = steeringWheel.value;
        currentSteerAngle = maxSteerAngle * (steeringValue * 2 - 1);
        frontLeftWheelCollider.steerAngle = currentSteerAngle;
        frontRightWheelCollider.steerAngle = currentSteerAngle;
    }

    private void ApplyBreaking()
    {
        frontRightWheelCollider.brakeTorque = currentbreakForce;
        frontLeftWheelCollider.brakeTorque = currentbreakForce;
        rearLeftWheelCollider.brakeTorque = currentbreakForce;
        rearRightWheelCollider.brakeTorque = currentbreakForce;
    }

    private void HandleMotor()
    {

        float triggerValue = carControl.ReadValue<float>();
        float verticalInput = Mathf.Clamp01(triggerValue);

        frontLeftWheelCollider.motorTorque = verticalInput * motorForce;
        frontRightWheelCollider.motorTorque = verticalInput * motorForce;

        bool isMoving = verticalInput > 0; 
        if (isMoving)
        {
            if (!moving.isPlaying)
            {
                moving.Play();
            }
        }
        else
        {
            moving.Stop(); 
        }

        bool isBreaking = triggerValue < 0;
        currentbreakForce = isBreaking ? breakForce : 0f;
        ApplyBreaking();

        if (!isMoving)
        {
            if (!idle.isPlaying)
            {
                idle.Play();
            }
        }
        else
        {
            
            if (idle.isPlaying)
            {
                idle.Stop();
            }
        }
    }

    private void UpdateWheels()
    {
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheeTransform);
        UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform);
        UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }
    public void SetMotorForce(float force)
    {
        motorForce = force;
    }
  
}