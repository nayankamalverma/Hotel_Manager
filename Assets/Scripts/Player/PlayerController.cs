using System.Collections.Generic;
using Assets.Scripts.Items;
using UnityEngine;
using System.Linq;

namespace Assets.Scripts.Player
{
	public class PlayerController : MonoBehaviour
	{
		[SerializeField]
		private Animator animator;
		[SerializeField]
		private float playerSpeed;
		[SerializeField]
		private float rotateSpeed;
		[SerializeField]
		Transform itemPlace;

		private Camera cam;
		private Vector3 dir;
		[SerializeField] private List<Transform> items = new List<Transform>();
		private ItemType currentItem;
		float itemHight;
        private ItemService itemService;

		public void SetService(ItemService itemService)
		{
			this.itemService = itemService;
		}
		private void Start()
		{
			cam = Camera.main;
			currentItem = ItemType.None;
			items.Add(itemPlace);
		}

		private void Update()
		{
			Movement();
			Anim();
			ManageItems();
            if (items.Count > 1) PositionItems();
        }
        private void PositionItems()
        {
			itemHight = itemService.getItemHight(currentItem);
            items[1].position = itemPlace.position;
            for (int i = 2; i < items.Count; i++) {
				Transform item1 = items[i-1];
				Transform item2 = items[i];
				item2.position = new Vector3(itemPlace.position.x, item1.position.y+itemHight,itemPlace.position.z );
			}
        }
        private void ManageItems()
		{
			if(Physics.Raycast(transform.position,transform.forward,out var hit, 1f))
            {	Transform a = hit.collider.transform;
				
				//get bottels
                if (hit.collider.CompareTag("BottelStorage") && items.Count < 4)
				{
					currentItem = ItemType.Bottel1;

					GameObject bottel = itemService.GetItem(currentItem);
					bottel.transform.position = a.position;
                    items.Add(bottel.transform);

                    animator.SetBool("carry", true);
                    animator.SetBool("run", false);
                }
				//place bottels
				if (hit.collider.CompareTag("BottelShelf") && items.Count>1 && currentItem==ItemType.Bottel1) {
					Shelf s = hit.collider.GetComponent<Shelf>();
					if (s != null && s.HasEmptySpot()) {
						var i = items[items.Count - 1];
						items.Remove(i);
						s.SetItem(i);
					}
				}
				if (hit.collider.CompareTag("Storage") && items.Count>1)
				{
					for (int i = 1; i < items.Count; i++) {
						var item = items[i];
                        itemService.ReturnItem(currentItem,item.gameObject);
						items.Remove(item);
					}
				}
            }
		}
		private void Anim()
		{
            if (Input.GetMouseButtonDown(0))
            {
                if (items.Count > 1)
                {
                    animator.SetBool("carry", false);
                    animator.SetBool("RunWithPapers", true);
                }
                else
                {
                    animator.SetBool("run", true);
                }
            }
            if (Input.GetMouseButtonUp(0))
            {
                animator.SetBool("run", false);

                if (items.Count > 1)
                {
                    animator.SetBool("carry", true);
                    animator.SetBool("RunWithPapers", false);
				}
                if (items.Count <= 1)
                {
                    animator.SetBool("idle", true);
                    animator.SetBool("RunWithPapers", false);
                }
            }

        }

		private void Movement()
		{
			if (Input.GetMouseButton(0))
			{
				Plane plane = new Plane(Vector3.up, transform.position);
				Ray ray = cam.ScreenPointToRay(Input.mousePosition);

				if (plane.Raycast(ray, out var distance))
					dir = ray.GetPoint(distance);

				transform.position = Vector3.MoveTowards(transform.position, new Vector3(dir.x, 0f, dir.z), playerSpeed * Time.deltaTime);

				var offset = dir - transform.position;

				if (offset.magnitude > 1f)
					transform.LookAt(dir);
			}
		}
	}
}