using UnityEngine;
using Math = UnityEngine.Mathf;


public class Easings : MonoBehaviour
{
    //lots of these are from easings.net
    //holy shit what the fuck are these functions
    public static float easeInSine(float x)
    {
        return 1 - Math.Cos(x * Math.PI / 2);
    }

    public static float easeOutSine(float x)
    {
        return Math.Cos(x * Math.PI / 2);
    }

    public static float easeInOutSine(float x)
    {
        return Math.Sin(x * Math.PI / 2);
    }

    public static float easeInQuad(float x)
    {
        return x * x;
    }

    public static float easeOutQuad(float x)
    {
        return 1 - (1 - x) * (1 - x);
    }

    public static float easeInOutQuad(float x)
    {
        return x < 0.5 ? 2 * x * x : 1 - Math.Pow(-2 * x + 2, 2) / 2;
    }

    public static float easeInCubic(float x)
    {
        return x * x * x;
    }

    public static float easeOutCubic(float x)
    {
        return 1 - Math.Pow(1 - x, 3);
    }

    public static float easeInOutCubic(float x)
    {
        return x < 0.5 ? 4 * x * x * x : 1 - Math.Pow(-2 * x + 2, 3) / 2;
    }
    public static float easeInQuart(float x)
    {
        return x * x * x * x;
    }

    public static float easeOutQuart(float x)
    {
        return 1 - Math.Pow(1 - x, 4);
    }

    public static float easeInOutQuart(float x)
    {
        return x < 0.5 ? 8 * x * x * x * x : 1 - Math.Pow(-2 * x + 2, 4) / 2;
    }

    public static float easeInQuint(float x)
    {
        return Math.Pow(x, 5);
    }

    public static float easeOutQuint(float x)
    {
        return 1 - Math.Pow(1 - x, 5);
    }

    public static float easeInOutQuint(float x)
    {
        return x < 0.5 ? 16 * x * x * x * x * x : 1 - Math.Pow(-2 * x + 2, 5) / 2;
    }

    public static float easeInExpo(float x)
    {
        return x == 0 ? 0 : Math.Pow(2, 10 * x - 10);
    }

    public static float easeOutExpo(float x)
    {
        return x == 1 ? 1 : 1 - Math.Pow(2, -10 * x);
    }

    public static float easeInOutExpo(float x)
    {
        return x == 0
        ? 0
        : x == 1
        ? 1
        : x < 0.5 ? Math.Pow(2, 20 * x - 10) / 2
        : (2 - Math.Pow(2, -20 * x + 10)) / 2;
    }

    public static float easeInCirc(float x)
    {
        return 1 - Math.Sqrt(1 - Math.Pow(x, 2));
    }

    public static float easeOutCirc(float x)
    {
        return Math.Sqrt(1 - Math.Pow(x - 1, 2));
    }

    public static float easeInOutCirc(float x)
    {
        return x < 0.5
          ? (1 - Math.Sqrt(1 - Math.Pow(2 * x, 2))) / 2
          : (Math.Sqrt(1 - Math.Pow(-2 * x + 2, 2)) + 1) / 2;
    }

    public static float easeInBack(float x)
    {
        float c1 = 1.70158f;
        float c3 = c1 + 1;

        return c3 * x * x * x - c1 * x * x;
    }

    public static float easeOutBack(float x)
    {
        float c1 = 1.70158f;
        float c3 = c1 + 1;

        return 1 + c3 * Math.Pow(x - 1, 3) + c1 * Math.Pow(x - 1, 2);
    }

    public static float easeInOutBack(float x)
    {
        float c1 = 1.70158f;
        float c2 = c1 * 1.525f;

        return x < 0.5
          ? Math.Pow(2 * x, 2) * ((c2 + 1) * 2 * x - c2) / 2
          : (Math.Pow(2 * x - 2, 2) * ((c2 + 1) * (x * 2 - 2) + c2) + 2) / 2;
    }

    public static float easeInElastic(float x)
    {
        float c4 = 2 * Math.PI / 3;

        return -Math.Pow(2, 10 * x - 10) * Math.Sin((x * 10 - 10.75f) * c4);
    }

    public static float easeOutElastic(float x)
    {
        float c4 = 2 * Math.PI / 3;

        return Math.Pow(2, -10 * x) * Math.Sin((x * 10 - 0.75f) * c4) + 1;
    }

    public static float easeInOutElastic(float x)
    {
        return x < 0.5f
            ? easeInElastic(x * 2)
            : easeOutElastic((x + 0.5f)  * 2);
    }

    // interpolate using functions
    public static float Interp(float i, string eType, string eCurve)
    {
        string easing = $"{eType}{eCurve}";

        return easing switch
        {
            "outsine" => easeOutSine(i),
            "insine" => easeInSine(i),
            "in outsine" => easeInOutSine(i),
            "outquad" => easeOutQuad(i),
            "inquad" => easeInQuad(i),
            "in outquad" => easeInOutQuad(i),
            "outcubic" => easeOutCubic(i),
            "incubic" => easeInCubic(i),
            "in outcubic" => easeInOutCubic(i),
            "outquart" => easeOutQuart(i),
            "inquart" => easeInQuart(i),
            "in outquart" => easeInOutQuart(i),
            "outquint" => easeOutQuint(i),
            "inquint" => easeInQuint(i),
            "in outquint" => easeInOutQuint(i),
            "outexpo" => easeOutExpo(i),
            "inexpo" => easeInExpo(i),
            "in outexpo" => easeInOutExpo(i),
            "outcirc" => easeOutCirc(i),
            "incirc" => easeInCirc(i),
            "in outcirc" => easeInOutCirc(i),
            "outback" => easeOutBack(i),
            "inback" => easeInBack(i),
            "in outback" => easeInOutBack(i),
            "outelastic" => easeOutElastic(i),
            "inelastic" => easeInElastic(i),
            "in outelastic" => easeInOutElastic(i),
            _ => Math.Lerp(0, 1, i),
        };
    }
}
