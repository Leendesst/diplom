using UnityEngine;

public class PortalScript : MonoBehaviour
{   
    [SerializeField] private GameObject _interactUi;

    public int ToScene;


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player"){
            _interactUi.SetActive(value: true);
        }
    }

    private void OnTriggerStay2D(Collider2D other) 
    {
        if(other.tag == "Player" && Input.GetKey(KeyCode.E))
        {
            PlayerPrefs.SetInt(key: "Heath", value: other.GetComponent<ICreature>().Heath);
            PlayerPrefs.SetInt(key: "Damage",value:  other.GetComponent<IDamageable<int>>().OutDamage);

            GameObject.FindGameObjectWithTag( tag: "LevelLouder").GetComponent<LevelLoaderScript>().LoadLevel(intScene: ToScene);
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.tag == "Player"){
            _interactUi.SetActive(value: false);
        }
    }
}