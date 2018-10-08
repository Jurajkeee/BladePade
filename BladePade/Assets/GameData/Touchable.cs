using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Touchable : Text
{
    protected override void Awake()
    {
        base.Awake();
    }
}
 
 // Touchable_Editor component, to prevent treating the component as a Text object.
 
