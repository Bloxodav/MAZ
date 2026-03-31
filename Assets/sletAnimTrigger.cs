using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sletAnimTrigger : MonoBehaviour
{
    public ButtonAnim script;
    public GameObject slet;
    public GameObject normal;
   
    public void Triggered()
    {
        script.played = true;
    }
    public void Playeed()
    {
        script.play = true;
    }

    public void Slet()
    {
        slet.SetActive(false);
        normal.SetActive(true);
    }
}
