using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    public Text time;
    public Text score;
    public Text finalScore;

    public GameObject timeScore, endScore;
    public GameObject secret;

    public float currentTime = 150;

    private int points = 0;

    public int Points
    {
        get
        {
            return points;
        }

        set
        {
            points = value;
        }
    }

    // Use this for initialization
    void Start () {
        endScore.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        currentTime -= Time.deltaTime;

        time.text = "Tid: " + (int)currentTime;
        score.text = "Poäng: " + points;

        if (points == 9)
            secret.SetActive(true);

        if (currentTime <= 0)
            EndGame();
	}

    void EndGame()
    {
        GameObject.FindGameObjectWithTag("Player").SetActive(false);
        timeScore.SetActive(false);
        endScore.SetActive(true);
        finalScore.text = points.ToString();
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
}
