using System.IO;
using UnityEngine;

public static class SaveData {

    public static void Save(SaveableData saveData) {
        var json = JsonUtility.ToJson(saveData);
        File.WriteAllText("DoNotEnter" + ".json", json);
    }

    public static SaveableData LoadSave(FileInfo file) {
        var json = File.ReadAllText(file.FullName);
        SaveableData loadedData = JsonUtility.FromJson<SaveableData>(json);
        return loadedData;
        
    }

}