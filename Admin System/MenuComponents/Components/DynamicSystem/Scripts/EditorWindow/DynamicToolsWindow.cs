﻿#if UNITY_EDITOR
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities;
using Sirenix.Utilities.Editor;
using UnityEditor;
using UnityEngine;

namespace MenuComponents.DynamicSystem
{
    public class DynamicToolsWindow : OdinMenuEditorWindow
    {
        private const string ScriptableObjectsPath = "MenuComponents/Components/DynamicSystem/DynamicScriptableObjects";
        
        /// <summary>
        /// Opens the Admin System's control panel and center aligns it. 
        /// </summary>
        [MenuItem("AdminSystem/Control Panel")]
        private static void OpenWindow()
        {
            var window = GetWindow<DynamicToolsWindow>();
            window.position = GUIHelper.GetEditorWindowRect().AlignCenter(800, 600);
        }

        /// <summary>
        /// Builds out the menu tree.
        /// </summary>
        /// <returns>Returns the Odin Menu Tree</returns>
        protected override OdinMenuTree BuildMenuTree()
        {
            var tree = new OdinMenuTree(supportsMultiSelect: true)
            {
                { "Home", this, EditorIcons.House },
                { "Data Entry", this, EditorIcons.File },
                { "Colour", BaseDynamicManager.Instance, EditorIcons.EyeDropper },
                { "Text Colour", BaseDynamicManager.Instance, EditorIcons.SpeechBubbleRound },
                { "Text Font", BaseDynamicManager.Instance, EditorIcons.PenAdd },
                { "Logos", BaseDynamicManager.Instance, EditorIcons.Image }
            };

            tree.AddAllAssetsAtPath("Colour", $"{ScriptableObjectsPath}/ColourPallets", typeof(ScriptableObject), true);
        
            tree.AddAllAssetsAtPath("Text Colour", $"{ScriptableObjectsPath}/FontColourPallets", typeof(ScriptableObject), true);
            
            tree.AddAllAssetsAtPath("Text Font", $"{ScriptableObjectsPath}/FontData", typeof(ScriptableObject), true);
        
            tree.AddAllAssetsAtPath("Logos", $"{ScriptableObjectsPath}/LogoImages", typeof(ScriptableObject), true);

            return tree;
        }
    }
}
#endif