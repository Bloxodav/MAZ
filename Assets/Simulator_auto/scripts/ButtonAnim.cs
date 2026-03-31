using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ButtonAnim : MonoBehaviour
{
    public GameObject car;
    public GameObject AnimCar;
    public GameObject SobrCar;
    public bool played = false;
    public bool play = true;
    public GameObject razbor;

    void Start()
    {
        GetComponent<XRSimpleInteractable>().selectEntered.AddListener(x => Razlet());
        GetComponent<XRSimpleInteractable>().selectEntered.AddListener(x => Sobranie());
    }

   public void Razlet()
    {
        if(play == true)
        {
          car.SetActive(false);
          AnimCar.SetActive(true);
         play = false;
        }
    }
    public void Sobranie()
    {
        if(played == true)
        {
            AnimCar.SetActive(false);
            SobrCar.SetActive(true);
            played = false;
            razbor.SetActive(false);
        }
    }
}
