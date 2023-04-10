using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitApplication : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the "q" key is pressed
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // If running in the editor, exit play mode
            #if UNITY_EDITOR
            if (UnityEditor.EditorApplication.isPlaying)
            {
                UnityEditor.EditorApplication.isPlaying = false;
            }
            #endif

            // Otherwise, quit the application
            Application.Quit();
        }
    }
}
