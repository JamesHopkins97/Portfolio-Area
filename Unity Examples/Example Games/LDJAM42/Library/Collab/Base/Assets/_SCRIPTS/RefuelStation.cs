﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RefuelStation : MonoBehaviour {

    public Button RefuelAddOne;
    public Button RefuelAddAll;
    public Button AddFoodAddOne;
    public Button AddFoodAddAll;
    public Button AddMedicineAddOne;
    public Button AddMedicineAddAll;
    public Button OffloadRefugees;
    public Button ReturnHome;

    public GameObject boat;

    public AudioManager Ding;
    private ResourceList resources;
    // Use this for initialization
    void Start ()
    {
        if (Ding == null)
            Ding = GameObject.Find("GameManager").GetComponent<AudioManager>();

        resources = boat.GetComponent<ResourceList>();
        RefuelAddOne.onClick.AddListener(RefuelShipOne);
        RefuelAddAll.onClick.AddListener(RefuelShipAll);

        AddFoodAddOne.onClick.AddListener(ResupplyFoodOne);
        AddFoodAddAll.onClick.AddListener(ResupplyFoodAll);

        AddMedicineAddOne.onClick.AddListener(ResupplyMedicinalsOne);
        AddMedicineAddAll.onClick.AddListener(ResupplyMedicinalsAll);

        OffloadRefugees.onClick.AddListener(DropOffRefugees);

        ReturnHome.onClick.AddListener(EndGame);
    }

    /// <summary>
    /// Fuel Shop
    /// </summary>
    void RefuelShipOne() {  resources.PayForFuel(1); Ding.PlayHoverDing();   }
    void RefuelShipAll() {   resources.PayForFuel((int)resources.AmountOfFuelAvailabletoBuy); Ding.PlayHoverDing(); }

    /// <summary>
    /// Food Shop
    /// </summary>
    void ResupplyFoodOne() {   resources.PayForFood(1); Ding.PlayHoverDing(); }
    void ResupplyFoodAll() {   resources.PayForFood(resources.AmountOfFoodAvailableToBuy); Ding.PlayHoverDing(); }

    /// <summary>
    /// Medicine Shop
    /// </summary>
    void ResupplyMedicinalsOne() {   resources.PayForMedicine(1); Ding.PlayHoverDing(); }
    void ResupplyMedicinalsAll() {   resources.PayForMedicine(resources.AmountOfMedicineAvailabletoBuy); Ding.PlayHoverDing(); }

    /// <summary>
    /// Drop off Refugees
    /// </summary>
    void DropOffRefugees() {  resources.setTotalRefugees(); Ding.PlayHoverDing(); }

    void EndGame() { Debug.Log("End the game"); }
}
