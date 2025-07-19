using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementNodes : MonoBehaviour
{
    //a movement node represents a point in the level that AI can naivgate to

    public Dictionary<GameObject, GameObject> MoveNodeMasterList = new Dictionary<GameObject, GameObject>();

    /*
    GameObject FindFromNodeList(string category,string searchTerm)
    {
        if(category == "roomType")
        {
            for(int i = 0; i < MoveNodeMasterList.Count; i++)
            {
                string nodeInfo = .GetComponent<MoveNodeData>().roomType;
                if ()
                {

                }
            }
        }
        else if(category == "interactionType")
        {

        }
        else if(category == "charactersAssociated")
        {

        }
        else
        {
            return null;
        }
    }
    */

}


