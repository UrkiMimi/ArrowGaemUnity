using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System;

public class V3MapFormatData
{
    // map format class
    public class BasicMapData
    {
        [JsonProperty("colorNotes")]
        public List<NoteData> notes;

        public string version;

        [JsonProperty("cameraEvents")]
        public List<AnimatorData> animators {  get; set; } 
    }

    // note class
    public class NoteData
    {
        [JsonProperty("b")]
        public float time { get; set; }

        [JsonProperty("x")]
        public int lane { get; set; }
    }

    public class AnimatorData
    {
        [JsonProperty("b")]
        public float time { get; set; } // time

        [JsonProperty("d")]
        public float duration { get; set; } // duration

        [JsonProperty("t")]
        public string type { get; set; } // type

        public string eType { get; set; } // easing type

        public string eCurve { get; set; } // easing curve

        public List<float> init { get; set; } //inital

        public List<float> final { get; set; } // final
    }
}
