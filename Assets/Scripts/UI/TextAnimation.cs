using System.Collections;
using UnityEngine;

public class TextAnimation : MonoBehaviour
{  
    [SerializeField, TextArea] private string _content;

    [SerializeField] private float _textDelay;

    [SerializeField] private float _startDelay;
    
    IEnumerator Start()
    {
        yield return new WaitForSeconds(_startDelay);

        UnityEngine.UI.Text textComponent = GetComponent<UnityEngine.UI.Text>();
        

        for (int i = 0; i < _content.Length; i++)
        {
            yield return new WaitForSeconds(_textDelay);

            textComponent.text += _content[i];
        }
    }
}
