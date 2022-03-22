using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BulletNum : MonoBehaviour
{
    public TextMeshProUGUI score;
    public static int scoreValue = 0;
    public static bool canShoot;

    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = scoreValue + "";

        if(scoreValue > 0)
        {
            canShoot = true;
        } else
        {
            canShoot = false;
        }
    }
}
