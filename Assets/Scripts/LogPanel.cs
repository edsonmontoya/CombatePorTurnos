using UnityEngine;
using UnityEngine.UI;

public class LogPanel : MonoBehaviour
{
    public LogPanel current;
    public Text Loglabel;
    private void Awake()
    {
        current = this;
    }
    public  void write(string message)
    {
        current.Loglabel.text = message;
    }

}