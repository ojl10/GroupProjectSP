using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

// This scirpt is used to close the game when used

public class QuitOnClick : MonoBehaviour
{
    private void OnMouseUp()
    {
        {
            Application.Quit();

        }

    }

}
        