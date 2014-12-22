﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Soomla.Store.PolicePatrol 
{
	public class InAppPurchases : IStoreAssets 
	{
		public int GetVersion() 
		{
			return 0;
		}
		
		public VirtualCurrency[] GetCurrencies() 
		{
			return new VirtualCurrency[]{MUFFIN_CURRENCY};
		}
		
		public VirtualGood[] GetGoods() 
		{
			return new VirtualGood[] {MUFFINCAKE_GOOD, PAVLOVA_GOOD,CHOCLATECAKE_GOOD, CREAMCUP_GOOD, NO_ADS_LTVG};
		}
		
		public VirtualCurrencyPack[] GetCurrencyPacks() 
		{
			return new VirtualCurrencyPack[] {TENMUFF_PACK, FIFTYMUFF_PACK, FOURHUNDMUFF_PACK, THOUSANDMUFF_PACK};
		}
		
		public VirtualCategory[] GetCategories() 
		{
			return new VirtualCategory[]{GENERAL_CATEGORY};
		}
		
		public const string MUFFIN_CURRENCY_ITEM_ID = "currency_muffin";
		public const string TENMUFF_PACK_PRODUCT_ID = "android.test.refunded";
		public const string FIFTYMUFF_PACK_PRODUCT_ID = "android.test.canceled";
		public const string FOURHUNDMUFF_PACK_PRODUCT_ID = "android.test.purchased";
		public const string THOUSANDMUFF_PACK_PRODUCT_ID = "2500_pack";
		public const string MUFFINCAKE_ITEM_ID = "fruit_cake";
		public const string PAVLOVA_ITEM_ID = "pavlova";
		public const string CHOCLATECAKE_ITEM_ID = "chocolate_cake";
		public const string CREAMCUP_ITEM_ID = "cream_cup";
		public const string NO_ADS_LIFETIME_PRODUCT_ID = "no_ads_01";
		
		public static VirtualCurrency MUFFIN_CURRENCY = new VirtualCurrency
		(
			"Muffins",										// name
			"",												// description
			MUFFIN_CURRENCY_ITEM_ID							// item id
		);
		
		public static VirtualCurrencyPack TENMUFF_PACK = new VirtualCurrencyPack
		(
			"10 Muffins",                                   // name
			"Test refund of an item",                       // description
			"muffins_10",                                   // item id
			10,												// number of currencies in the pack
			MUFFIN_CURRENCY_ITEM_ID,                        // the currency associated with this pack
			new PurchaseWithMarket(TENMUFF_PACK_PRODUCT_ID, 0.99)
		);
		
		public static VirtualCurrencyPack FIFTYMUFF_PACK = new VirtualCurrencyPack
		(
			"50 Muffins",                                   // name
			"Test cancellation of an item",                 // description
			"muffins_50",                                   // item id
			50,                                             // number of currencies in the pack
			MUFFIN_CURRENCY_ITEM_ID,                        // the currency associated with this pack
			new PurchaseWithMarket(FIFTYMUFF_PACK_PRODUCT_ID, 1.99)
		);
		
		public static VirtualCurrencyPack FOURHUNDMUFF_PACK = new VirtualCurrencyPack
		(
			"400 Muffins",                                  // name
			"Test purchase of an item",                 	// description
			"muffins_400",                                  // item id
			400,                                            // number of currencies in the pack
			MUFFIN_CURRENCY_ITEM_ID,                        // the currency associated with this pack
			new PurchaseWithMarket(FOURHUNDMUFF_PACK_PRODUCT_ID, 4.99)
		);
		
		public static VirtualCurrencyPack THOUSANDMUFF_PACK = new VirtualCurrencyPack
		(
			"1000 Muffins",                                 // name
			"Test item unavailable",                 		// description
			"muffins_1000",                                 // item id
			1000,                                           // number of currencies in the pack
			MUFFIN_CURRENCY_ITEM_ID,                        // the currency associated with this pack
			new PurchaseWithMarket(THOUSANDMUFF_PACK_PRODUCT_ID, 8.99)
		);
		
		public static VirtualGood MUFFINCAKE_GOOD = new SingleUseVG
		(
			"Fruit Cake",                                       		// name
			"Customers buy a double portion on each purchase of this cake", // description
			"fruit_cake",                                       		// item id
			new PurchaseWithVirtualItem(MUFFIN_CURRENCY_ITEM_ID, 225)
		); // the way this virtual good is purchased
		
		public static VirtualGood PAVLOVA_GOOD = new SingleUseVG
		(
			"Pavlova",                                         			// name
			"Gives customers a sugar rush and they call their friends", // description
			"pavlova",                                          		// item id
			new PurchaseWithVirtualItem(MUFFIN_CURRENCY_ITEM_ID, 175)
		); // the way this virtual good is purchased
		
		public static VirtualGood CHOCLATECAKE_GOOD = new SingleUseVG
		(
			"Chocolate Cake",                                   		// name
			"A classic cake to maximize customer satisfaction",	 		// description
			"chocolate_cake",                                   		// item id
			new PurchaseWithVirtualItem(MUFFIN_CURRENCY_ITEM_ID, 250)
		); // the way this virtual good is purchased
		
		
		public static VirtualGood CREAMCUP_GOOD = new SingleUseVG
		(
			"Cream Cup",                                        		// name
			"Increase bakery reputation with this original pastry",   	// description
			"cream_cup",                                        		// item id
			new PurchaseWithVirtualItem(MUFFIN_CURRENCY_ITEM_ID, 50)
		);  // the way this virtual good is purchased
		
		public static VirtualCategory GENERAL_CATEGORY = new VirtualCategory
		(
			"General", new List<string>(new string[] { MUFFINCAKE_ITEM_ID, PAVLOVA_ITEM_ID, CHOCLATECAKE_ITEM_ID, CREAMCUP_ITEM_ID })
		);
		
		public static VirtualGood NO_ADS_LTVG = new LifetimeVG
		(
			"No Ads", 														// name
			"No More Ads!",				 									// description
			"no_ads_01",													// item id
			new PurchaseWithMarket(NO_ADS_LIFETIME_PRODUCT_ID, 0.99)
		);
	}
}