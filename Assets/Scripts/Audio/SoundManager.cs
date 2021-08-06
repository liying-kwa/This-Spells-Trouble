using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SoundManager : MonoBehaviour
{
    public AudioSource masterSource;

    public AudioSource effectSource;

    public AudioSource UISource;

    // BGM Clips

    public AudioClip onCharacterSelectionMenuClip;

    public AudioClip onStageOneStartClip;

    // Player Clips

    public AudioClip onLavaClip;

    public AudioClip onRegenClip;

    public AudioClip onPlayerDeathClip;

    public AudioClip onVictoryClip;

    // Spells Clips

    public AudioClip onFireballCastClip;

    public AudioClip onFireballHitClip;

    public AudioClip onTeleportCastClip;

    //public AudioClip onTeleportLandClip;

    public AudioClip onLightningCastClip;
    public AudioClip onLightningHitClip;
    public AudioClip onTornadoCastClip;
    public AudioClip onTornadoHitClip;
    public AudioClip onRushCastClip;

    public AudioClip onArcCastClip;
    public AudioClip onArcHitClip;
    public AudioClip onBoomerangCastClip;
    public AudioClip onBoomerangHitClip;
    public AudioClip onCloudCastClip;
    public AudioClip onGroundAttackCastClip;
    public AudioClip onGroundAttackHitClip;
    public AudioClip onIceAttackCastClip;
    public AudioClip onIceAttackHitClip;
    public AudioClip onLaserCastClip;
    public AudioClip onLaserHitClip;
    public AudioClip onMineCastClip;
    public AudioClip onMineHitClip;
    public AudioClip onShockwaveCastClip;
    public AudioClip onShockwaveHitClip;
    public AudioClip onWallCastClip;

    // UI Clips 
    public AudioClip onArrowButtonClip;

    public AudioClip onReadyButtonClip;

    public AudioClip onBuySpellClip;

    public AudioClip onClockTickingClip;

    public AudioClip onJoinButtonClip;
    
    // BGM Methods

    public void PlayCharacterSelectionMenu()
    {
        masterSource.PlayOneShot(onCharacterSelectionMenuClip);
    }

    public void PlayStageOneTheme()
    {
        masterSource.Stop();
        masterSource.PlayOneShot(onStageOneStartClip);
    }

    // Player Methods

    public void PlayLava()
    {
        effectSource.PlayOneShot(onLavaClip);
    }

    public void PlayRegen()
    {
        effectSource.PlayOneShot(onRegenClip);
    }

    public void PlayPlayerDeath()
    {
        effectSource.PlayOneShot(onPlayerDeathClip);
    }

      public void PlayVictory()
    {
        masterSource.Stop();
        masterSource.PlayOneShot(onVictoryClip);
    }

    // Spells Methods

    public void PlayFireballCast()
    {
        effectSource.PlayOneShot(onFireballCastClip);
    }

    public void PlayFireballHit()
    {
        //AudioSource.PlayClipAtPoint(onFireballHitClip, new Vector3(0,0,0));
        //transform.position += new Vector3 (0.0f, 0.0f, 0f);
        //effectSource.PlayClipAtPoint(onFireballHitClip, transform.position);
        effectSource.PlayOneShot(onFireballHitClip);
    }

    public void PlayTeleportCast()
    {
        effectSource.PlayOneShot(onTeleportCastClip);
    }

    // public void PlayTeleportLand()
    // {
    //     effectSource.PlayOneShot(onTeleportLandClip);
    // }

    public void PlayLightningCast()
    {
        effectSource.PlayOneShot(onLightningCastClip);
    }

    public void PlayLightningHit()
    {
        effectSource.PlayOneShot(onLightningHitClip);
    }

    public void PlayTornadoCast()
    {
        effectSource.PlayOneShot(onTornadoCastClip);
    }

    public void PlayTornadoHit()
    {
        effectSource.PlayOneShot(onTornadoHitClip);
    }

    public void PlayRushCast()
    {
        effectSource.PlayOneShot(onRushCastClip);
    }

    public void PlayArcCast()
    {
        effectSource.PlayOneShot(onArcCastClip);
    }

    public void PlayArcHit()
    {
        effectSource.PlayOneShot(onArcHitClip);
    }

    public void PlayBoomerangCast()
    {
        effectSource.PlayOneShot(onBoomerangCastClip);
    }

    public void PlayBoomerangHit()
    {
        effectSource.PlayOneShot(onBoomerangHitClip);
    }

    public void PlayCloudCast()
    {
        effectSource.PlayOneShot(onCloudCastClip);
    }

    public void PlayGroundAttackCast()
    {
        effectSource.PlayOneShot(onGroundAttackCastClip);
    }

    public void PlayGroundAttackHit()
    {
        effectSource.PlayOneShot(onGroundAttackHitClip);
    }

    public void PlayIceAttackCast()
    {
        effectSource.PlayOneShot(onIceAttackCastClip);
    }

    public void PlayIceAttackHit()
    {
        effectSource.PlayOneShot(onIceAttackHitClip);
    }

    public void PlayLaserCast()
    {
        effectSource.PlayOneShot(onLaserCastClip);
    }

    public void PlayLaserHit()
    {
        effectSource.PlayOneShot(onLaserHitClip);
    }

    public void PlayMineCast()
    {
        effectSource.PlayOneShot(onMineCastClip);
    }

    public void PlayMineHit()
    {
        effectSource.PlayOneShot(onMineHitClip);
    }

    public void PlayShockwaveCast()
    {
        effectSource.PlayOneShot(onShockwaveCastClip);
    }

    public void PlayShockwaveHit()
    {
        effectSource.PlayOneShot(onShockwaveHitClip);
    }

    public void PlayWallCast()
    {
        effectSource.PlayOneShot(onWallCastClip);
    }

    // UI Methods

    public void PlayArrowButton()
    {
        UISource.PlayOneShot(onArrowButtonClip);
    }

    public void PlayReadyButton()
    {
        UISource.PlayOneShot(onReadyButtonClip);
    }

    public void PlayJoinButton()
    {
        UISource.PlayOneShot(onJoinButtonClip);
    }

    public void PlayBuySpell() {
        UISource.PlayOneShot(onBuySpellClip);
    }

    public void PlayClockTicking()
    {   
        UISource.PlayOneShot(onClockTickingClip);
    }

    public void PauseClockTicking()
    {
        UISource.Pause();
    }

    public void ResumeClockTicking()
    {
        UISource.UnPause();
    }



  

}


