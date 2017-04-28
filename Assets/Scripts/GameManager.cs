using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour {

    private float fixedDeltaTime;
    private bool isPaused = false;


    public bool recording = true;

    void Start()
    {
        fixedDeltaTime = Time.fixedDeltaTime;
        PlayerPrefsManager.UnlockLevel(2);
        print("Level 1 unlock status: " + PlayerPrefsManager.IsLevelUnlocked(1));
        print("Level 2 unlock status: " + PlayerPrefsManager.IsLevelUnlocked(2));
    }
    
	// Update is called once per frame
	void Update () {
		if (CrossPlatformInputManager.GetButton("Fire1"))
        {
            recording = false;
        } else
        {
            recording = true;
        }

        if (Input.GetKeyDown(KeyCode.P) && isPaused)
        {
            isPaused = false;
            ResumeGame();
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            isPaused = true;
            PauseGame();
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0;
        Time.fixedDeltaTime = 0;        
    }

    void ResumeGame()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = fixedDeltaTime;
    }

}
