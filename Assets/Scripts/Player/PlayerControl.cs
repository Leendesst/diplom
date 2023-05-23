using UnityEngine;


public class PlayerControl : MonoBehaviour
{
    [Header("Moving")]
    [SerializeField] private float _movingspeed;
    [SerializeField] private Transform _movingpoint;
    private GameManager _manager;
    public LayerMask DoNotMovingHere;

    [Header("Other")]
    public GameObject HealthBarPrefab;

    
    
    

    void Start()
    {
        _manager = GameObject.FindGameObjectWithTag(tag: "GameController").GetComponent<GameManager>();

        _movingpoint.parent = null;

        Transform canvas = GameObject.FindGameObjectWithTag(tag: "GameCanvas").GetComponent<Transform>();
        
        GameObject healthBar = Instantiate( original: HealthBarPrefab, position: transform.position, rotation: Quaternion.identity, parent: canvas);

        healthBar.GetComponent<HeathBarScript>().Target = this.transform;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(current: transform.position, target: _movingpoint.position, maxDistanceDelta: _movingspeed * Time.deltaTime);


        if(_manager.GameStape == StepMode.PlayerTurn || _manager.GameStape == StepMode.NoFight){

            GameObject[] enemies = GameObject.FindGameObjectsWithTag(tag: "Enemy");
            
            foreach (var Enemy in enemies)
            {
                int distanceToEnemy = Mathf.RoundToInt(f: UnityEngine.Vector3.Distance(this.transform.position, Enemy.transform.position));

                if(distanceToEnemy == 1)
                {
                    Enemy.GetComponent<NpcControl>().ActiveForAttack = true;
                }
                else
                {
                    Enemy.GetComponent<NpcControl>().ActiveForAttack = false;
                }
                
            }


            if (Input.GetAxisRaw( axisName:"Horizontal") == 1f || Input.GetAxisRaw( axisName: "Vertical") == 1f)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            else if (Input.GetAxisRaw( axisName: "Horizontal") == -1f || Input.GetAxisRaw( axisName: "Vertical") == -1f )
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }


            if (Vector3.Distance( a: transform.position, b: _movingpoint.position) <= 0.05f)
            {
                if (Mathf.Abs(Input.GetAxisRaw( axisName: "Horizontal")) == 1f)
                {
                    if (!Physics2D.OverlapCircle(point: _movingpoint.position + new Vector3(Input.GetAxisRaw( axisName: "Horizontal"), 0f, 0f), radius: 0.2f, layerMask: DoNotMovingHere))
                    {
                        _movingpoint.position += new Vector3(x: Input.GetAxisRaw( axisName: "Horizontal"), y: 0f, z: 0f);
                        
                        if(_manager.GameStape != StepMode.NoFight)
                            _manager.GameStape = StepMode.EnemyTurn;
                    }
                }
                else if (Mathf.Abs(Input.GetAxisRaw( axisName: "Vertical")) == 1f)
                {

                    if (!Physics2D.OverlapCircle(point: _movingpoint.position + new Vector3(0f, Input.GetAxisRaw( axisName: "Vertical"), 0f), radius: 0.2f, layerMask: DoNotMovingHere))
                    {
                        _movingpoint.position += new Vector3(x: 0f, y: Input.GetAxisRaw( axisName: "Vertical"), z: 0f);
                        
                        if(_manager.GameStape != StepMode.NoFight)
                            _manager.GameStape = StepMode.EnemyTurn;
                    }
                }

            }
        } 
    }
}

