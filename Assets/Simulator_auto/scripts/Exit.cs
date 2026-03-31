using UnityEngine;
using UnityEngine.InputSystem;

public class Exit : MonoBehaviour
{
    [SerializeField] private InputAction menu;
    [SerializeField] private GameObject PlOut;
    [SerializeField] private GameObject PlIn;
    [SerializeField] private GameObject Dver;
    [SerializeField] private GameObject DverStatic;



    private void OnEnable()
    {
        menu.Enable();
    }

    private void OnDisable()
    {
        menu.Disable();
    }

    private void Update()
    {
        if (menu.triggered)
        {
            Debug.Log("arthas");
            if(PlIn != null)
            {
                PlIn.SetActive(false);
            }
            if(PlOut != null)
            {
                PlOut.SetActive(true);
            }
            if (Dver != null)
            {
                
                Dver.SetActive(true);
               
            }
            if(DverStatic != null)
            {
                DverStatic.SetActive(false);
            }
        }
    }
}
