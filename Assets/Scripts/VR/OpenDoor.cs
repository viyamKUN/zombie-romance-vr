using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] private door door;
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("CardKey"))
        {
            door.OpenDoor();
        }    
    }
}
