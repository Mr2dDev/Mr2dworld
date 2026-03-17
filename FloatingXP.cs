using UnityEngine;
using TMPro;

public class FloatingXP : MonoBehaviour
{
    private TextMeshProUGUI text;

    void Awake()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void SetText(string value)
    {
        if (text != null)
        {
            text.text = value;
        }
    }

    void Start()
    {
        Destroy(gameObject, 2f);
    }
}