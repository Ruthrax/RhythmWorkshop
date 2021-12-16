using System.Collections.Generic;
using UnityEngine;
using System;

public class SoundManager : LocalManager<SoundManager>
{
    private AudioSource audioSource = null;
    public List<AudioClip> clips = null;

    protected override void Awake()
    {
	base.Awake();
        audioSource = GetComponent<AudioSource>();
    }

    private void Play(AudioClip clipToPlay)
    {
        audioSource.PlayOneShot(clipToPlay);
    }

	public void PlaybossAttacks()
	{
		Play(clips[0]);
	}

	public void PlaybossAttacks2()
	{
		Play(clips[1]);
	}

	public void PlaybossGruntLight()
	{
		Play(clips[2]);
	}

	public void PlayexplosionLight()
	{
		Play(clips[3]);
	}

	public void PlayGoodNote()
	{
		Play(clips[4]);
	}

	public void PlayLaunchLaser()
	{
		Play(clips[5]);
	}

	public void PlayLaunchMissile()
	{
		Play(clips[6]);
	}

	public void PlaymissNote()
	{
		Play(clips[7]);
	}

	public void PlayperfectNote()
	{
		Play(clips[8]);
	}

	public void PlayplayerGetsHit()
	{
		Play(clips[9]);
	}

	public void PlayPrelaser()
	{
		Play(clips[10]);
	}

	public void PlayShuriken()
	{
		Play(clips[11]);
	}

	public void PlayStab()
	{
		Play(clips[12]);
	}

	public void PlayStartButton()
	{
		Play(clips[13]);
	}

	public void PlayButtonHilight()
	{
		Play(clips[14]);
	}

	public void PlayMenuClick()
	{
		Play(clips[15]);
	}
}