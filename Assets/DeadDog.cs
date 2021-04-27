using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadDog : MonoBehaviour
{
    public ParticleSystem bloodSplat;
    void Start() {
        bloodSplat = GetComponent<ParticleSystem>();
    }

   public void OnCollisionEnter2D(Collision2D collider) {
        if (collider.transform.tag == "Ground") {
            print("Yes");
            bloodSplat.Play();
        }
    }
}
