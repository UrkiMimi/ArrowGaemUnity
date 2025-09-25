using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteGuideController : MonoBehaviour
{
    [SerializeField]
    private noteType pickedNote;

    [SerializeField]
    private float returnSpeed;

    private enum noteType
    {
        Left, Right, Up, Down
    }

    private float scale = 1f;

    private void Start()
    {
        scale = 1f;
    }

    void Update()
    {
        // animate
        if (Input.GetButtonDown(pickedNote.ToString()))
        {
            scale = 0.9f;
        }

        scale = Mathf.Lerp(scale, 1f, Time.deltaTime * returnSpeed);

        transform.localScale = new Vector3(scale, scale, scale);
    }
}
