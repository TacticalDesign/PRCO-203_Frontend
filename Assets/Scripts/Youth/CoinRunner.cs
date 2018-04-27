using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(Coins))]
public class CoinRunner : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (!Application.isPlaying)
        {
            GUILayout.Label("Run the app to be enable running the coins");
            return;
        }

        Coins myScript = (Coins)target;

        GUILayout.Label("Is running: " + (myScript.isRunning? "true" : "false"));

        if (GUILayout.Button("Fire!"))
        {
            myScript.Fire();
        }
    }
}