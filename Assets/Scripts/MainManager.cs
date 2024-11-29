using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager instance;//Static variables are shared by all instances of an object
    public Color teamColour;
    private int type;
    public static int numCreated = 0;
    
    private void Awake()
    {
        numCreated = numCreated + 1;
        type = numCreated;        
        Debug.Log("Initiated MainManager No. " + type);
        if(instance != null)//If Instance already exists; so has already been created
        {
            Debug.Log("Duplicate found, destroying.");
            Destroy(gameObject);//Destroy this game object; to prevent duplication.
        }
        else
        {
            instance = this;//Set the MainManager script variable, Instance, to this current instance
            DontDestroyOnLoad(gameObject);//Don't destroy this game object when changing scenes
            Debug.Log("I am No. " + type);
        }
        /**
            Dev Note:
            Tutorial code had a fatal error causing duplication despite
            a single object only meaning to exist at a single time;
            it described only an if statement to check if the instance
            variable was null, but still defined the object if it
            managed to pass this check. For some reason, every
            second instance managed to pass. Encapsulating the first-
            creation code within an 'else' statement prevents this.
        */
    }
}
