using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private ICharacterFactory _characterFactory;
    
    public void SetFactory(ICharacterFactory characterFactory)
    {  this._characterFactory = characterFactory; }

    public void CreateCharacter()
    {
        if (this._characterFactory != null)
        {
            Character character = _characterFactory.CreateCharacter();
        }
        else
        {
            Debug.Log("Factory is null");
        }
    }


}
