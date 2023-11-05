using Firebase.Firestore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[FirestoreData]
public class FirestoreDTO
{
    
    [FirestoreProperty]
    public int Count { get; set; }
    
    [FirestoreProperty]
    public string UpdatedBy { get; set; }

    [FirestoreProperty]
    public string Name { get; set; }

    [FirestoreProperty]//
    public string Input { get; set; }//

}
