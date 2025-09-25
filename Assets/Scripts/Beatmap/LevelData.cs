using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "ArrowGaem/LevelSO")]
public class LevelData : ScriptableObject
{
    // properties
    [Header("Song Attributes")]
    public string songName;

    public string songArtistName;

    public string levelCreatorName;

    [Header("Audio")]
    public float beatsPerMinute;

    public AudioClip songClip;


    // temporary
    public V3MapFormatSO mapData;

}
