using UnityEngine;
using UnityEngine.SceneManagement;

public static class LevelLoader
{
    static readonly string[] GamePlayLevels = { LevelsEnum.LevelOne, LevelsEnum.LevelTwo, LevelsEnum.LevelThree, LevelsEnum.LevelFour };
    static int currentLevelIndex = 0;

    public static void LoadNextLevel()
    {
        currentLevelIndex++;

        if (currentLevelIndex < GamePlayLevels.Length)
        {
            SceneManager.LoadScene(GamePlayLevels[currentLevelIndex]);
        }
        else
        {
            Debug.Log("No More Levels");
            SceneManager.LoadScene(GamePlayLevels[GamePlayLevels.Length - 1]);
        }
    }

    public static void LoadMainMenuScene()
    {
        SceneManager.LoadScene(LevelsEnum.MainMenu);
    }

    public static void LoadStoreLevel()
    {
        SceneManager.LoadScene(LevelsEnum.Store);
    }

    public static void StartFromFirstLevel()
    {
        currentLevelIndex = 0;
        SceneManager.LoadScene(GamePlayLevels[currentLevelIndex]);
    }

    public static string GetCurrentLevel()
    {
        return SceneManager.GetActiveScene().name;
    }

    public static int GetLevelNumber()
    {
        return currentLevelIndex + 1;
    }
}
