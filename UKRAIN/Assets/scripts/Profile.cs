using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Profile : MonoBehaviour
{
	#region Singlton:Profile

	public static Profile Instance;
	

	void Awake()
	{
		if (Instance == null)
			Instance = this;
		else
			Destroy(gameObject);
	}

	#endregion

	public class Avatar
	{
		public Sprite Image;
	}

	public List<Avatar> AvatarsList;

	[SerializeField] GameObject AvatarUITemplate;
	[SerializeField] Transform AvatarsScrollView;

	GameObject g;
	
	[SerializeField] Image CurrentAvatar;

	void Start()
	{
		GetAvailableAvatars();
		
		
	}

	void GetAvailableAvatars()
	{
		for (int i = 0; i < Shop.instance.ShopItemsList.Count; i++)
		{
			if (Shop.instance.ShopItemsList[i].IsPurchased)
			{
				//add all purchased avatars to AvatarsList
				AddAvatar(Shop.instance.ShopItemsList[i].image);
			}
		}

		
	}

	public void AddAvatar(Sprite img)
	{
		if (AvatarsList == null)
			AvatarsList = new List<Avatar>();

		Avatar av = new Avatar() { Image = img };
		//add av to AvatarsList
		AvatarsList.Add(av);

		//add avatar in the UI scroll view
		g = Instantiate(AvatarUITemplate, AvatarsScrollView);
		g.transform.GetChild(0).GetComponent<Image>().sprite = av.Image;

		
	}

	
}
