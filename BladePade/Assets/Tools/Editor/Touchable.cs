using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class Touchable : Text
{
    protected override void Awake()
    {
        base.Awake();
    }
}
 

 [CustomEditor(typeof(Touchable))]
public class Touchable_Editor : Editor
{
    public void OnInspectorGUI()
    {
        // Do nothing
    }
}
