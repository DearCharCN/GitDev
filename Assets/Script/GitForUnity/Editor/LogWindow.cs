using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using LibGit2Sharp;

namespace GitForUnity
{
    public class LogWindow : EditorWindow
    {
        [MenuItem("Git for Unity/Log Window")]
        public static void CreateTestWindow()
        {
            LogWindow tw = GetWindow<LogWindow>();



            //Repository.IsValid()
        }

        private void OnGUI()
        {
            GUILayout.Label(System.Environment.CurrentDirectory);

            GUILayout.Label(Repository.IsValid(System.Environment.CurrentDirectory).ToString());
            GUILayout.Label(Repository.IsValid(Application.dataPath).ToString());
            GUILayout.Label(Repository.IsValid("gdfdgfg").ToString());
            GUILayout.Label(System.IO.Directory.Exists("gdfdgfg").ToString());
            
            //GUILayout.Label(Application.dataPath);

        }
    }
}


