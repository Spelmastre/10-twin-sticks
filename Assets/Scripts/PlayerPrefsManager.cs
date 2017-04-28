using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour {

    const string MASTER_VOLUME_KEY = "master_volume";
    const string DIFFICULTY_KEY = "difficulty";
    const string LEVEL_UNLOCKED = "level_unlocked_";

	public static void SetMasterVolume(float volume)
    {
        if (volume >= 0f && volume <= 1f)
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        } else
        {
            Debug.LogError("master_volume out of range");
        }
        
    }

    public static float GetMasterVolume()
    {
        if (PlayerPrefs.GetFloat(MASTER_VOLUME_KEY) != 0)
        {
            return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
        } else
        {
            return 0.5f;
        }        
    }

    public static void UnlockLevel(int level)
    {
        if (level <= SceneManager.sceneCountInBuildSettings -1)
        {
            PlayerPrefs.SetInt(LEVEL_UNLOCKED + level.ToString(), 1);
        } else
        {
            Debug.LogError("Trying to unlock level that doesn't exist in build order");
        }        
    }

    public static bool IsLevelUnlocked(int level)
    {
        if (level <= SceneManager.sceneCountInBuildSettings - 1)
        {
            int levelValue = PlayerPrefs.GetInt(LEVEL_UNLOCKED + level.ToString());
            bool isLevelUnlocked = (levelValue == 1);
            return isLevelUnlocked;
        }
        else
        {
            Debug.LogError("Level doesn't exist in build order");
            return false;            
        }
    }

    public static void SetDifficulty(float difficulty)
    {
        if (difficulty >= 1f && difficulty <= 3f)
        {
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
        } else
        {
            Debug.LogError("Difficulty is out of range");
        }
    }

    public static float GetDifficulty()
    {
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }    
}
