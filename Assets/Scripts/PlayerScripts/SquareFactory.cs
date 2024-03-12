using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareFactory : ICharacterFactory
{
    public Character CreateCharacter()
    {
        return new SquarePlayer(200.0f);
    }
}
