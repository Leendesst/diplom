using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;


public class LevelLoaderScript : MonoBehaviour
{
    [SerializeField] private GameObject _loadingObject;

    [SerializeField] private Vector3 _startPos;


    private IEnumerator Start (){

        _startPos = transform.position;

        LeanTween.rotateAround(_loadingObject,Vector3.forward,360,2.5f).setLoopClamp();

        yield return new WaitForSeconds(3f);

        LeanTween.moveY(this.gameObject, _startPos.y - 30, 3f).setEaseOutQuad();

    }

    public void LoadLevel(int intScene){
        StartCoroutine(SceneLoading(intScene));   
    }


    private IEnumerator SceneLoading(int intScene){
        


        GetComponent<CanvasGroup>().alpha = 1;
        GetComponent<CanvasGroup>().interactable = true;
        GetComponent<CanvasGroup>().blocksRaycasts = true;

        LeanTween.moveY(this.gameObject, _startPos.y, 1f).setEaseOutQuad();

        yield return new WaitForSeconds(3f);

        AsyncOperation loadingSceneAsync = SceneManager.LoadSceneAsync(intScene);
        
        PlayerPrefs.SetInt("Deep", PlayerPrefs.GetInt("Deep") + 1);
    }
}
