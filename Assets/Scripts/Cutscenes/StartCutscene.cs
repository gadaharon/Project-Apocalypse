using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCutscene : MonoBehaviour
{
    void OnEnable()
    {
        Dialog.OnDialogComplete += HandleOnDialogComplete;
    }

    void OnDisable()
    {
        Dialog.OnDialogComplete -= HandleOnDialogComplete;
    }

    void HandleOnDialogComplete()
    {
        GameManager.Instance.StartGame();
    }
}
