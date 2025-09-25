using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoButton : MonoBehaviour
{
    public LevelIndexSO _index;

    public TMPro.TMP_Dropdown _dropDown;

    // Start is called before the first frame update
    
    public void StartGame()
    {
        _index.LevelIndex = _dropDown.value;
        SceneManager.LoadScene("MainGameScene");
    }
}
