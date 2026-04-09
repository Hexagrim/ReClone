using UnityEngine;
using UnityEditor;

public class LineRendererFix
{
    [MenuItem("Tools/Fix lineRenderer z to zero")]
    static void FixZ()
    {
        LineRenderer[] lines = Object.FindObjectsByType<LineRenderer>(FindObjectsSortMode.None);
        foreach (LineRenderer lr in lines)
        {
            int count = lr.positionCount;
            Vector3[] positions = new Vector3[count];
            lr.GetPositions(positions);
            for (int i = 0; i < count; i++)
            {
                positions[i].z = 0f;
            }
            lr.SetPositions(positions);
            EditorUtility.SetDirty(lr);
        }
        Debug.Log("all lineRenderer z position set to zero");
    }
}
