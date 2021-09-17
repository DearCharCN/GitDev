using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TestWindow : EditorWindow
{
    [MenuItem("Git for Unity/OpenWindows")]
    public static void CreateTestWindow()
    {
        TestWindow tw = GetWindow<TestWindow>();
    }
}
