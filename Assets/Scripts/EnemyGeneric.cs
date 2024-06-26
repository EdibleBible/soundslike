using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SO_Enums;
using static SO_Events;

public class EnemyGeneric : MonoBehaviour, IEnemy
{
    public EnemyType type;
    public AudioPlayer audioPlayer;
    private List<AudioClip> audioClipList = new();
    public SO_Attacks attacks;
    public SO_CurrentLevel levelInfo;
    public int damageToPlayer = 1;

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
        AttackEvent += Damage;
        audioClipList.Add(attacks.attackSound0);
        audioClipList.Add(attacks.attackSound1);
        audioClipList.Add(attacks.attackSound2);
        audioClipList.Add(attacks.attackSound3);
        audioClipList.Add(attacks.attackSound4);
    }

    private void OnDisable() //Unsubscribes from the attack event
    {
        AttackEvent -= Damage;
    }

    private void Start()
    {
        transform.LookAt(levelInfo.heartObject.transform.position);
    }

    public void Damage(int attackIndex)
    {
        if (attackIndex == (int)type)
        {
            if (audioClipList[(int)type] != null)
            {
                audioPlayer.PlayAudio(audioClipList[(int)type]);
            }
            levelInfo.enemiesInLevel.Remove(gameObject);
            gameObject.SetActive(false);
        }
    }
}
