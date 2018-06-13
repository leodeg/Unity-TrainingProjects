using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    public Camera myCamera;

    private GameObject parent;
    private StarDisplay starDisplay;

    // Use this for initialization
    void Start ()
    {
        parent = GameObject.Find("Defenders");
        if (!parent)
        {
            parent = new GameObject("Defenders");
        }
        starDisplay = GameObject.FindObjectOfType<StarDisplay>();        
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    //private void OnMouseDown()
    //{
    //    Vector2 rawPosition = CalculateWordlPointOfMouseClick();
    //    GameObject newDefender = Instantiate(Button.selectedDefender, 
    //        SnapToGrid(rawPosition), Quaternion.identity) as GameObject;

    //    int defenderCost = parent.GetComponent<Defenders>().starCost;

    //    if (starDisplay.UseStars(defenderCost) == StarDisplay.Status.SUCCESS)
    //    {
    //        newDefender.transform.parent = parent.transform;
    //    }   
    //    else
    //    {
    //        Debug.Log("You don't have much money for spawn");
    //    }
    //}

    void OnMouseDown()
    {
        Vector2 rawPos = CalculateWordlPointOfMouseClick();
        Vector2 roundedPos = SnapToGrid(rawPos);
        GameObject defender = Button.selectedDefender;

        int defenderCost = defender.GetComponent<Defenders>().starCost;
        if (starDisplay.UseStars(defenderCost) == StarDisplay.Status.SUCCESS)
        {
            SpawnDefender(roundedPos, defender);
        }
        else
        {
            Debug.Log("Insufficient stars to spawn");
        }
    }

    void SpawnDefender(Vector2 roundedPos, GameObject defender)
    {
        Quaternion zeroRot = Quaternion.identity;
        GameObject newDef = Instantiate(defender, roundedPos, zeroRot) as GameObject;
        newDef.transform.parent = parent.transform;
    }

    Vector2 SnapToGrid(Vector2 rawWorldPosition)
    {
        float newX = Mathf.RoundToInt(rawWorldPosition.x);
        float newY = Mathf.RoundToInt(rawWorldPosition.y);
        return new Vector2(newX, newY);
    }

    Vector2 CalculateWordlPointOfMouseClick()
    {
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;
        float distanceFromCamera = 10f;

        Vector3 weirdTriplet = new Vector3(mouseX, mouseY, distanceFromCamera);
        Vector2 worldPosition = myCamera.ScreenToWorldPoint(weirdTriplet);

        return worldPosition;
    }
}
