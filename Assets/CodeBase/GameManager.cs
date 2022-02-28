using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletoneMonobehaveor<GameManager>
{
   public int Score;
   private int _addScore =10;

   public void AddScore()
   {
      Score += _addScore;
   }

   public void RemoveScore()
   {
      Score -= _addScore;
   }
}
