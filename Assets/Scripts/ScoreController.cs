using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [HideInInspector]
    public int noteCombo;

    [HideInInspector]
    public int score;

    [SerializeField]
    private TextMeshPro _comboText;

    [SerializeField]
    private TextMeshProUGUI _scoreTex;

    [SerializeField]
    private Animator _comboAnimator;

    [SerializeField]
    private Animator _scoreAnimator;

    private string cTrigger = "ComboUp";

    // basic stuff
    public void Init()
    {
        score = 0;
        noteCombo = 0;
    }

    public void Increment()
    {
        score += 110;
        noteCombo++;
        _comboAnimator.Play(cTrigger, -1 , 0);
        _scoreAnimator.Play(cTrigger, -1 ,0);
    }

    public void Miss()
    {
        noteCombo = 0;
    }

    // update ui
    void Update()
    {
        if (score != 0)
        {
            _scoreTex.text = score.ToString("# ### ### ###");
        }
        _comboText.text = noteCombo.ToString();
    }
}
