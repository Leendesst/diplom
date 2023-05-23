using UnityEngine;
using UnityEngine.UI;

public class DeepTextScript : MonoBehaviour
{
    void Update()
    {
        GetComponent<Text>().text = GameObject.FindGameObjectWithTag( tag: "GameController").GetComponent<GameManager>().AsMuchDeep.ToString();
    }
}
