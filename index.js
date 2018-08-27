const { app, BrowserWindow, ipcMain, dialog } = require('electron');

let win;

function createWindow() {
  app.setName('mooh');

  // Create the browser window.
  win = new BrowserWindow({
    width: 600,
    height: 600,
    backgroundColor: '#ffffff',
    icon: `file://${__dirname}/dist/assets/logo.png`
  });

  // win.loadURL(`file://${__dirname}/dist/index.html`)
  win.loadURL(`http://localhost:4200`);

  //// uncomment below to open the DevTools.
  // win.webContents.openDevTools()

  ipcMain.on('getFilePath', (e, args) => {
    dialog.showOpenDialog(win, { properties: ['openFile'] }, files => {
      if (files && files.length > 0) {
        e.sender.send('filePath', files[0]);
      }
    });
  });

  // Event when the window is closed.
  win.on('closed', function() {
    win = null;
  });
}

// Create window on electron intialization
app.on('ready', createWindow);

// Quit when all windows are closed.
app.on('window-all-closed', function() {
  // On macOS specific close process
  if (process.platform !== 'darwin') {
    app.quit();
  }
});

app.on('activate', function() {
  // macOS specific close process
  if (win === null) {
    createWindow();
  }
});
