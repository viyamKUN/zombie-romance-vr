using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BulletInputHandling : MonoBehaviour
{
    public void GetBullet(SelectEnterEventArgs args)
    {
        GameManager.GM.Bullet += 1;
        SoundManager.SM.PlayAudio(SoundName.GetItem);
    }

    public void UseBullet(SelectExitEventArgs args)
    {
        Destroy(args.interactable.gameObject);
    }
}
