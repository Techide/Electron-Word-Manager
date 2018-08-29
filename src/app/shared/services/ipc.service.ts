import { Injectable } from '@angular/core';
import { IpcRenderer } from 'electron';

@Injectable({
  providedIn: 'root'
})
export class IpcService {
  private _ipc: IpcRenderer | undefined;

  /**
   * @description
   * Returns an instance of the ipc renderer.
   *
   * @usageNotes
   * The following snippet shows how to subscribe and send a message to the ipc main thread.
   *
   * @example {subscribe} on(channel: String, (e: Electron.IpcMessageEvent, args: any) => {});
   * @example {send} send(channel: String, [...args: any]);
   */
  get ipc(): IpcRenderer {
    return this._ipc;
  }

  constructor() {
    if (window.require) {
      try {
        this._ipc = window.require('electron').ipcRenderer;
      } catch (error) {
        throw error;
      }
    } else {
      console.warn(
        'IpcRenderer was not loaded, no filepicker dialog will be available.'
      );
    }
  }
}
