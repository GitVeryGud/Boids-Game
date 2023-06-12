using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MeshGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        var m = Triangle();

        string filePath =
        EditorUtility.SaveFilePanelInProject("Save Procedural Mesh", "Procedural Mesh", "asset", "");
        AssetDatabase.CreateAsset(m, filePath);
        AssetDatabase.SaveAssets();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Mesh Triangle()
    {
        // Createds a triangle, because, apparently, there isn`t any triangle sprite in older unity versios
        var mf = GetComponent<MeshFilter>();
        var m = new Mesh();
        mf.mesh = m;

        int vertices = 3;
        Vector3[] VerticesArray = new Vector3[vertices];
        int[] trianglesArray = new int[vertices];

        // Base triangle
        VerticesArray[0] = new Vector3(0, 0.5f, 0);
        VerticesArray[1] = new Vector3(Mathf.Sqrt(3) / 3, -0.5f, 0);
        VerticesArray[2] = new Vector3(-Mathf.Sqrt(3) / 3, -0.5f, 0);

        trianglesArray[0] = 0;
        trianglesArray[1] = 1;
        trianglesArray[2] = 2;

        m.vertices = VerticesArray;
        m.triangles = trianglesArray;

        // create new colors array where the colors will be created.
        Color[] colors = new Color[3];


        colors[0] = Color.white;
        colors[1] = Color.white;
        colors[2] = Color.white;

        m.colors = colors;

        return m;
    }
}
