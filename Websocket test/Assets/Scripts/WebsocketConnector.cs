using System;
using UnityEngine;
using System.Collections;
using WebSocketSharp;

public class WebsocketConnector : MonoBehaviour
{
  private WebSocket ws;

  // Use this for initialization
  void Start()
  {
    Debug.Log("log message");
    this.ws = new WebSocket("ws://echo.websocket.org");

    ws.OnMessage += (sender, e) =>
      Debug.Log("Echo says: " + e.Data);

    ws.OnOpen += (sender, args) => { Debug.Log("Websocket connected!"); };

    ws.OnError += (sender, args) =>
      Debug.Log("Error: " + args.Message.ToString());

    ws.OnClose += (sender, args) =>
      Debug.Log("Websocket closed because: " + args.Reason.ToString());

    ws.Connect();
    ws.Send("Foooooo...");
    Debug.Log("message sent");
  }

  // Update is called once per frame
  void Update()
  {
  }
}