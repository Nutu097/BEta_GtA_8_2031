using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
[CustomEditor(typeof(bob_spawner))]
public class bob_ediit : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        bob_spawner spawner = (bob_spawner)target;

        EditorGUILayout.Space(3);


        if (GUILayout.Button("find points", GUILayout.Height(30)))
        {
            spawner.FindSpawnPoints();
            EditorUtility.SetDirty(spawner);
        }
        
    }

}
#endif