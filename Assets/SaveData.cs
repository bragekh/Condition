using System.IO;
using UnityEngine;

public static class SaveData {
    public static string saveFolder =>  Application.dataPath + "/DoNotEditYouLilBitch.json";
    public static void Save(SaveThis saveData) {
        var json = JsonUtility.ToJson(saveData);
        File.WriteAllText(saveFolder, json);
    }

    public static SaveThis LoadSave(FileInfo file) {
        var json = File.ReadAllText(file.FullName);
        SaveThis loadedData = JsonUtility.FromJson<SaveThis>(json);
        return loadedData;
        
    }

}