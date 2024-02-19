using UnityEngine;
using UnityEditor;

//[CustomPropertyDrawer(typeof(VFXName), true)]
//public class VFXNameDrawer : PropertyDrawer
//{
//    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
//    {
//        EditorGUI.BeginProperty(position, label, property);

//        EditorGUI.PropertyField(position, property.FindPropertyRelative("vfxname"));

//        EditorGUI.EndProperty();
//    }
//}

[CustomEditor(typeof(VFXCtrl))]
public class VFXCtrlEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        var vfxCtrl = (VFXCtrl)target;

        // Display dropdown to select VFXName subclass
        vfxCtrl.selectedVFXNameIndex = EditorGUILayout.Popup("VFX Name", vfxCtrl.selectedVFXNameIndex, vfxCtrl.vfxNames);

        // Display enum values based on selected subclass
        switch (vfxCtrl.selectedVFXNameIndex)
        {
            case 0:
                vfxCtrl.explosionVFXName = (ExplosionVFXName.ExplosionVFXNameEnum)EditorGUILayout.EnumPopup("Explosion VFX", vfxCtrl.explosionVFXName);
                break;
            case 1:
                vfxCtrl.commonVFXName = (CommonVFXName.CommonVFXNameEnum)EditorGUILayout.EnumPopup("Common VFX", vfxCtrl.commonVFXName);
                break;
            case 2:
                vfxCtrl.spawnVFXName = (SpawnVFXName.SpawnVFXNameEnum)EditorGUILayout.EnumPopup("Spawn VFX", vfxCtrl.spawnVFXName);
                break;
            case 3:
                vfxCtrl.bulletImpactVFXName = (BulletImpactVFXName.BulletImpactVFXNameEnum)EditorGUILayout.EnumPopup("BulletImpact VFX", vfxCtrl.bulletImpactVFXName);
                break;
            case 4:
                vfxCtrl.shieldImpactImpactVFXName = (ShieldImpactVFXName.ShieldImpactVFXNameEnum)EditorGUILayout.EnumPopup("ShieldImpact VFX", vfxCtrl.shieldImpactImpactVFXName);
                break;
            default:
                break;
        }
    }
}