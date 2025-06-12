using TMPro;
using UnityEngine;

public class Scorenum : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI textscore;

    void Update()
    {
        textscore.text = score.ToString();
    }
}
