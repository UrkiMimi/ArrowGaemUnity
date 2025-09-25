using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField]
    private LevelController _levelController;

    [SerializeField]
    private GameObject _posAnimatorGO;

    [SerializeField]
    public List<AnimatorTask> aTasks = new List<AnimatorTask>();

    // animation task class
    public class AnimatorTask
    {
        public float duration;

        public float time;

        public string target;

        public Vector3 init;

        public Vector3 final;

        public string eType;

        public string eCurve;
    }

    private void Start()
    {
        Shader.SetGlobalVector("_SinAmp", Vector4.zero);
    }

    // update
    private void Update()
    {
        // loop over events
        foreach (var e in aTasks)
        {
            float t = Mathf.Clamp01((_levelController.animTime - e.time) / e.duration);
            float eT = Easings.Interp(t, e.eType, e.eCurve);

            // animate switch case
            switch (e.target)
            {
                case "pos": // position
                    _posAnimatorGO.transform.position = Vector3.LerpUnclamped(e.init, e.final, eT);
                    break;
                case "rot": // rotation
                    _posAnimatorGO.transform.rotation = Quaternion.Euler(
                        Vector3.LerpUnclamped(e.init, e.final, eT));
                    break;
                case "sin": // sin
                    Shader.SetGlobalVector("_SinAmp", Vector4.LerpUnclamped(e.init, e.final, eT));
                    break;
                default:
                    break;
            }
        }

        // garbage collection loop
        for (var i = aTasks.Count - 1; i >= 0; --i)
        {
            // get stuff to determine if animation is complete
            var e = aTasks[i];
            float t = (_levelController.animTime - e.time) / e.duration;

            // remove task if duration is complete
            if (t > 1.1f)
            {
                aTasks.RemoveAt(i);
            }
        }
    }

    public void ParseAnimatorEvent(V3MapFormatData.AnimatorData animDat)
    {
        //stopgap
        if (animDat.init.Count == 0)
        {
            return;
        }

        // convert floats to vectors
        var init = new Vector3(animDat.init[0], animDat.init[1], animDat.init[2]);
        var final = new Vector3(animDat.final[0], animDat.final[1], animDat.final[2]);

        // conversion shit cause scratch 3d bad
        if (animDat.type == "pos")
        {
            init /= 13.5f;
            final /= 13.5f;
            init.z *= -1;
            final.z *= -1;
        }

        // add animator task
        aTasks.Add(new AnimatorTask
        {
            duration = animDat.duration,
            time = animDat.time,
            target = animDat.type,
            init = init,
            final = final,
            eType = animDat.eType,
            eCurve = animDat.eCurve,
        });
    }
}
