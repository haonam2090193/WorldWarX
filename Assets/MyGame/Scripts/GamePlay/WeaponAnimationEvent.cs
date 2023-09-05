using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationEvent : UnityEvent<string>
{

}

public class WeaponAnimationEvent : MonoBehaviour
{
    public AnimationEvent WeaponAnimEvent = new AnimationEvent();

    public void OnAnimationEvent(string eventName)
    {
        WeaponAnimEvent.Invoke(eventName);
    }

    public void SoundClip()
    {
        RaycastWeapon raycastWeapon = GetComponent<RaycastWeapon>();
        raycastWeapon.PlaySound();
    }

    public void PistolShoot()
    {
        if (UIManager.HasInstance)
        {
            AudioManager.Instance.PlaySE(AUDIO.SE_PISTOL_FIRE);
        }
    }
    public void SMGShoot()
    {
        if (UIManager.HasInstance)
        {
            AudioManager.Instance.PlaySE(AUDIO.SE_SMG_FIRE);
        }
    }
    public void ShotgunShoot()
    {
        if (UIManager.HasInstance)
        {
            AudioManager.Instance.PlaySE(AUDIO.SE_SHOTGUN_FIRE);
        }
    }

    public void PistolReload()
    {
        if (UIManager.HasInstance)
        {
            AudioManager.Instance.PlaySE(AUDIO.SE_PISTOL_RELOAD);
        }
    }
    public void SMGReload()
    {
        if (UIManager.HasInstance)
        {
            AudioManager.Instance.PlaySE(AUDIO.SE_SMG_RELOAD);
        }
    }

    public void ShotgunOpen()
    {
        if (UIManager.HasInstance)
        {
            AudioManager.Instance.PlaySE(AUDIO.SE_SHOTGUN_RELOAD_OPEN);
        }
    }

    public void ShotgunReload()
    {
        if (UIManager.HasInstance)
        {
            AudioManager.Instance.PlaySE(AUDIO.SE_SHOTGUN_SELOAD_INSERT);
        }
    }
    public void ShotgunClose()
    {
        if (UIManager.HasInstance)
        {
            AudioManager.Instance.PlaySE(AUDIO.SE_SHOTGUN_RELOAD_CLOSE);
        }
    }
}
