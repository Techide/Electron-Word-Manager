import { Component, OnInit } from '@angular/core';
// import { Dialog, BrowserWindow, IpcRenderer } from 'electron';
import { IpcRenderer } from 'electron';

@Component({
  selector: 'ewm-navigation-menu',
  templateUrl: './navigation-menu.component.html',
  styleUrls: ['./navigation-menu.component.scss']
})
export class NavigationMenuComponent implements OnInit {
  // private _dialog: Dialog | undefined;

  // private _browserWindow: BrowserWindow | undefined;

  private _ipc: IpcRenderer | undefined;

  constructor() {
    if (window.require) {
      try {
        // this._dialog = window.require('electron').remote.dialog;
        // this._browserWindow = window
        //   .require('electron')
        //   .remote.BrowserWindow.getFocusedWindow();
        this._ipc = window.require('electron').ipcRenderer;
      } catch (error) {
        throw error;
      }
    } else {
      console.warn(
        'Electron/dialog & Electron/browserwindow was not loaded, no filepicker dialog will be available.'
      );
    }
  }

  ngOnInit() {
    this._ipc.on('filePath', (e: Electron.IpcMessageEvent, args: any) => {
      console.log(args);
    });
  }

  onClick() {
    // this._dialog.showOpenDialog(
    //   this._browserWindow,
    //   {
    //     properties: ['openFile']
    //   },
    //   files => {
    //     console.log(files);

    //     this._ipc.on('fileResponse', (e: Electron.IpcMessageEvent, args: any) => {
    //       console.log(args);
    //     });

    //     this._ipc.send('fileName', files[0]);
    //   }
    // );

    this._ipc.send('getFilePath');
  }
}
