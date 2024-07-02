using UnityEngine;
using static SO_Enums;
using static SO_Events;

// Handles the basics of enemies
public class EnemyGeneric : MonoBehaviour, IEnemy
{
    public EnemyType type;
    public int damageToPlayer = 1;
    [Tooltip("Enemy attack sound")] public AudioClip attackPattern;
    [Tooltip("SO_Attacks")] public SO_Attacks attacks;
    [Tooltip("SO_CurrentLevel")] public SO_CurrentLevel levelInfo;
    private AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<WebHeart>() != null)
        {
            other.GetComponent<WebHeart>().GetHurt(damageToPlayer);
            gameObject.SetActive(false);
        }
    }

    private void OnEnable() //Subscribes to the attack event
    {
        audioSource = GetComponent<AudioSource>();
        AttackEvent += Damage;
        audioSource.clip = attackPattern;
        audioSource.Play();
    }

    private void OnDisable() //Unsubscribes from the attack event
    {
        AttackEvent -= Damage;
    }

    private void Start()
    {
        transform.LookAt(levelInfo.heartObject.GetComponent<WebJoint>().joints[4].transform.position); // Rotates the enemies towards the center (with a bugfix)
    }

    public void Damage(int attackIndex)
    {
        if (attackIndex == (int)type) // If the attack index & enemy type (as int) are the same, the attack is performed
        {
            levelInfo.enemiesInLevel.Remove(gameObject); // Unindexes the enemy from the list
            gameObject.SetActive(false);
        }
    }
}
