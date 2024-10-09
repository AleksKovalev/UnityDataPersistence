using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
    public TMP_InputField nameField;

    public void DidClickStart()
    {
        string name = nameField.text;
        if (name != null && name.Length > 0)
        {
            StateStorage.instance.currentUserName = name;
            SceneManager.LoadScene(1);
        }
    }

    public void DidClickExit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
