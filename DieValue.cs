//example provided by http://www.cookingwithunity.com/

using UnityEngine;
using System.Collections;

public class DieValue : MonoBehaviour
{
	public int value = 1;
}

//This script is necessary for attaching to the gameObject or die within the game. This gives it a value that can be changed from within the inspector. In fact, this is used on the corresponding sides on the die.
//Each side changes the value of this script to 1-6 depending on the side it is attached to. This is so the game could pick up which side is facing up to count the score.
