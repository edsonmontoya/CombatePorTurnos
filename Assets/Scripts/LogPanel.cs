using UnityEngine;
using UnityEngine.UI;

public class LogPanel : MonoBehaviour
{
    protected static LogPanel current;
    public Text Loglabel;
    private void Awake()
    {
        current = this;
    }
    public static void write(string message)
    {
        current.Loglabel.text = message;
    }

}