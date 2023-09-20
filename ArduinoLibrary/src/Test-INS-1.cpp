#include <INS1Matrix.h>
#include <icons.h>


#define INS1_LATCH_PIN 16 // u2_rxd
#define INS1_DATA_PIN 18
#define INS1_CLK_PIN 17  // u2_txd
#define INS1_BLNK_PIN 19

/*
#define INS1_LATCH_PIN 16
#define INS1_DATA_PIN 17
#define INS1_CLK_PIN 18
#define INS1_BLNK_PIN 19
*/

#define INS1_DISPLAYS 2

INS1Matrix matrix = INS1Matrix(INS1_DATA_PIN, INS1_CLK_PIN, INS1_LATCH_PIN, INS1_BLNK_PIN, true, INS1_DISPLAYS);




void setup()
{
  matrix.writeStaticImgToDisplay(allOn);
  delay(1000);
  matrix.writeStaticImgToDisplay(allOff);
  delay(1000);
  matrix.setAnimationToDisplay(testAnimation);


}

void loop()
{
  // digitalWrite(13, HIGH);
  delay(1);
  // digitalWrite(13, LOW);
  matrix.animateDisplay();
 
  // testMatrix.writeStaticImgToDisplay(const_cast<uint32_t *>(arr[0]), DISPLAYS);

  // put your main code here, to run repeatedly:
}
