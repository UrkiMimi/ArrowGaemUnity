using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelDropdownSelector : MonoBehaviour
{
    [SerializeField]
    private LevelCollection _levelCollection;

    [SerializeField]
    private TMP_Dropdown _dropdownSelector;


    // set stuff
    void Start()
    {
        // add level collection shit into dropdown options
        _dropdownSelector.ClearOptions();
        
        // bruh
        var tmp = new List<string>();
        foreach (var level in _levelCollection._levels)
        {
            tmp.Add($"{level.songName} - {level.songArtistName}");
        }

        _dropdownSelector.AddOptions(tmp);
    }
}
