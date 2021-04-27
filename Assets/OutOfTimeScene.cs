using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using System;

public class OutOfTimeScene : MonoBehaviour
{
    public Button quit;
    public Button retry;
    public Text youTried;
    public Text newHIghSCORE;
    public string java;
    private void Start() {
        java = File.ReadAllText(Application.dataPath + "/DoNotEditYouLilBitch.json");
        quit.onClick.AddListener(Quitting);
        retry.onClick.AddListener(Retrying);
        SaveThis loaded = JsonUtility.FromJson<SaveThis>(java);
        if (loaded.bananasCollected > SaveableData.SD.data.amount)
            newHIghSCORE.gameObject.SetActive(true);
        }

    private void Retrying() {
        SceneManager.LoadScene("GameScene");
    }

    public void Update() {
        youTried.text = "Even though you collected " + SaveableData.SD.data.amount + " bananas, you still didn't collect enough to get rid of your Potassium deficiency";
    }

    public void Quitting() {
        Application.Quit();
    }
    }
