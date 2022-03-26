using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMgr : MonoBehaviour
{
    public static SoundMgr instance;
    private AudioSource asBg;
    private List<AudioSource> asList;
    private float backVolume;
    private float effectVolume;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        asBg = GetComponent<AudioSource>();
        asList = new List<AudioSource>();
        LoadConfing();
    }

    public void PlayBackSound(string soundName)
    {
        AudioClip _ac = GetSound(soundName);
        if (_ac != null)
        {
            asBg.clip = _ac;
            asBg.Play();
        }
    }
    public void PlayOtherSound(string soundName)
    {
        AudioClip _ac = GetSound(soundName);
        AudioSource _as = GetAudioSource();
        if (_ac != null)
        {
            _as.clip = _ac;
            _as.Play();
        }
    }
    private AudioSource GetAudioSource()
    {
        foreach (AudioSource _item in asList)
        {
            if (!_item.isPlaying)
                return _item;
        }
        AudioSource _as = gameObject.AddComponent<AudioSource>();
        _as.volume = effectVolume;
        asList.Add(_as);
        return asList[asList.Count - 1];
    }
    private AudioClip GetSound(string soundName)
    {
        return Resources.Load<AudioClip>(PublicDefine.soundPath + soundName);
    }
    public void SetSoundVolume(SoundType soundType, float soundVolume)
    {
        switch (soundType)
        {
            case SoundType.BackSound:
                SetBackVolume(soundVolume);
                break;
            case SoundType.EffectSound:
                SetEffectVolume(soundVolume);
                break;
            default:
                break;
        }
    }
    private void SetBackVolume(float volume)
    {
        asBg.volume = volume;
        backVolume = volume;
    }
    private void SetEffectVolume(float volume)
    {
        foreach (AudioSource item in asList)
        {
            item.volume = volume;
        }
        effectVolume = volume;
    }

    private void LoadConfing()
    {
        ClientDataProxy _cdp = AppFacade.Instance.RetrieveProxy(ClientDataProxy.NAME) as ClientDataProxy;
        SetBackVolume((float)_cdp.VO.backSoundVolume);
        SetEffectVolume((float)_cdp.VO.effectSoundVolume);
    }
}