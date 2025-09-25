using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Collection", menuName = "ArrowGaem/LevelCollectionSO")]
public class LevelCollection : ScriptableObject
{
    public List<LevelData> _levels;

    // returns level from SO
    public LevelData GetLevel(int id)
    {
        // if statement hell for stopgap
        if (id > (_levels.Count - 1))
        {
            return _levels[_levels.Count - 1];
        }
        else if (id < 0)
        {
            return _levels[0];
        }
        else
        {
            return _levels[id];
        }
    }
}
