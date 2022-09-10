using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Kogane.Internal
{
    [FilePath( "ProjectSettings/Kogane/AutoImportAssetOnEnterPlayMode.asset", FilePathAttribute.Location.ProjectFolder )]
    internal sealed class AutoImportAssetOnEnterPlayModeSetting : ScriptableSingleton<AutoImportAssetOnEnterPlayModeSetting>
    {
        [SerializeField] private Object[] m_objectArray = Array.Empty<Object>();

        public IReadOnlyList<Object> ObjectList => m_objectArray;

        public void Save()
        {
            Save( true );
        }
    }
}