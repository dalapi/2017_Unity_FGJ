using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class titletrash : MonoBehaviour
{
    private GameObject _Start;
    private float Z = -1.0f;
    // Alpha増減値(点滅スピード調整)
    private float _Step = 0.02f;

    void Start()
    {
        this._Start = GameObject.Find("titletrash");
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    void Update()
    {
        //Z -= 0.1f;
        this._Start.transform.Rotate(0.0f, 0.0f, Z);

    }
}
