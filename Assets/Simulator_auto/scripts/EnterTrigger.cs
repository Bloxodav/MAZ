using UnityEngine;

public class EnterTrigger : MonoBehaviour
{
    public GameObject objectToDeactivate;
    public GameObject objectToDeactivate2;
    public GameObject objectToActivate;
    public GameObject Door;
   // [SerializeField] private CarController carController;
    public GameObject DoorStatic;

    private bool playerInsideTrigger = false;
    private float timeInsideTrigger = 0f;
    private float activationTime = 3f;
    [SerializeField] Rigidbody car;
    private bool siker = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInsideTrigger = true;
            siker = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInsideTrigger = false;
            timeInsideTrigger = 0f;
            siker = false;
        }
    }

    private void Update()
    {
        if (playerInsideTrigger == true && siker == true)
        {
            timeInsideTrigger += Time.deltaTime;
            if (timeInsideTrigger >= activationTime)
            {
                if (objectToDeactivate != null)
                {
                    Door.transform.localPosition = Vector3.zero;
                    Door.transform.rotation = Quaternion.Euler(-90f, 0f, 2f);
                    objectToDeactivate.SetActive(false);
                    Door.SetActive(false);
                    objectToDeactivate2.SetActive(false);
                }
                if (objectToActivate != null)
                {
                    objectToActivate.SetActive(true);
                    DoorStatic.SetActive(true);
                }
                car.isKinematic = false;
            
                siker = false;
                timeInsideTrigger = 0f;
            }

        }
    }
}
