using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHover : MonoBehaviour
{
  
    [SerializeField] private Rigidbody door;


    public void Select()
    {
        if (door != null)
        {
            door.constraints = RigidbodyConstraints.None;
        }
    }

}
