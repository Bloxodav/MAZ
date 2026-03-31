using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class lightController : MonoBehaviour
{
    public GameObject[] headlights;
    public XRKnob knob;

    public float angle1 = 90f;
    public float angle2 = -90f;

    public AudioSource audioSource;
    public AudioClip clickSound;

    private bool light1On;
    private bool light2On;

    void Update()
    {
        float knobAngle = knob.handle.localEulerAngles.y;

        if (Mathf.Abs(knobAngle - angle1) < 5f || Mathf.Abs(knobAngle - (angle1 + 360)) < 5f)
        {
            if (!light1On)
            {
                TurnOnHeadlights(1);
                PlayClickSound();
                light1On = true;
                light2On = false;
            }
        }
        else if ((knobAngle >= angle2 - 5f && knobAngle <= angle2 + 5f) || (knobAngle >= angle2 - 5f + 360 && knobAngle <= angle2 + 5f + 360))
        {
            if (!light2On)
            {
                TurnOnHeadlights(2);
                PlayClickSound();
                light1On = false;
                light2On = true;
            }
        }
        else
        {
            TurnOffAllHeadlights();
            light1On = false;
            light2On = false;
        }
    }

    void TurnOnHeadlights(int index)
    {
        for (int i = 0; i < headlights.Length; i++)
        {
            if (i == index - 1)
                headlights[i].SetActive(true);
            else
                headlights[i].SetActive(false);
        }
    }

    void TurnOffAllHeadlights()
    {
        foreach (GameObject light in headlights)
        {
            light.SetActive(false);
        }
    }

    void PlayClickSound()
    {
        if (clickSound != null && audioSource != null)
        {
            audioSource.clip = clickSound;
            audioSource.Play();
        }
    }
}
