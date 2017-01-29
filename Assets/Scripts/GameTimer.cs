using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

	public float levelTotalTime = 10;

	private Slider slider;
	private LevelManager levelManager;
	private bool levelIsEnded = false;
	private AudioSource audioSource;
	private GameObject winLabel;
	private GameObject loseCollider;
    private GameObject[] allTaggedObjects;


	// Use this for initialization
	void Start () {
		levelManager = FindObjectOfType<LevelManager>();
		slider = GetComponent<Slider>();
		audioSource = GetComponent<AudioSource>();
		FindYouWinObj ();
		winLabel.SetActive(false);
		loseCollider = GameObject.Find("Lose Collider");
		loseCollider.SetActive(true);
	}

	void FindYouWinObj ()
	{
		winLabel = GameObject.Find ("You Win");
		if (!winLabel) {
			Debug.LogWarning ("Please Create 'You Win' object");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
		slider.value = Time.timeSinceLevelLoad / levelTotalTime;

		bool levelTimeIsUp = ( slider.value >= 1);
		if (levelTimeIsUp && levelIsEnded == false){    //course used Time.timeSinceLevelLoad >= LevelSeconds && !isEndOfLevel)
            HandleWinCondition();
		}

	}

    void HandleWinCondition()
    {
        DestoryAllTaggedObjects();
        audioSource.Play();
        Invoke("LoadNextLevel", audioSource.clip.length);
        levelIsEnded = true;
        winLabel.SetActive(true);
        loseCollider.SetActive(false);
    }

    // Destory all objects withdestoryOnWin tag
    void DestoryAllTaggedObjects(){
        allTaggedObjects = GameObject.FindGameObjectsWithTag("destoryOnWin");
        foreach (GameObject obj in allTaggedObjects)
        {
            Destroy(obj);
        }
    }

	void LoadNextLevel(){
		levelManager.LoadNextLevel();
	}



}
