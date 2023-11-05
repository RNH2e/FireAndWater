using System;
using System.Collections;
using System.Collections.Generic;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using Firebase.Firestore;
using UnityEngine;
using UnityEngine.UI;



public class DatabaseManager : MonoBehaviour
{
    [SerializeField] Button updateCountButton;
    [SerializeField] Text countUI;
    [SerializeField] Text nameTextUI;
    [SerializeField] InputField inputUI; //
    FirebaseFirestore db;
    ListenerRegistration listenerRegistration;
    // Start is called before the first frame update
    void Start()
    {
        db = FirebaseFirestore.DefaultInstance;
        updateCountButton.onClick.AddListener(OnHandleClick);
        listenerRegistration = db.Collection("counters").Document("counter").Listen(snapshot =>
        {
            FirestoreDTO firestoreDto = snapshot.ConvertTo<FirestoreDTO>();
            countUI.text = firestoreDto.Count.ToString();
            nameTextUI.text = firestoreDto.Input.ToString();
            inputUI.text = firestoreDto.Input.ToString();
        });

       // theInput = inputUI.GetComponent<Text>().text;//

        // GetData();
    }
    void OnDestroy()
    {
        listenerRegistration.Stop();
    }
    void OnHandleClick()
    {

        System.Random randomObject = new System.Random();
        int oldCount = int.Parse(countUI.text);
      


        FirestoreDTO firestoreDto = new FirestoreDTO
        {
            Count = oldCount + 1,
            UpdatedBy = "Aminenur Gökmen",
            Name = $"Aminenur Gökmen {oldCount} _ {randomObject.Next()}",
            Input = inputUI.text
            
            
        };

        DocumentReference docReferance = db.Collection("counters").Document("counter");

        docReferance.SetAsync(firestoreDto).ContinueWithOnMainThread(task =>
        {
            Debug.Log("Updated Counter");
            // GetData();
        });

    }
    void GetData()
    {
        db.Collection("counters").Document("counter").GetSnapshotAsync().ContinueWithOnMainThread(task =>
        {
            FirestoreDTO counter = task.Result.ConvertTo<FirestoreDTO>();
            countUI.text = counter.Count.ToString();
            nameTextUI.text = counter.Name;
        });
    }



}
