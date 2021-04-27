using System.IO;
using UnityEngine;

public static class SaveData {

    public static void Save(Vector3 saveData) {
        var json = JsonUtility.ToJson(saveData);
        File.WriteAllText("DoNotEnter" + ".json", json);
    }

    public static Vector3 LoadSave(FileInfo file) {
        var json = File.ReadAllText(file.FullName);
        Vector3 loadedData = JsonUtility.FromJson<Vector3>(json);
        return loadedData;
        
    }

}