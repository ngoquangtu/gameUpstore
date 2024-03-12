using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleFactory : ICharacterFactory
{
    public Character CreateCharacter()
    {
        return new TrianglePlayer(10.0f);
    }
}
