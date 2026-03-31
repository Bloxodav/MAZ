using UnityEngine;

public class WheelStart : MonoBehaviour
{
    public Transform steeringWheel;

    void Start()
    {
        if (steeringWheel != null)
        {
            steeringWheel.localRotation = Quaternion.Euler(-35f, 0f, 0f);
        }
    }
}
