
// Tabla de valores exportada desde Excel
const unsigned char tabla[34] = {0 ,16 ,32 ,49 ,65 ,81 ,98 ,81 ,65 ,49
   ,32 ,16 ,0 ,15 ,24 ,30 ,33 ,35 ,35 ,33
   ,30 ,24 ,15 ,0 ,220 ,237 ,247 ,253 ,255 ,253
   ,247 ,237 ,220 ,0
};

const int pwmPin = 9;

void setup() {
  // Configurar el pin 9 como salida
  pinMode(9, OUTPUT);
  
  // Configuración del modo PWM rápido de 8 bits
  TCCR1A = _BV(WGM10) | _BV(COM1A1); // WGM10 = 1 (PWM rápido, 8 bits), COM1A1 =  1(salida en pin 9)
  TCCR1B = _BV(WGM12) | _BV(CS10);   // WGM12 = 1 (PWM rápido) y CS10 = 1 (sin prescaler)
}

void loop() {
  for (int i = 0; i < 34; i++) {
    //Asignar a OCR1A es mas eficiente que analogWrite(pwmPin, tabla[i]);
    OCR1A = tabla[i]; 
    //Delay para tiempo de muestreo
    delayMicroseconds(100);
  }  
}
