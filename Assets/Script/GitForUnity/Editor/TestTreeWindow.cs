using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.IMGUI.Controls;
using LibGit2Sharp;

public class TestTreeWindow : TreeView
{
    public TestTreeWindow(TreeViewState state, MultiColumnHeader multiColumnHeader) : base(state, multiColumnHeader)
    {

    }

    protected override TreeViewItem BuildRoot()
    {
        return new TreeViewItem(0, -1, "RootNode");
    }

    IEnumerable<Commit> commits;

    internal void SetData(IEnumerable<Commit> mData)
    {
        commits = mData;
        Reload();
    }

    List<TreeViewItem> tRows = new List<TreeViewItem>();
    protected override IList<TreeViewItem> BuildRows(TreeViewItem root)
    {
        int i = 0;
        foreach (var c in commits)
        {
            var item = new TreeViewItem(i, 1, c.Message);
            i++;
            root.AddChild(item);
            tRows.Add(item);
        }

        return tRows;
    }

    protected override IList<int> GetAncestors(int id)
    {
        return base.GetAncestors(id);
    }

    protected override void RowGUI(RowGUIArgs args)
    {
        //for (int visibleColumnIdx = 0; visibleColumnIdx < args.GetNumVisibleColumns(); visibleColumnIdx++)
        //{
        //    Rect cellRect = args.GetCellRect(visibleColumnIdx);

        //    GUIStyle secondaryLabel = nor;
        //    secondaryLabel.Draw(
        //        cellRect, "111111111111111", false, true, false, false);
        //}


        //base.RowGUI(args);
    }

    GUIStyle nor
    {
        get
        {
            var style = new GUIStyle(TreeView.DefaultStyles.label);
            style.fontSize = 11;
            style.alignment = TextAnchor.MiddleLeft;

            style.active = new GUIStyleState() { textColor = new Color(135f / 255, 135f / 255, 135f / 255) };
            style.focused = new GUIStyleState() { textColor = new Color(135f / 255, 135f / 255, 135f / 255) };
            style.hover = new GUIStyleState() { textColor = new Color(135f / 255, 135f / 255, 135f / 255) };
            style.normal = new GUIStyleState() { textColor = new Color(135f / 255, 135f / 255, 135f / 255) };
            style.fontStyle = FontStyle.Bold;

            return style;
        }
    }


}
