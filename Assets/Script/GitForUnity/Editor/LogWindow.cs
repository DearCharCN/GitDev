using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using LibGit2Sharp;
using UnityEditor.IMGUI.Controls;
using static UnityEditor.IMGUI.Controls.MultiColumnHeaderState;

namespace GitForUnity
{
    public class LogWindow : EditorWindow
    {
        [MenuItem("Git for Unity/Log Window")]
        public static void CreateTestWindow()
        {
            LogWindow tw = GetWindow<LogWindow>("GitLog");
            IRepositoryEntry rp = RepositoryManager.GetProjectRepository();
            tw.Init(rp);
        }

        IRepositoryEntry repository = null;
        TestTreeWindow tableView;
        private void Init(IRepositoryEntry rp)
        {
            repository = rp;

            TreeViewState treeViewState = new TreeViewState();
            Column[] columns = new Column[2];
            Column column0 = new Column()
            {
                width = 550,
                headerContent = new GUIContent(
                            "路径"),
                minWidth = 200,
                allowToggleVisibility = false,
            };
            Column column1 = new Column()
            {
                width = 200,
                headerContent = new GUIContent(
                            "作者"),
                minWidth = 80
            };
            columns[0] = column0;
            columns[1] = column1;
            MultiColumnHeaderState multiColumnHeaderState = new MultiColumnHeaderState(columns);
            MultiColumnHeader multiColumnHeader = new MultiColumnHeader(multiColumnHeaderState);
            tableView = new TestTreeWindow(treeViewState, multiColumnHeader);
            IQueryableCommitLog historyLogs = repository.Repository.Commits;
            tableView.SetData(historyLogs);
        }

        
        private void OnGUI()
        {
            if (repository == null)
            {
                GUILayout.Label("当前没有 Git 仓库");
                return;
            }

            GUILayout.BeginVertical();
            GUILayout.Label(string.Format("当前在 {0} 分支", repository.Repository.Head.RemoteName));
            Rect rect = GUILayoutUtility.GetRect(0, 100000, 0, 100000);
            tableView.OnGUI(rect);
            GUILayout.EndVertical();
        }
    }
}


