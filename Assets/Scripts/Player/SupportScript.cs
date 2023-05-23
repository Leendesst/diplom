using UnityEngine;

public class SupportScript : MonoBehaviour
{   
    [SerializeField] private int _newHp;
    [SerializeField] private int _newDamage;

    private void OnCollisionEnter2D(Collision2D other) {

        if(other.gameObject.tag == "Player"){
            
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>().Heath += _newHp;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>().GetComponent<IDamageable<int>>().OutDamage += _newDamage;

            Destroy(obj: this.gameObject);

        }
    }
}
