using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveableData : MonoBehaviour
{
<<<<<<< Updated upstream
  public List<GameObject> resetObjects = new List<GameObject>();
    [ContextMenu("Save")]
    public void Save() {
        foreach (GameObject r in resetObjects) {
            SaveData.Save(r.transform.position);
        }
    }
    [ContextMenu("Load")]
    public void Load() {
       // FileInfo save;
        foreach (GameObject r in resetObjects) {
          //  r.transform.position = SaveData.LoadSave(save);

        }
    }
=======
    public int bananasCollected;
>>>>>>> Stashed changes
}
