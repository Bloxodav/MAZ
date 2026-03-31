using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class Key : MonoBehaviour
{
    public GameObject keyCar;
    public GameObject key2;
    public XRGrabInteractable door;

   

    public void ReleaseKinematic()
    {
        if (door != null)
        {
            door.enabled = true;
        }
    }


    public void ReverseVisibility()
    {
        keyCar.SetActive(true);
        key2.SetActive(false);
    }
   
}
