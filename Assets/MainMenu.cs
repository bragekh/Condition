using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
   public Button quit, start;
    public Text highScoreText;
    public void Start() {
        quit.onClick.AddListener(IShallQuitTheGameYouCretin);
        start.onClick.AddListener(IShallPlayThisAbominationOfAGame);
        string json = File.ReadAllText(Application.dataPath + "/DoNotEditYouLilBitch.json");
        SaveThis loaded = JsonUtility.FromJson<SaveThis>(json);
        SaveableData.SD.data = loaded;
        highScoreText.text = SaveableData.SD.data.bananasCollected.ToString();
    }
    public void Update() {

    }
    public void IShallQuitTheGameYouCretin() {
        Application.Quit();
    }
    public void IShallPlayThisAbominationOfAGame() {
        SceneManager.LoadScene("GameScene");
    }

}
