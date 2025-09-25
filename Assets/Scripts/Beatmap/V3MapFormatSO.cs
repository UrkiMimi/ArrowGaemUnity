using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static V3MapFormatData;

[CreateAssetMenu(fileName = "UnnamedMapData", menuName = "ArrowGaem/MapDataSO")]
public class V3MapFormatSO : ScriptableObject
{
    [HideInInspector]
    [SerializeField]
    public string _json;
    
    [HideInInspector]
    // convert json string to map
    public BasicMapData LoadFromJSON()
    {
        // convert json data
        BasicMapData data = JsonConvert.DeserializeObject<BasicMapData>(_json);

        // check map version. return empty map if version isn't v3
        if (data.version == "3.3.0")
        {
            return data;
        }
        else
        {
            Debug.LogError("Error loading map format. Expected map data JSON was unsupported");
            data = new BasicMapData();
            return data;
        }
    }
}
