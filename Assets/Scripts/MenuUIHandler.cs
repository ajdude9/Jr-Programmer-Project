using System;
using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
    using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public ColorPicker ColorPicker;

    public void NewColorSelected(Color colour)
    {
        MainManager.instance.teamColour = colour;
    }
    
    private void Start()
    {
        ColorPicker.Init();
        //this will call the NewColorSelected function when the color picker has a color button clicked.
        ColorPicker.onColorChanged += NewColorSelected;
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);//Load the main scene
    }

    public void changeScene(int scenePos)
    {
        SceneManager.LoadScene(scenePos);
    }

    public void Exit()
    {
        #if UNITY_EDITOR//Specialised compiler if statement to detected editor mode
            EditorApplication.ExitPlaymode();//Exit playmode if viewing the editor
        #else
            Application.Quit();//Quit the game and close the window
        #endif
    }
}
