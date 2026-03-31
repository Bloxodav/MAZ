using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class razborSpawn : MonoBehaviour
{
    public GameObject anim;
    public GameObject staticcar;
    
    public void Spawn()
    {
        anim.SetActive(false);
        staticcar.SetActive(true);
    }
}
