using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class BeatmapObjectSpawnerController : MonoBehaviour
{
    public LevelController _levelController;

    [SerializeField]
    private GameObject _notePrefab;

    [SerializeField]
    private GameObject _animatorPrefab;
    public void SpawnNote(int lane, float time)
    {
        // what the fuck
        GameObject noteGO = Instantiate(_notePrefab, _animatorPrefab.transform);
        Note noteScript = noteGO.GetComponent<Note>();
        noteScript.lane = lane;
        noteScript.lifeTime = time;
        noteScript.Begin();
    }
}
