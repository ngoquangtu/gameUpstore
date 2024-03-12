using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleFactory : ICharacterFactory
{
    public Character CreateCharacter()
    {
        return new CirclePlayer(10.0f);
    }
}
