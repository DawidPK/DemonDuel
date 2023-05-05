using UnityEngine.Audio;
using UnityEngine;
using System;
public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;
    public AudioMixerGroup mixer;
    // Start is called before the first frame update
    void Awake() {
        foreach(Sound s in sounds) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.outputAudioMixerGroup = mixer;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    public void Play (string nameSound) {
        Sound s = Array.Find(sounds, sound => sound.name == nameSound);
        s.source.Play();
    }
}
