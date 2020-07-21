"use strict";

import * as signalr from '@microsoft/signalr';

const connection = new signalr
  .HubConnectionBuilder()
  .withUrl("/updates")
  .configureLogging(signalr.LogLevel.Information)
  .withAutomaticReconnect()
  .build();

export const begin = async () => {
  try {
    await connection.start();
  } catch (err) {
    console.error(err);
  }
};

export const ping = planeId => {
  connection.invoke("Ping", planeId)
    .catch(console.error);
}

connection.on("pong", planeId => console.log("pong: " + planeId));

connection.on("ReceiveMessage", (user, message) => console.log(`user: ${user} message: ${message}`));