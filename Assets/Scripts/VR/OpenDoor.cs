using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] private door door;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CardKey"))
        {
            Debug.Log("collide with key");
            door.OpenDoor();
            SoundManager.SM.PlayAudio(SoundName.DoorOpen);
        }
    }
}
