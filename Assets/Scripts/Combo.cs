using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// Para que quando referênciado em outro script, ele possa aparecer na aba inspector
[Serializable]
//  Classe que mantém os hits, porque cada combo pode possuir uma quantidade diferente de hits
public class Combo 
{
    public Hit[] hits;
    

}

[Serializable]
// Está classe terá as propriedades de cada golpe executado
public class Hit 
{
    public string animation;
    public string inputButton;
    public float animationTime;
    public float resetTime;

    public int damage;
    public AudioClip hitSound;
    public bool slowDown;
    

}





















