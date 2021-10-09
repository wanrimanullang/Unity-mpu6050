#include <MPU6050_tockn.h>
#include <Wire.h>
#define TCAADDR 0x70

void tcaselect(uint8_t i)
{
 if (i > 7) return;
 Wire.beginTransmission(TCAADDR);
 Wire.write(1 << i);
 Wire.endTransmission();  
}

MPU6050 mpu6050_1(Wire);
MPU6050 mpu6050_2(Wire);
MPU6050 mpu6050_0(Wire);

long timer = 0;

void setup() {
  Serial.begin(115200);
  Wire.begin();
  tcaselect(0);
  mpu6050_0.begin();
  mpu6050_0.calcGyroOffsets(true);
  tcaselect(1);
  mpu6050_1.begin();
  mpu6050_1.calcGyroOffsets(true);
  tcaselect(2);
  mpu6050_2.begin();
  mpu6050_2.calcGyroOffsets(true);
}

void tangan0(){
    tcaselect(0);
    mpu6050_0.update();
    Serial.print("0");
    Serial.print(" ");Serial.print(mpu6050_0.getAngleX());
    Serial.print(" ");Serial.print(mpu6050_0.getAngleY());
    Serial.print(" ");Serial.println(mpu6050_0.getAngleZ());
    delay(5);
  }
  
void tangan1(){
    tcaselect(1);
    mpu6050_1.update();
    Serial.print("1");
    Serial.print(" ");Serial.print(mpu6050_1.getAngleX());
    Serial.print(" ");Serial.print(mpu6050_1.getAngleY());
    Serial.print(" ");Serial.println(mpu6050_1.getAngleZ());
    delay(5);
  }
  
void tangan2(){
    tcaselect(2);
    mpu6050_2.update();
    Serial.print("2");
    Serial.print(" ");Serial.print(mpu6050_2.getAngleX());
    Serial.print(" ");Serial.print(mpu6050_2.getAngleY());
    Serial.print(" ");Serial.println(mpu6050_2.getAngleZ());
    delay(5);
  }

void loop() {
  tangan0();
  tangan1();
  tangan2();
}
