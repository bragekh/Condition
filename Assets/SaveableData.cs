using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveableData : MonoBehaviour
{
    public SaveThis data;
    public static SaveableData SD;

    public void Awake() {
        if (SD == null) {
            SD = this;
            DontDestroyOnLoad(this);
        }
        else
            Destroy(this.gameObject);
    }
    public void CollectedBanana() {
       data.bananasCollected++;
    }
}
[System.Serializable]
public class SaveThis {
    public int bananasCollected;
    public int amount;
}

