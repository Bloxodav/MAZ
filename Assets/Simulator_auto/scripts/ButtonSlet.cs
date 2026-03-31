using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ButtonSlet : MonoBehaviour
{
    public GameObject car;
    public GameObject AnimCar;
    public GameObject SobrCar;
    public bool played = true;
   
    void Start()
    {
      
        GetComponent<XRSimpleInteractable>().selectEntered.AddListener(x => Sobranie());
    }

    public void Sobranie()
    {
        if (played == true)
        {
            AnimCar.SetActive(false);
            SobrCar.SetActive(true);
            played = false;
        }
    }
}
