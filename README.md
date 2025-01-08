Running the application:
- Clone the Git repository and open in Visual Studio (or open into VS directly).
- Build and run the app to show the Dropbox app window.

![image](https://github.com/user-attachments/assets/0d748f4e-da01-486b-bc59-feddad259c87)

- Select the Input and Target folders (note that synchronisation cannot be started unless both folders are defined).
- Click the ‘Start Synchronising’ button (note that the folder selection buttons are disabled while synchronisation is in progress).
- Add a file (or files) to the Input folder; the new file(s) will be synchronised and appear in the Target folder.
- Remove a file (or files) from the Input folder; the file(s) will disappear from the Target folder.
- Log messages will appear for all add/remove file actions.
- A status message shows the synchronisation state.

![image](https://github.com/user-attachments/assets/f55b13f6-29f8-42fc-bc05-1c6965024364)

- Click the ‘Stop Synchronising’ button to finish.

Demo:

A recorded demo ‘Dropbox demo.mp4’ shows the running application.

Project notes:

The time spent working on this project was probably about 10-12 hours in total.  This includes initial design work, coding, debugging and testing, as well as writing some example unit and system tests.  Some time was also required for researching WinUI issues.

With more time, a number of changes/improvements could be made, for example:
- before synchronisation is started manually, the initial contents of the input folder could be synced to the target
- as well as addition/removal, synchronisation could take notice of changes to files, e.g. renaming or updating
- the UI could be improved, e.g. keeping the log list scrolled to the end, buttons to open the selected folders, preventing (or improving) window resizing etc.
- comprehensive error/exception handling would be added
- more tests would be written

Project design:
The design attempts to be clean and easy to understand.  It also allows the code to be easily tested in various ways and the tests included in the app solution are there to give an example of some of these.
