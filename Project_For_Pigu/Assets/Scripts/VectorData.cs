using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VectorData : MonoBehaviour {
    float x;
    float y;
    [SerializeField]
    InputField left;
    [SerializeField]
    InputField right;
	// Use this for initialization
	void Start () {
        left.onValueChanged.AddListener((string value)=> {
            float.TryParse(value, out x);
        });
        right.onValueChanged.AddListener((string value) => {
            float.TryParse(value, out y);
        });
    }
    public Vector2 getValue()
    {
        return new Vector2(x, y);
    }

}
