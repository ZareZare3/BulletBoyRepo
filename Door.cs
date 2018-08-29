using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;
public enum Location { starChamber, wreathRavine, mtAfficionado, stormySea }
public class Door : MonoBehaviour {
    public GameObject lRoom;
    public GameObject rRoom;
    public bool active;
    bool inRRoom;
    bool hasRun;
    public int id;
    public Location location;
    public GameObject player;
    XmlWriter writer;
	// Use this for initialization
	void Start () {
        Stream strm;
        if (new StreamWriter("save.bbsml") == null )
        {
             strm = File.Create("save.bbsml");
        }else{
            strm = File.Open("save.bbsml", FileMode.Open);


        }
         writer = XmlWriter.Create(strm);
	}
	
	// Update is called once per frame
	void Update () {
        if(active){
            if (!hasRun)
            {
                Instantiate(rRoom);
                hasRun = true;




            }
        }else{
            hasRun = false;
            Destroy(rRoom);


        }
        if(inRRoom){
            for (int i = 0; i < lRoom.transform.childCount;i++){
                if(lRoom.transform.GetChild(i).GetComponent<Door> () != null){

                    lRoom.transform.GetChild(i).GetComponent<Door>().active = false;




                }



            } 



        }
	}
    private void OnCollisionEnter(Collision collision)
    {
        bool hasRunRoomUpdate = false;
        if (collision.gameObject == player)
        {
            if (!hasRunRoomUpdate)
            {
                inRRoom = !inRRoom;
                writer.Flush();
                writer.WriteStartElement("id");
                writer.WriteElementString("id", id.ToString());
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Close();
                hasRunRoomUpdate = true;
            }
        }else{


            hasRunRoomUpdate = false;

        }
    }
}
