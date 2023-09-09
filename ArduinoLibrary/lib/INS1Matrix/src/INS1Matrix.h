/*
Library for my INS-1 Nixie Tube Matrix.
Nathan Safran - 9/10/2023
*/

#ifndef INS1Matrix_h
#define INS1Matrix_h
#include "Arduino.h"

class INS1Matrix
{
  public:
    INS1Matrix(uint8_t dataPin, uint8_t clockPin, uint8_t latchPin, uint8_t blankPin, boolean inverted);
    void writeStaticImgToDisplay(uint32_t imgData[], uint8_t displays); // write 2 uint32_t to the display * the num of displays. imgData should be an array of uint32_t 2*displays big
    void setAnimationToDisplay(const uint32_t** animationImgData, uint8_t displays, uint8_t frames, uint8_t delay); // write 2 uint32_t to display * the num of displays, how many frames are in the animation data, the delay between frames in ms. imgData should be a const array of frames (array of uint32_t 2*displays big)
    void animateDisplay();

    

  private:
    uint8_t _dataPin;
    uint8_t _clockPin;
    uint8_t _latchPin;
    uint8_t _blankPin;
    uint8_t _highValue;
    uint8_t _lowValue;
    const uint32_t** _animationImgData;
    uint8_t _displays;
    uint8_t _frames;
    uint8_t _frameDelay;
    boolean _inverted;  //since the shift register is 12v logic level, its mostly likely going to be driven by an inverted signal. Account for this in the code.
    uint32_t _timeSinceLastFrame;  //time since last frame was displayed
    uint8_t _lastFrame; //last frame sent to display

};

#endif
