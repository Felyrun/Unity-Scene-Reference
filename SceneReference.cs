using System;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace UnityEngine.SceneManagement
{
    [Serializable]
    public struct SceneReference : ISerializationCallbackReceiver
    {
        #if UNITY_EDITOR
        [SerializeField] private SceneAsset asset;
        #endif

        [SerializeField] private string name;

        public void OnAfterDeserialize() { }

        public void OnBeforeSerialize()
        {
            #if UNITY_EDITOR
            name = asset? asset.name : string.Empty;
            #endif
        }

        public static implicit operator string(SceneReference scene)
        {
            return scene.name;
        }

        #if UNITY_EDITOR
        [CustomPropertyDrawer(typeof(SceneReference))]
        public class SceneReferencePropertyDrawer : PropertyDrawer
        {            
            public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
            {
                EditorGUI.ObjectField(position, property.FindPropertyRelative(nameof(asset)), label);
            }
        }
        #endif
    }
}
