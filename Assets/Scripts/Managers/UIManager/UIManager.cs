using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] Canvas gameOverCanvas;
    [SerializeField] Canvas pauseMenuCanvas;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        if (gameOverCanvas != null)
        {
            HideGameOverCanvas();
        }
    }

    public void ShowGameOverCanvas()
    {
        gameOverCanvas.gameObject.SetActive(true);
    }
    public void HideGameOverCanvas()
    {
        gameOverCanvas.gameObject.SetActive(false);
    }
}
