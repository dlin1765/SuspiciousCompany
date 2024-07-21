using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    [SerializeField]
    Transform pointPrefab;

    [SerializeField]
    int resolution = 50;

    public enum Function{
        Wave,
        MultiWave,
        Ripple,
    }

    [SerializeField] Function currentFunction = Function.Wave;

    private Transform[] points;
    private void Awake()
    {
        points = new Transform[resolution];
        float step = 2f / resolution;
        var position = Vector3.zero;
        var scale = Vector3.one * step;
        for (int i = 0; i < resolution; i++)
        {
            Transform point = points[i] = Instantiate(pointPrefab);
            point.SetParent(transform, false);
            position.x = (i + 0.5f) * step - 1f;
            point.localPosition = position;
            point.localScale = scale;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(Animate());
    }

    // Update is called once per frame
    void Update()
    {
        float time = Time.time;
        for(int i = 0; i < points.Length; i++)
        {
            Transform point = points[i];
            Vector3 position = point.localPosition;
            switch (currentFunction)
            {
                case Function.Wave:
                    position.y = FunctionLibrary.Wave(position.x, time);
                    break;
                case Function.MultiWave:
                    position.y = FunctionLibrary.MultiWave(position.x, time);
                    break;
                case Function.Ripple:
                    position.y = FunctionLibrary.Ripple(position.x, time);
                    break;
            }
            point.localPosition = position;
        }
    }
    /*
    private IEnumerator Animate()
    {
        
        float time = Time.time;
        for (int i = 0; i < points.Length; i++)
        {
            Transform point = points[i];
            Vector3 position = point.localPosition;
            position.y = Mathf.Sin(Mathf.PI * (position.x + time));
            point.localPosition = position;
            yield return null;
        }
        StartCoroutine(Animate());
        
    }
    */
}
