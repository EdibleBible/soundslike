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

    public void Damage()
    {
        Debug.Log("dupa");
        audioPlayer.PlayAudio(audioClipList[(int)type]);
    }
}
