using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    private int score;
    private string text;
    private TextMesh ScoreText;

    public GameObject ScoreObj;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        text = "Score: 0";
        ScoreText = GameObject.Find(ScoreObj.name).GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider obj)
    {
        if(obj.gameObject.name == "Ball")
        {
            score += 1;
            text = "Score: " + score.ToString();
            ScoreText.text = text;
            Debug.Log(text);
        }
    }
}
