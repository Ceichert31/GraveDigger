using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class TreePlacement : MonoBehaviour
{
    //Terrain and Terrain data
    private Terrain map;
    private TerrainData mapData;

    //Prefab to replace trees with
    [SerializeField] private GameObject replacementTree;


    [ContextMenu("Replace Trees")]
    void ReplaceTrees()
    {
        //Set private variables
        map = GetComponent<Terrain>();
        mapData = GetComponent<Terrain>().terrainData;

        //For each tree find a trees position and replace with new tree
        foreach (TreeInstance tree in mapData.treeInstances)
        {
            //Find real world pos by multiplying old tree pos with terrain size
            Vector3 worldPos = Vector3.Scale(tree.position, mapData.size) + map.transform.position;
            //Place new tree
            Instantiate(replacementTree, worldPos, Quaternion.identity);
        }
        //Clear trees from map data
        List<TreeInstance> newTrees = new List<TreeInstance>(0);
        mapData.treeInstances = newTrees.ToArray();
    }
}
