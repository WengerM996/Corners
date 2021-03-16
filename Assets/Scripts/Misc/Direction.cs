using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Direction
{
     public enum Path
     {
         Left, Right, Up, Down, UpLeft, UpRight, DownLeft, DownRight
     }
             
     [SerializeField] private Path path;
     [SerializeField] private float _distance;
     
     public Vector3 Ray
     {
         get
         {
             switch (path)
             {
                 case Path.Left:
                     return Vector3.left;
                 case Path.Right:
                     return Vector3.right;
                 case Path.Up:
                     return Vector3.up;
                 case Path.Down:
                     return Vector3.down;
                 case Path.UpLeft:
                     return new Vector3(-1f, 1f, 0f);
                 case Path.UpRight:
                     return new Vector3(1f, 1f, 0f);
                 case Path.DownLeft:
                     return new Vector3(-1f, -1f, 0f);
                 case Path.DownRight:
                     return new Vector3(1f, -1f, 0f);
                 default:
                     return Vector3.zero;
             }
         }
     }
     
     public Path Way => path;
     public float Distance => _distance;
     public List<RaycastHit> Hits { get; set; }

     public Direction()
     {
         Hits = new List<RaycastHit>();
     }
}
