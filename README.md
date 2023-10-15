# INS-1_Matrix
Matrix Display made with INS-1 Nixie Tube indicators

ArduinoLibrary contains the library to use the matrix. A description of the animation data format is provided in the docs folder.

INS-1_MatrixDesigner contains a c# WinForms app to help design animations for the display. You can save and load animations from JSON files with this app. This is not a polished applicaiton and it may crash if you do something I didn't think of.
You will just copy and paste the array definition from the output text box into your arduion code.

INS-1 Matrix Board directory contains the kicad files as designed. I recommend moving the resistors for the indicators away from the plated through hole. WHen I had the boards assembled by JLCPCB, the hole was filled with solder. I had to suck the solder out of all the holes that had the resistors right next to the anode hole.
