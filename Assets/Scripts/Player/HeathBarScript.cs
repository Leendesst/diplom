using System.Collections.Generic;
using UnityEngine;

public class HeathBarScript : MonoBehaviour
{
    [SerializeField] private List<GameObject> Points = new List<GameObject>();
    
    [SerializeField] private GameManager _manager;
    
    private ICreature _creature;

    public GameObject ExampleOfHeath; 

    public Transform Target;




    private void Start() 
    {
        _creature = Target.GetComponent<ICreature>();
        _manager = GameObject.FindGameObjectWithTag(tag: "GameController").GetComponent<GameManager>();
    }

    void Update()
    {

        if(_manager.GameStape == StepMode.NoFight)
        {
            GetComponent<CanvasGroup>().alpha = 0;

            foreach (var Point in Points)
            {
                Point.SetActive(value: false);
            }

            return;
        }
        else
        {
            GetComponent<CanvasGroup>().alpha = 1;

            foreach (var Point in Points)
            {
                Point.SetActive(value: true);
            }
        }


        if(!Target)
        {
            Destroy(obj: this.gameObject);
            return;
        }

        transform.position = Target.position;


        if(Points.Count != _creature.Heath)
        {

            foreach (var HeathPoint in Points)
            {
                Destroy(obj: HeathPoint);
            }
            
            Points.Clear();

            for (int i = 0; i < _creature.Heath; i++)
            {
                GameObject newHeath = Instantiate(original: ExampleOfHeath, position: transform.position, rotation: Quaternion.identity, parent: transform);

                Points.Add(item: newHeath);
            }
            

        }


        
    }
   
}

