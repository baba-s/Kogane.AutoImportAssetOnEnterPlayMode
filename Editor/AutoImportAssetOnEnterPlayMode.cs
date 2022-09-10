using System.Linq;
using UnityEditor;

namespace Kogane.Internal
{
    [InitializeOnLoad]
    internal static class AutoImportAssetOnEnterPlayMode
    {
        static AutoImportAssetOnEnterPlayMode()
        {
            void OnChanged( PlayModeStateChange change )
            {
                var settings = AutoImportAssetOnEnterPlayModeSetting.instance;
                if ( settings == null ) return;
                var objectList = settings.ObjectList;
                if ( objectList is not { Count: > 0 } ) return;
                if ( change != PlayModeStateChange.ExitingEditMode ) return;

                foreach ( var path in objectList.Select( x => AssetDatabase.GetAssetPath( x ) ) )
                {
                    AssetDatabase.ImportAsset( path, ImportAssetOptions.ImportRecursive );
                }
            }

            EditorApplication.playModeStateChanged += OnChanged;
        }
    }
}