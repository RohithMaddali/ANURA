using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Damien
{

    public class Room : MonoBehaviour
    {
        public Room[] Doorways;
        public MeshCollider MeshCollider;

        public Bounds Roombounds
        {
            get
            {
                return MeshCollider.bounds;
            }
        }
        

            // Start is called before the first frame update
        void Start()
        {
            
        }

    }
}