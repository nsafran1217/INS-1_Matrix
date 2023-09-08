/*
Library for my INS-1 Nixie Tube Matrix.
Nathan Safran - 9/10/2023
*/

#include "Arduino.h"
#include "INS1Matrix.h"

INS1Matrix::INS1Matrix(uint8_t dataPin, uint8_t clockPin, uint8_t latchPin, uint8_t blankPin, boolean inverted)
{
    pinMode(dataPin, OUTPUT);
    pinMode(clockPin, OUTPUT);
    pinMode(latchPin, OUTPUT);
    pinMode(blankPin, OUTPUT);
    _dataPin = dataPin;
    _clockPin = clockPin;
    _latchPin = latchPin;
    _blankPin = blankPin;
    _inverted = inverted;
    _highValue = inverted ? LOW : HIGH; // if signals are inverted, swap the high and low levels we are going to use.
    _lowValue = inverted ? HIGH : LOW;
}

void INS1Matrix::writeStaticImgToDisplay(uint32_t imgData[], uint8_t displays) // write 2 uint32_t to the display * the num of displays. imgData should be an array of uint32_t 2*displays big
{
    uint8_t bitValue;
    for (int i = 0; i < displays * 2; i++) // displays*2 becuase each display needs two uint32_t's
    {
        for (int j = 0; j < 32; j++)
        {
            bitValue = _inverted ? !(imgData[i] & (1ul << j)) : !!(imgData[i] & (1ul << j));
            digitalWrite(_dataPin, bitValue);
            digitalWrite(_clockPin, _highValue);
            digitalWrite(_clockPin, _lowValue);
        }
    }
    digitalWrite(_latchPin, _highValue);
    digitalWrite(_latchPin, _lowValue);
}
void INS1Matrix::setAnimationToDisplay(uint32_t **animationImgData, uint8_t displays, uint8_t frames, uint8_t delay) // write 2 uint32_t to display * the num of displays, how many frames are in the animation data, the delay between frames in ms. imgData should be an array of frames (array of uint32_t 2*displays big)
{
    _animationImgData = animationImgData;
    _displays = displays;
    _frames = frames;
    _frameDelay = delay;
    _timeSinceLastFrame = millis();
    _lastFrame = 0;
    writeStaticImgToDisplay(_animationImgData[_lastFrame], _displays);
}
void INS1Matrix::animateDisplay()
{
    uint32_t currentMillis = millis();
    if ((currentMillis - _timeSinceLastFrame) >= _frameDelay)
    {
        writeStaticImgToDisplay(_animationImgData[_lastFrame], _displays);
        if (_lastFrame < _frames)
        {
            _lastFrame++;
        }
        else
        {
            _lastFrame = 0;
        }

        _timeSinceLastFrame = currentMillis;
    }
}
