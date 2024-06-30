using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    [SerializeField]
    Transform pointPrefab;

    private void Awake()
    {
        var position = Vector3.zero;
        var scale = Vector3.one / 5f;
        for (int i = 0; i < 10; i++)
        {
            Transform point = Instantiate(pointPrefab);
            position.x = (i + 0.5f) / 5f - 1f;
            position.y = position.x;
            point.localPosition = position;
            point.localScale = scale;
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
