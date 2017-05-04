using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class MixLevels : MonoBehaviour
{
    [SerializeField]
    AudioMixer masterMixer;
    
    public void SetMasterVolume(float masterVol)
    {
        masterMixer.SetFloat("MasterVol", masterVol);
    }

    public void SetMusicVolume(float musicVol)
    {
        masterMixer.SetFloat("MusicVol", musicVol);
    }

    public void SetVoiceVolume(float voiceVol)
    {
        masterMixer.SetFloat("VoiceVol", voiceVol);
    }

    public void SetAllVolumeLevels(float masterVol, float musicVol, float voiceVol)
    {
        masterMixer.SetFloat("MasterVol", masterVol);
        masterMixer.SetFloat("MusicVol", musicVol);
        masterMixer.SetFloat("VoiceVol", voiceVol);
    }
}
