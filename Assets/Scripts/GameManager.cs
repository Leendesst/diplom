using System.Linq;
using System.Collections;
using UnityEngine;

public enum StepMode { PlayerTurn, EnemyTurn, NoFight }

public class GameManager : MonoBehaviour
{   
    [SerializeField] private static bool _wasWelcome;
    
    public int AsMuchDeep;

    public StepMode GameStape;

    private void Awake() 
    {
        AsMuchDeep = PlayerPrefs.GetInt(key: "Deep");
    }
    void Start()
    {

        if(_wasWelcome){
            Destroy(GameObject.FindGameObjectWithTag(tag: "Welcome"));
        }
        
        StartCoroutine(routine: CycleOfMoving());
    }

    private IEnumerator CycleOfMoving(){

        while(true){
            
            if(GameObject.FindGameObjectsWithTag(tag: "Enemy").Count() == 0)
            {
                GameStape = StepMode.NoFight;
            }
            else
            {

                GameStape = StepMode.PlayerTurn;

                while(GameStape == StepMode.PlayerTurn){

                    yield return new WaitForEndOfFrame();
                }         

                GameStape = StepMode.EnemyTurn;
                yield return new WaitForSeconds(0.1f);

                foreach (var Enemy in GameObject.FindGameObjectsWithTag(tag: "Enemy"))
                {
                    Enemy.GetComponent<NpcControl>().Action();

                    yield return new WaitForSeconds(0.8f);

                }

            }
            
            yield return new WaitForEndOfFrame();
        }
    }

    public void WelcomeSetOn(){
        _wasWelcome = true;
    }

    private void OnApplicationQuit() {
        
        PlayerPrefs.SetInt(key: "Deep",   value: 0);
        PlayerPrefs.SetInt(key: "Heath",  value: 5);
        PlayerPrefs.SetInt(key: "Damage", value: 1);
        _wasWelcome = false;
        
    }
}
