using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public LevelController _levelController; 

    [SerializeField]
    private SpriteRenderer _spriteRenderer;

    [HideInInspector]
    public float lifeTime;

    [HideInInspector]
    public int lane; // lane given from beatmap spawn controller

    private float start; // for subtracted time

    private float noteSize = 0.3f; // fixed note size for note placement

    private Vector3 position;

    private float laneOffsetParams; // handles rotation and position for notes

    private string noteLane; // sets the proper note key for input

    private bool activeNote = false;

    private float subtractedTime; // for proper life time

    private float realLifeTime;

    // will place the note in the proper position
    public void Begin()
    {
        // calculate note placement
        laneToTransform(lane);
        Vector3 rotation = transform.localRotation.eulerAngles;
        // lots of issues arose with this when using this with the animator controller
        // so i have to set them which is fucking cringe
        position = new Vector3(laneOffsetParams, -1000, 0); 

        // set rotation
        // local cause animator fucking sucks
        transform.localPosition = position;
        transform.localRotation = Quaternion.Euler(rotation);

        // activate note
        _spriteRenderer.enabled = true;
        start = _levelController.fixedTime;
        activeNote = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (activeNote)
        {
            subtractedTime = _levelController.fixedTime - start;
            realLifeTime =  (subtractedTime / (_levelController._levelData.beatsPerMinute / 60) / (_levelController._noteOffset));

            // lerp y position
            position.y = Mathf.Lerp(1.95f, -1.95f, subtractedTime / (lifeTime * 1.0f));
            transform.localPosition = position;
        }
    }

    private void LateUpdate()
    {
        if (activeNote)
        {
            // temporary. will kill the note after lifetime
            if (realLifeTime > 1.5f)
            {
                _levelController._scoreC.Miss();
                Destroy(this.gameObject);
            }
            
            // hit detection
            // TODO: add scoring
            if (realLifeTime > 0.9f && realLifeTime < 1.1f)
            {
                if (Input.GetButtonDown(noteLane))
                {
                    _levelController._scoreC.Increment();
                    Destroy(this.gameObject);
                }
                _spriteRenderer.color = new Color(1,1,1,1);
            }
            else
            {
                _spriteRenderer.color = new Color(1,0,0,0.5f);
            }
        }
    }

    // bro what the fuck am i doing
    private void laneToTransform(int lane)
    {
        switch (lane)
        {
            case 0:
                laneOffsetParams = noteSize * -3f;
                noteLane = "Left";
                break;
            case 1:
                laneOffsetParams = -noteSize;
                noteLane = "Down";
                break;
            case 2:
                laneOffsetParams = noteSize;
                noteLane = "Up";
                break;
            case 3:
                laneOffsetParams = noteSize * 3f;
                noteLane = "Right";
                break;
        }
    }
}
