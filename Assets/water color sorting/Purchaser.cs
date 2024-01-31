/*
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Purchasing;

    

// Placing the Purchaser class in the CompleteProject namespace allows it to interact with ScoreManager, 
// one of the existing Survival Shooter scripts.
	// Deriving the Purchaser class from IStoreListener enables it to receive messages from Unity Purchasing.
	public class Purchaser : MonoBehaviour, IStoreListener
	{

     


    

		private static IStoreController m_StoreController;          // The Unity Purchasing system.
		private static IExtensionProvider m_StoreExtensionProvider; // The store-specific Purchasing subsystems.

		// Product identifiers for all products capable of being purchased: 
		// "convenience" general identifiers for use with Purchasing, and their store-specific identifier 
		// counterparts for use with and outside of Unity Purchasing. Define store-specific identifiers 
		// also on each platform's publisher dashboard (iTunes Connect, Google Play Developer Console, etc.)

		// General product identifiers for the consumable, non-consumable, and subscription products.
		// Use these handles in the code to reference which product to purchase. Also use these values 
		// when defining the Product Identifiers on the store. Except, for illustration purposes, the 
		// kProductIDSubscription - it has custom Apple and Google identifiers. We declare their store-
		// specific mapping to Unity Purchasing's AddProduct, below.
		public static string kProductIDConsumable =    "consumable";   
		public static string kProductIDNonConsumable = "nonconsumable";
		public static string kProductIDSubscription =  "subscription"; 

	[Header("Remove Ads Inapp Ids")]
	public  string removeadsID =    "removeads";
    public String RemoveAdprice;
    public Text RemoveAdTxt;

    [Space(100)]
    public Text[] AllBackgroundTexts;
    [Header("Unlock All Background Inapp Id")]
    public  string allbackgroundsID = "allbackgrounds";
    public String AllBackgroundsprice;



    [Space(100)]
    public Text[] HintTexts;
  
    
    [Header("Hints id 1")]
    public  string hintpack1ID = "hint2";
    public string hintpack1price = "hint2";
    public int assignhintpack1Values;

    [Header("Hints id 2")]
    public  string hintpack2ID = "hint5";
    public string hintpack2price = "hint5";
    public int assignhintpack2Values;


    [Header("Hints id 3")]
    public  string hintpack3ID = "hint10";
    public string hintpack3price = "hint10";
    public int assignhintpack3Values;




    [Space(100)]
    public Text[] TubesTexts;

   

    [Header("Add Tubes First Inapp")]
    public  string addtubepack1ID = "addtube1";
    public string addtubepack1price = "hint10";
    public int assigntubepack1Values;



    [Header("Add Tubes Second Inapp")]
    public  string addtubepack2ID = "addtube2";
    public string addtubepack2price = "hint10";
    public int assigntubepack2Values;


    [Header("Add Tubes Third Inapp")]
    public  string addtubepack3ID = "addtube3";
    public string addtubepack3price = "hint10";
    public int assigntubepack3Values;

    [Space(100)]
    public Text[] CoinsTexts;
    [Header("Coins Inapps Ids")]

    [Header("Coins PAck1")]
    public  string coinpack1ID = "coin1";
    public string coinpack1price = "hint10";
    public int assigncoinpack1Values;


    [Header("Coins PAck2")]
    public  string coinpack2ID = "coin2";
    public string coinpack2price = "hint10";
    public int assigncoinpack2Values;



    [Header("Coins PAck3")]
    public  string coinpack3ID = "coin3";
    public string coinpack3price = "hint10";
    public int assigncoinpack3Values;



    [Space(100)]
    public Text[] SpecialOfferText;
    [Header("Special Offer Inapp Id")]
    public  string specialofferID = "specialoffer";
    public int asignspecialoffercoinvalue;
    public int asignspecialofferhintvalue;
    public String specialofferprice;
    [Header("Assign Coins Value")]

    








    // Apple App Store-specific product identifier for the subscription product.
    private static string kProductNameAppleSubscription =  "com.unity3d.subscription.new";

		// Google Play Store-specific product identifier subscription product.
		private static string kProductNameGooglePlaySubscription =  "com.unity3d.subscription.original"; 

		void Start()
		{
			// If we haven't set up the Unity Purchasing reference
			if (m_StoreController == null)
			{
				// Begin to configure our connection to Purchasing
				InitializePurchasing();
			}

        AssignallInapps();
        }

    void AssignallInapps()
    {
        AssignSpecialOfferText();
        assignremoveAdText();
        assigncoinspackText();
        assigntubespackText();
    }


    //assigning Hints Texts
    void assigntubespackText()
    {
        TubesTexts[0].text = addtubepack1price;
        TubesTexts[1].text = "ADD " + assigntubepack1Values.ToString() + " Tube";
        TubesTexts[2].text = addtubepack2price;
        TubesTexts[3].text = "ADD " + assigntubepack2Values.ToString() + " Tube";
        TubesTexts[4].text = addtubepack3price;
        TubesTexts[5].text = "ADD " + assigntubepack3Values.ToString() + " Tube";
    }



    //assigning Hints Texts
    void assignhintspackText()
    {
        HintTexts[0].text = hintpack1price;
        HintTexts[1].text = "Buy " + assignhintpack1Values.ToString() + "Hints";
        HintTexts[2].text = hintpack2price;
        HintTexts[3].text = "Buy " + assignhintpack2Values.ToString() + "Hints";
        HintTexts[4].text = hintpack3price;
        HintTexts[5].text = "Buy " + assignhintpack3Values.ToString() + "Hints";
    }

    //assigning Coin Texts
    void assigncoinspackText()
    {
        CoinsTexts[0].text = coinpack1price;
        CoinsTexts[1].text = assigncoinpack1Values.ToString()+" Coins";
        CoinsTexts[2].text = coinpack2price;
        CoinsTexts[3].text = assigncoinpack2Values.ToString() + " Coins";
        CoinsTexts[4].text = coinpack3price;
        CoinsTexts[5].text = assigncoinpack3Values.ToString() + " Coins";
    }



    //assigning Remove Ad  Texts
    void assignremoveAdText()
    {
        RemoveAdTxt.text = RemoveAdprice.ToString();
    }

        //assigning Special Offer Texts
        void AssignSpecialOfferText()
    {
        SpecialOfferText[0].GetComponent<Text>().text = specialofferprice;
        SpecialOfferText[1].GetComponent<Text>().text = "-/ ALL BACKGROUNDS \n" +  "-/"+ asignspecialofferhintvalue.ToString()+" HINTS \n"+"-/ ALL TUBES \n"+"-/"+ asignspecialoffercoinvalue+" COINS ";
    }









		public void InitializePurchasing() 
		{
			// If we have already connected to Purchasing ...
			if (IsInitialized())
			{
				// ... we are done here.
				return;
			}

			// Create a builder, first passing in a suite of Unity provided stores.
			var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

			// Add a product to sell / restore by way of its identifier, associating the general identifier
			// with its store-specific identifiers.
		builder.AddProduct(hintpack1ID, ProductType.Consumable);
		builder.AddProduct(hintpack2ID, ProductType.Consumable);
		builder.AddProduct(hintpack3ID, ProductType.Consumable);
		builder.AddProduct(addtubepack1ID, ProductType.Consumable);
		builder.AddProduct(addtubepack2ID, ProductType.Consumable);
        builder.AddProduct(addtubepack3ID, ProductType.Consumable);
        builder.AddProduct(coinpack1ID, ProductType.Consumable);
        builder.AddProduct(coinpack2ID, ProductType.Consumable);
        builder.AddProduct(coinpack3ID, ProductType.Consumable);
        builder.AddProduct(allbackgroundsID, ProductType.Consumable);
        builder.AddProduct(specialofferID, ProductType.Consumable);

        // Continue adding the non-consumable product.
        builder.AddProduct(removeadsID, ProductType.NonConsumable);
			// And finish adding the subscription product. Notice this uses store-specific IDs, illustrating
			// if the Product ID was configured differently between Apple and Google stores. Also note that
			// one uses the general kProductIDSubscription handle inside the game - the store-specific IDs 
			// must only be referenced here. 
//			builder.AddProduct(kProductIDSubscription, ProductType.Subscription, new IDs(){
//				{ kProductNameAppleSubscription, AppleAppStore.Name },
//				{ kProductNameGooglePlaySubscription, GooglePlay.Name },
//			});

			// Kick off the remainder of the set-up with an asynchrounous call, passing the configuration 
			// and this class' instance. Expect a response either in OnInitialized or OnInitializeFailed.
			UnityPurchasing.Initialize(this, builder);
		}


		private bool IsInitialized()
		{
			// Only say we are initialized if both the Purchasing references are set.
			return m_StoreController != null && m_StoreExtensionProvider != null;
		}


//		public void BuyConsumable()
//		{
//			// Buy the consumable product using its general identifier. Expect a response either 
//			// through ProcessPurchase or OnPurchaseFailed asynchronously.
//			BuyProductID(kProductIDConsumable);
//		}

	public void Removeads()
	{
		// Buy the consumable product using its general identifier. Expect a response either 
		// through ProcessPurchase or OnPurchaseFailed asynchronously.
		BuyProductID(removeadsID);
	}
	public void buycoinspackage(int n)
	{
		// Buy the consumable product using its general identifier. Expect a response either 
		// through ProcessPurchase or OnPurchaseFailed asynchronously.
		if (n == 1) {
			BuyProductID (coinpack1ID);

		}else if (n == 2) {
			BuyProductID (coinpack2ID);
		}else if (n == 3) {
			BuyProductID (coinpack3ID);
		}
       

    }
    public void buyhintpackage(int n)
    {
        // Buy the consumable product using its general identifier. Expect a response either 
        // through ProcessPurchase or OnPurchaseFailed asynchronously.
        if (n == 1)
        {
            BuyProductID(hintpack1ID);
        }
        else if (n == 2)
        {
            BuyProductID(hintpack2ID);
        }
        else if (n == 3)
        {
            BuyProductID(hintpack3ID);
        }

    }
    public void buytubepackage(int n)
    {
        // Buy the consumable product using its general identifier. Expect a response either 
        // through ProcessPurchase or OnPurchaseFailed asynchronously.
        if (n == 1)
        {
            BuyProductID(addtubepack1ID);
        }
        else if (n == 2)
        {
            BuyProductID(addtubepack2ID);
        }
        else if (n == 3)
        {
            BuyProductID(addtubepack3ID);
        }
    }


    public void buybgpackage()
    {
        // Buy the consumable product using its general identifier. Expect a response either 
        // through ProcessPurchase or OnPurchaseFailed asynchronously.
       
            BuyProductID(allbackgroundsID);
       
    }

    public void buyspecialofferpackage()
    {
        // Buy the consumable product using its general identifier. Expect a response either 
        // through ProcessPurchase or OnPurchaseFailed asynchronously.

        BuyProductID(specialofferID);
    }




    //		public void BuyNonConsumable()
    //		{
    //			// Buy the non-consumable product using its general identifier. Expect a response either 
    //			// through ProcessPurchase or OnPurchaseFailed asynchronously.
    //			BuyProductID(kProductIDNonConsumable);
    //		}


    public void BuySubscription()
		{
			// Buy the subscription product using its the general identifier. Expect a response either 
			// through ProcessPurchase or OnPurchaseFailed asynchronously.
			// Notice how we use the general product identifier in spite of this ID being mapped to
			// custom store-specific identifiers above.
			BuyProductID(kProductIDSubscription);
		}


		void BuyProductID(string productId)
		{
			// If Purchasing has been initialized ...
			if (IsInitialized())
			{
				// ... look up the Product reference with the general product identifier and the Purchasing 
				// system's products collection.
				Product product = m_StoreController.products.WithID(productId);

				// If the look up found a product for this device's store and that product is ready to be sold ... 
				if (product != null && product.availableToPurchase)
				{
					Debug.Log(string.Format("Purchasing product asychronously: '{0}'", product.definition.id));
					// ... buy the product. Expect a response either through ProcessPurchase or OnPurchaseFailed 
					// asynchronously.
					m_StoreController.InitiatePurchase(product);
				}
				// Otherwise ...
				else
				{
					// ... report the product look-up failure situation  
					Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
				}
			}
			// Otherwise ...
			else
			{
				// ... report the fact Purchasing has not succeeded initializing yet. Consider waiting longer or 
				// retrying initiailization.
				Debug.Log("BuyProductID FAIL. Not initialized.");
			}
		}


		// Restore purchases previously made by this customer. Some platforms automatically restore purchases, like Google. 
		// Apple currently requires explicit purchase restoration for IAP, conditionally displaying a password prompt.
		public void RestorePurchases()
		{
			// If Purchasing has not yet been set up ...
			if (!IsInitialized())
			{
				// ... report the situation and stop restoring. Consider either waiting longer, or retrying initialization.
				Debug.Log("RestorePurchases FAIL. Not initialized.");
				return;
			}

			// If we are running on an Apple device ... 
			if (Application.platform == RuntimePlatform.IPhonePlayer || 
				Application.platform == RuntimePlatform.OSXPlayer)
			{
				// ... begin restoring purchases
				Debug.Log("RestorePurchases started ...");

				// Fetch the Apple store-specific subsystem.
				var apple = m_StoreExtensionProvider.GetExtension<IAppleExtensions>();
				// Begin the asynchronous process of restoring purchases. Expect a confirmation response in 
				// the Action<bool> below, and ProcessPurchase if there are previously purchased products to restore.
				apple.RestoreTransactions((result) => {
					// The first phase of restoration. If no more responses are received on ProcessPurchase then 
					// no purchases are available to be restored.
					Debug.Log("RestorePurchases continuing: " + result + ". If no further messages, no purchases available to restore.");
				});
			}
			// Otherwise ...
			else
			{
				// We are not running on an Apple device. No work is necessary to restore purchases.
				Debug.Log("RestorePurchases FAIL. Not supported on this platform. Current = " + Application.platform);
			}
		}


		//  
		// --- IStoreListener
		//

		public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
		{
			// Purchasing has succeeded initializing. Collect our Purchasing references.
			Debug.Log("OnInitialized: PASS");

			// Overall Purchasing system, configured with products for this application.
			m_StoreController = controller;
			// Store specific subsystem, for accessing device-specific store features.
			m_StoreExtensionProvider = extensions;
		}


		public void OnInitializeFailed(InitializationFailureReason error)
		{
			// Purchasing set-up has not succeeded. Check error for reason. Consider sharing this reason with the user.
			Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
		}
		public void OnInitializeFailed(InitializationFailureReason error, string message)
		{
			// Purchasing set-up has not succeeded. Check error for reason. Consider sharing this reason with the user.
			Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
		}

		public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args) 
		{
			// A consumable product has been purchased by this user.
		if (String.Equals(args.purchasedProduct.definition.id, coinpack1ID, StringComparison.Ordinal))
			{
				Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
            int temp = prefmanager.instance.Getcoinsvalue();
            temp = temp + assigncoinpack1Values;
            prefmanager.instance.SetcoinsValue(temp);

         //   UnityEngine.SceneManagement.SceneManager.LoadScene(0);


        }

		else if (String.Equals(args.purchasedProduct.definition.id, coinpack2ID, StringComparison.Ordinal)){
			Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
            int temp = prefmanager.instance.Getcoinsvalue();
            temp = temp + assigncoinpack2Values;
            prefmanager.instance.SetcoinsValue(temp);

           // UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }

		else if (String.Equals(args.purchasedProduct.definition.id, coinpack3ID, StringComparison.Ordinal)){
			Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
            int temp = prefmanager.instance.Getcoinsvalue();
            temp = temp + assigncoinpack3Values;
            prefmanager.instance.SetcoinsValue(temp);

          //  UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }


		else if (String.Equals(args.purchasedProduct.definition.id, hintpack1ID, StringComparison.Ordinal)){
			Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
            int temp = prefmanager.instance.Gethintvalue();
            temp = temp + assignhintpack1Values;
            prefmanager.instance.SetHintValue(temp);

        //    UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }


		else if (String.Equals(args.purchasedProduct.definition.id, hintpack2ID, StringComparison.Ordinal)){
			Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
            int temp = prefmanager.instance.Gethintvalue();
            temp = temp + assignhintpack2Values;
            prefmanager.instance.SetHintValue(temp);

          //  UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            // The consumable item has been successfully purchased, add 100 coins to the player's in-game score.

        }
        else if (String.Equals(args.purchasedProduct.definition.id, hintpack3ID, StringComparison.Ordinal))
        {
            Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
            int temp = prefmanager.instance.Gethintvalue();
            temp = temp + assignhintpack3Values;
            prefmanager.instance.SetHintValue(temp);

         //   UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            // The consumable item has been successfully purchased, add 100 coins to the player's in-game score.
            //ScoreManager.score += 100;

        }
        else if (String.Equals(args.purchasedProduct.definition.id, addtubepack1ID, StringComparison.Ordinal))
        {
            Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
            int temp = prefmanager.instance.Gettubevalue();
            temp = temp + assigntubepack1Values;
            prefmanager.instance.SettubeValue(temp);

         //   UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            // The consumable item has been successfully purchased, add 100 coins to the player's in-game score.
            //ScoreManager.score += 100;

        }
        else if (String.Equals(args.purchasedProduct.definition.id, addtubepack2ID, StringComparison.Ordinal))
        {
            Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
            int temp = prefmanager.instance.Gettubevalue();
            temp = temp + assigntubepack2Values;
            prefmanager.instance.SettubeValue(temp);

          //  UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            // The consumable item has been successfully purchased, add 100 coins to the player's in-game score.
            //ScoreManager.score += 100;

        }
        else if (String.Equals(args.purchasedProduct.definition.id, addtubepack3ID, StringComparison.Ordinal))
        {
            Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
            int temp = prefmanager.instance.Gettubevalue();
            temp = temp + assigntubepack3Values;
            prefmanager.instance.SettubeValue(temp);

         //   UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            // The consumable item has been successfully purchased, add 100 coins to the player's in-game score.
            //ScoreManager.score += 100;

        }
        else if (String.Equals(args.purchasedProduct.definition.id, allbackgroundsID, StringComparison.Ordinal))
        {
            Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));

            PlayerPrefs.SetString("bglockfile", "11111111");
          //  UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            // The consumable item has been successfully purchased, add 100 coins to the player's in-game score.
            //ScoreManager.score += 100;

        }
        else if (String.Equals(args.purchasedProduct.definition.id, specialofferID, StringComparison.Ordinal))
        {
            Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));

            PlayerPrefs.SetString("bglockfile", "11111111");
            PlayerPrefs.SetString("bottlelockfile", "11111111111");


            /*
                        //Set Tube Value
                        int temp = prefmanager.instance.Gettubevalue();
                        temp = temp + 10;
                        prefmanager.instance.SettubeValue(temp);
            #1#
            //Set Hint Value
            int hint = prefmanager.instance.Gethintvalue();
            hint = hint + asignspecialofferhintvalue;
            prefmanager.instance.SetHintValue(hint);


            //Set Coins Value
            int coinvalue = prefmanager.instance.Getcoinsvalue();
            coinvalue = coinvalue + asignspecialoffercoinvalue;
            prefmanager.instance.SetcoinsValue(coinvalue);

            UnityEngine.SceneManagement.SceneManager.LoadScene(0);

            // The consumable item has been successfully purchased, add 100 coins to the player's in-game score.
            //ScoreManager.score += 100;
        }

        // Or ... a non-consumable product has been purchased by this user.




        else if (String.Equals(args.purchasedProduct.definition.id, removeadsID, StringComparison.Ordinal))
			{
				Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
            // TODO: The non-consumable item has been successfully purchased, grant this item to the player.
            //Utils.SaveRemoveAds();
            PlayerPrefs.SetInt("removeads", 1);


        }
			// Or ... a subscription product has been purchased by this user.
			else if (String.Equals(args.purchasedProduct.definition.id, kProductIDSubscription, StringComparison.Ordinal))
			{
				Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
				// TODO: The subscription item has been successfully purchased, grant this to the player.
			}
			// Or ... an unknown product has been purchased by this user. Fill in additional products here....
			else 
			{
				Debug.Log(string.Format("ProcessPurchase: FAIL. Unrecognized product: '{0}'", args.purchasedProduct.definition.id));
			}

			// Return a flag indicating whether this product has completely been received, or if the application needs 
			// to be reminded of this purchase at next app launch. Use PurchaseProcessingResult.Pending when still 
			// saving purchased products to the cloud, and when that save is delayed. 
			return PurchaseProcessingResult.Complete;
		}


		public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
		{
			// A product purchase attempt did not succeed. Check failureReason for more detail. Consider sharing 
			// this reason with the user to guide their troubleshooting actions.
			Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason));
		}
	}
	*/
