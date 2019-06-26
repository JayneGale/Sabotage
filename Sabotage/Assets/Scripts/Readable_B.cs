//using Assets.scripts.reading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.items
{
    // [CreateAssetMenu(fileName = "New Readable", menuName = "Inventory/Readable")]
    // public class Readable : Item
    public class Readable_B : MonoBehaviour

    {
        public Sprite sprite;
        internal int timeActive = 0;

 //       [SerializeField] private Mouseable m_Mouseable;

        private void Start()
        {
 //           m_Mouseable.Init(gameObject, CursorImage.Readable);
        }

        private void Update()
        {

            if (timeActive < 100) timeActive++;
        }

        private void OnMouseEnter()
        {

 //           m_Mouseable.OnMouseEnter();
        }

        private void OnMouseExit()
        {

//            m_Mouseable.OnMouseExit();
            // OnMouseUp();
        }

        private void OnMouseDown()
        {
            if (EventSystem.current.IsPointerOverGameObject()) return;
            // Read the item
            print("Readable.OnMouseDown");
            timeActive = 0;
 //           ReadingManager.instance.StartReading(gameObject);
        }
    }

    
}

/*public class Readable_B : MonoBehaviour {

//void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
*/