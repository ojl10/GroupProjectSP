using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

// This script is used to load a new scene
// The number of the scene that needs to be loaded must be put into brackets
// Use 0 for the Main Menu
// Use 1 for the Game

public class LoadSceneOnClick : MonoBehaviour
{
    private void OnMouseUp()
    {
       
        {
            SceneManager.LoadScene(1);
        }
    }

}