/*
XBee-Arduino library 
https://github.com/andrewrapp/xbee-arduino/blob/master/XBee.h
*/
#include <XBee.h>
/*
For Date and time using just software,
based on millis() & timer
*/
#include <RTClib.h>
/*
The Program is for Series 1 XBee
Sends a TX16 or TX64 request with the values of Traffic parameters and checks the status response for success
Note: In my testing it took about 15 seconds for the XBee to start reporting success, so I've added a startup delay
*/
#include <Sleep_n0m1.h>
/* Sleep Mode Library */
XBee xbee = XBee();
RTC_Millis RTC;
unsigned long start = millis();
Sleep sleep;
unsigned long sleepTime; //How long you want the arduino to sleep.
const int XBee_wake = 7; // Arduino pin used to Make the Xbee to sleep

// allocate 13  bytes for to hold traffic parameteres
uint8_t payload[] = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0  };
// // union to convert integer year of date to byte string
union {
  int32_t j;
  byte b[4];
} u;
// Assumptions of vehicle sizes
int randsize[3]={80, 100, 200}; 
int v_size;

//vehicle speed
int  v_speed;

// 16-bit addressing: typically the coordinator 0xFFFF
Tx16Request tx = Tx16Request(0xFFFF, payload, sizeof(payload));
TxStatusResponse txStatus = TxStatusResponse();

// flash TX indicator
int statusLed = 11;
int errorLed = 12;

void flashLed(int pin, int times, int wait)
{
  for (int i = 0; i < times; i++)
  {
    digitalWrite(pin, HIGH);
    delay(wait);
    digitalWrite(pin, LOW);
    if (i + 1 < times)
    {
      delay(wait); 
    }
  }
}

// Function to generate normal distributed random number 
//based on  Average  and Standard Deviation 
double randn (double mu, double sigma)
{
  double U1, U2, W, mult, randnum;
  static double X1, X2;
  static int call = 0;

  if (call == 1)
    {
      call = !call;
      randnum = mu + sigma * (double) X2;
      if (randnum < 20 || randnum > 100)
        return mu;
        else
        return randnum;
    }
 
  do
    {
      // Get two random numbers
      U1 = -1 + ((double) rand () / RAND_MAX) * 2;
      U2 = -1 + ((double) rand () / RAND_MAX) * 2;
      // Radius of circle
      W = pow (U1, 2) + pow (U2, 2);
    }
  while (W >= 1);  //If outside unit circle, then reject number
 
  mult = sqrt ((-2 * log (W)) / W);
  X1 = U1 * mult;
  X2 = U2 * mult;
 
  call = !call;
  randnum = mu + sigma * (double) X1;
      if (randnum < 20 || randnum > 100)
        return mu;
        else
        return randnum;
}

// Generate  normal distributed random Vehicle Size
int GenerateVehicleSize()
{
//  int pickedindex=randn(0.91, 0.41);  
  int pickedindex=random(3);
  return randsize[pickedindex];
}

// Generate  normal distributed random Vehicle speed
int GenerateVehicleSpeed()
{
  return randn(55, 17.8); 
}


void setup()
{
  pinMode(statusLed, OUTPUT);
  pinMode(errorLed, OUTPUT);
  Serial.begin(9600);
  xbee.setSerial(Serial);
  RTC.begin(DateTime(__DATE__, __TIME__)); 
  sleepTime = 898000; //set sleep time in ms, max sleep time is 49.7 days
}

void loop()
{
  // Wake up the XBee
  pinMode(XBee_wake, OUTPUT);
  digitalWrite(XBee_wake, LOW);
  // start transmitting after a startup delay.  Note: this will rollover to 0 eventually so not best way to handle
  if (millis() - start > 15000)
  {
    DateTime now =RTC.now();
    v_size = GenerateVehicleSize();  // random speed
    v_speed= GenerateVehicleSpeed(); // random speed
    
    payload[0] = v_size >> 8 & 0xff; // Converting int to hex could also used highByte() lowByte()
    payload[1] = v_size & 0xff;
    payload[2]=now.day();
    payload[3]=now.month();
    u.j=now.year();
    payload[4] = u.b[3];
    payload[5] = u.b[2];
    payload[6] = u.b[1];
    payload[7] = u.b[0];
    payload[8]=now.hour();
    payload[9]=now.minute();
    payload[10]=now.second();
    payload[11] = v_speed >> 8 & 0xff;
    payload[12] = v_speed & 0xff;
    
    xbee.send(tx);
    // flash TX indicator
    flashLed(statusLed, 1, 100);
    pinMode(XBee_wake, OUTPUT); // put pin in a high impedence state
    digitalWrite(XBee_wake, HIGH);
    sleep.pwrDownMode(); //set sleep mode
    sleep.sleepDelay(sleepTime); //sleep for: sleepTime
    }
  
    // after sending a tx request, we expect a status response
    // wait up to 5 seconds for the status response
    if (xbee.readPacket(5000))
    {
      // got a response!   
      if (xbee.getResponse().getApiId() == TX_STATUS_RESPONSE)
      {
        xbee.getResponse().getTxStatusResponse(txStatus);
        // get the delivery status, the fifth byte
        if (txStatus.getStatus() == SUCCESS)
        {
          // success.  time to celebrate
          flashLed(statusLed, 5, 50);
        }
        else 
        {
          // the remote XBee did not receive our packet. is it powered on?
          flashLed(errorLed, 3, 500);
        }
      }
    }
    else if (xbee.getResponse().isError())
    {
      flashLed(errorLed, 3, 500);
    }
    else 
    {
      // local XBee did not provide a timely TX Status Response.  Radio is not configured properly or connected
      flashLed(errorLed, 2, 50);
    }
    delay(3000);
    // delay(random(1000, 20000));  
}
