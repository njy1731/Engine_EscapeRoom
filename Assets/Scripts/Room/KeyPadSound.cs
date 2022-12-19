using UnityEngine;
using System.Collections;

public class KeyPadSound : MonoBehaviour 
{
	public void KeyPadClick () {
		GetComponent<AudioSource>().Play();
	}
}
