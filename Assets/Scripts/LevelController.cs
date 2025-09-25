using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class LevelController : MonoBehaviour
{
    // properties
    public LevelCollection _levelCollection;

    public LevelIndexSO _index;

    public BeatmapObjectSpawnerController _beatmapSpawnController;

    public AnimationController _animationController;

    public AudioSyncController _audioSync;

    public ScoreController _scoreC;

    public float _noteOffset;

    // vars
    private float bpm;

    private V3MapFormatData.BasicMapData mapDat;

    [SerializeField]
    private float latency;

    // beatmap reading in realtime type shit
    [HideInInspector]
    public float fixedTime;

    [HideInInspector]
    public float animTime;

    [HideInInspector]
    public LevelData _levelData;

    private int noteIndex = 0;

    private int animatorIndex = 0;
    void Start()
    {
        // load map data
        _levelData = _levelCollection.GetLevel(_index.LevelIndex);

        _audioSync.Init(_levelData.songClip);
        bpm = _levelData.beatsPerMinute;
        mapDat = _levelData.mapData.LoadFromJSON();
        Debug.Log(mapDat.notes.ToString());

        // other init stuff
        _audioSync.Play();
        _scoreC.Init();
    }

    void Update()
    {
        // audio time thingy
        // please fix this lmao
        fixedTime = ((_audioSync.audioTime + (latency/1000)) + _noteOffset) * (bpm / 60);
        animTime = (_audioSync.audioTime + (latency / 1000)) * (bpm / 60);

        // note loop
        if (noteIndex < (mapDat.notes.Count))
        {
            if (fixedTime > mapDat.notes[noteIndex].time)
            {
                _beatmapSpawnController.SpawnNote(mapDat.notes[noteIndex].lane, _noteOffset * (bpm / 60));
                noteIndex++;
            }
        }

        // animator
        // dont run if it doesn't exist
        if (mapDat.animators != null)
        {
            // loop through animators
            if (animatorIndex < (mapDat.animators.Count))
            {
                // parse animators if its overdue
                if (animTime > mapDat.animators[animatorIndex].time)
                {
                    _animationController.ParseAnimatorEvent(mapDat.animators[animatorIndex]);
                    animatorIndex++;
                }
            }
        }

        if (!_audioSync.audioSource.isPlaying)
        {
            SceneManager.LoadScene("SongPicker");
        }
    }
}
