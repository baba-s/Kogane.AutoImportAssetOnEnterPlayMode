using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Kogane.Internal
{
    internal sealed class AutoImportAssetOnEnterPlayModeSettingProvider : SettingsProvider
    {
        private const string PATH = "Kogane/Auto Import Asset On Enter Play Mode";

        private Editor m_editor;

        private AutoImportAssetOnEnterPlayModeSettingProvider
        (
            string              path,
            SettingsScope       scopes,
            IEnumerable<string> keywords = null
        ) : base( path, scopes, keywords )
        {
        }

        public override void OnActivate( string searchContext, VisualElement rootElement )
        {
            var instance = AutoImportAssetOnEnterPlayModeSetting.instance;

            instance.hideFlags = HideFlags.HideAndDontSave & ~HideFlags.NotEditable;

            Editor.CreateCachedEditor( instance, null, ref m_editor );
        }

        public override void OnGUI( string searchContext )
        {
            using var changeCheckScope = new EditorGUI.ChangeCheckScope();

            m_editor.OnInspectorGUI();

            if ( !changeCheckScope.changed ) return;

            AutoImportAssetOnEnterPlayModeSetting.instance.Save();
        }

        [SettingsProvider]
        private static SettingsProvider CreateSettingProvider()
        {
            return new AutoImportAssetOnEnterPlayModeSettingProvider
            (
                path: PATH,
                scopes: SettingsScope.Project
            );
        }
    }
}