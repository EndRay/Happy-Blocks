using UnityEngine;

public class DestroyAll : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnMouseDown()
    {
        foreach (var obj in GameObject.FindGameObjectsWithTag("CreateObj"))
        {
            Destroy(obj);
        }
        
    }
}
