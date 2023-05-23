using UnityEngine;

public class GameOverScript : MonoBehaviour
{   
    [SerializeField] private GameObject _text;

    [SerializeField] private Vector3 _startPos;
    
    
    void Start()
    {
        _startPos = transform.position;

        LeanTween.moveY(this.gameObject, _startPos.y - 30, 3f).setEaseOutQuad();
    }
    
    public void ShowingWindow(){
        
        CanvasGroup cGroup = GetComponent<CanvasGroup>();

        cGroup.alpha = 1;
        cGroup.blocksRaycasts = true;
        cGroup.interactable = true;

        LeanTween.moveY(this.gameObject, _startPos.y, 3f).setEaseOutQuad();

        _text.SetActive(true);
    }

    public void RestartGame(){
        
        PlayerPrefs.SetInt("Deep", -1);
        PlayerPrefs.SetInt("Heath", 5);
        PlayerPrefs.SetInt("Damage", 1);

        GameObject.FindGameObjectWithTag("LevelLouder").GetComponent<LevelLoaderScript>().LoadLevel(0);
    }
}

