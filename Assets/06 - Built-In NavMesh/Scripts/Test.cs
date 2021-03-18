using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button button = gameObject.GetComponent<Button>();
        string test = "Test";
        string message2 = "Message 2";

        button.onClick.AddListener(() => OnClickWithParameter(test, message2));
    }

    private void OnClickWithParameter(string _message, string _message2)
    {
        Debug.LogError(_message);
        Debug.Log(_message2);
        transform.position += transform.up * 100;
    }
}
