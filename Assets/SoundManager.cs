using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    public static SoundManager SM;
    public List<Sounds> sounds = new List<Sounds>();
    public AudioSource aS;
    private void Start() {
        if (SM == null) {
            SM = this;
            DontDestroyOnLoad(this);
        }
        else
            Destroy(gameObject);
    }
    public void PlaySound(string soundType) {
        foreach (Sounds s in sounds) {
            if (soundType == s.soundName) {

                aS.PlayOneShot(s.sound, 1f);
                print("played " + s.name);
            }

        }
    }   
}
