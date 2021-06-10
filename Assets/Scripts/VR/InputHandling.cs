using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class InputHandling : MonoBehaviour
{
    public void GetBullet(SelectEnterEventArgs args)
    {
        GameManager.GM.Bullet += 1;
    }

    public void UseBullet(SelectExitEventArgs args)
    {
        Destroy(args.interactable.gameObject);
    }

    public void GetHealKit(SelectEnterEventArgs args)
    {
        GameManager.GM.HP = 1.0f;
        Destroy(args.interactable.gameObject);
    }
}
