# INS-1_Matrix
Matrix Display made with INS-1 Nixie Tube indicators

More info at: https://nsafran.com/ins-1-nixie-tube-matrix.html

ArduinoLibrary contains the library to use the matrix. A description of the animation data format is provided in the docs folder.

INS-1_MatrixDesigner contains a c# WinForms app to help design animations for the display. You can save and load animations from JSON files with this app. This is not a polished application and it may crash if you do something I didn't think of.
You will just copy and paste the array definition from the output text box into your Arduino code.

INS-1 Matrix Board directory contains the KiCAD files as designed. I recommend moving the resistors for the indicators away from the plated through hole. When I had the boards assembled by JLCPCB, the hole was filled with solder. I had to suck the solder out of all the holes that had the resistors right next to the anode hole.

# Completed Boards working
<img src="https://github.com/nsafran1217/INS-1_Matrix/assets/54966414/a1805c81-9221-4923-a68c-82a3d2b319be"  width="50%">

# Unpopulated Board
<img src="https://github.com/nsafran1217/INS-1_Matrix/assets/54966414/0f6f0bf0-60ec-4c30-a390-eeaf1579e8bc"  width="50%">
