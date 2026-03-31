using UnityEngine;
using System.Collections;
using UnityEngine.XR.Content.Interaction;

public class TurnLeft : MonoBehaviour
{
    public GameObject turnSignals;
    public float turnOnDuration = 0.3f;
    public float turnOffDuration = 0.5f;
    public XRKnob steeringWheel;
    public XrLepestok xrLepestok;

    private Coroutine turnSignalCoroutine;
    private bool isInInitialRange = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Lepestok"))
        {
            if (turnSignalCoroutine != null)
            {
                StopCoroutine(turnSignalCoroutine);
            }
            turnSignalCoroutine = StartCoroutine(TurnSignalRoutine());

            if (steeringWheel.value >= 0.48f && steeringWheel.value <= 0.52f)
            {
                isInInitialRange = true;
            }
            else
            {
                isInInitialRange = false;
            }

            xrLepestok.end = true;
        }
        else
        {
            xrLepestok.end = false;
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Lepestok"))
        {
            xrLepestok.end = false;
        }
    }

    private IEnumerator TurnSignalRoutine()
    {
        bool isFirstPass = true;

        while (true)
        {
            turnSignals.SetActive(true);
            yield return new WaitForSeconds(turnOnDuration);
            turnSignals.SetActive(false);
            yield return new WaitForSeconds(turnOffDuration);

            if (steeringWheel.value >= 0.48f && steeringWheel.value <= 0.52f && isFirstPass)
            {
                xrLepestok.Povorot();
                isFirstPass = false;
            }

            if (steeringWheel.value >= 0.48f && steeringWheel.value <= 0.52f && !isInInitialRange)
            {
                turnSignals.SetActive(false);
                yield break;
            }

            if (isInInitialRange && (steeringWheel.value < 0.48f || steeringWheel.value > 0.52f))
            {
                isInInitialRange = false;
            }
        }
    }
}
