using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFactory : ICharacterFactory
{
    public Character CreateCharacter()
    {
        return new MousePlayer(10.0f);
    }
}
