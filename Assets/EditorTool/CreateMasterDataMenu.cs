using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CreateMasterDataMenu : Editor {

    [MenuItem("MasterData/Stats")]
    static void Create()
    {
        var instance = CreateInstance<Pekemon.Battle.PicaStats>();

        AssetDatabase.CreateAsset(instance, "Assets/EditorTool/PicaStats.asset");
    }
}
